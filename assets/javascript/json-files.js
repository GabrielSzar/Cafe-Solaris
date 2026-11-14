// Grava nos JSON de data/ (clientes, pedidos e itens_pedido).
// JS puro no navegador não escreve em arquivo sozinho: usamos a File System
// Access API, que funciona no Chrome e no Edge. Na primeira gravação o
// navegador pede para escolher a pasta data/; ela fica salva no IndexedDB.

let db_name = "cafe-solaris";
let db_store = "arquivos";
let dir_key = "pasta-data";

function open_db() {
  return new Promise((resolve, reject) => {
    let request = indexedDB.open(db_name, 1);
    request.onupgradeneeded = () => request.result.createObjectStore(db_store);
    request.onsuccess = () => resolve(request.result);
    request.onerror = () => reject(request.error);
  });
}

async function read_saved_dir() {
  let db = await open_db();
  return new Promise((resolve, reject) => {
    let request = db.transaction(db_store).objectStore(db_store).get(dir_key);
    request.onsuccess = () => resolve(request.result || null);
    request.onerror = () => reject(request.error);
  });
}

async function save_dir(dir) {
  let db = await open_db();
  return new Promise((resolve, reject) => {
    let tx = db.transaction(db_store, "readwrite");
    tx.objectStore(db_store).put(dir, dir_key);
    tx.oncomplete = () => resolve();
    tx.onerror = () => reject(tx.error);
  });
}

async function get_data_dir() {
  if (!window.showDirectoryPicker) {
    return null;
  }

  let dir = await read_saved_dir();
  if (!dir) {
    dir = await window.showDirectoryPicker({
      id: "cafe-solaris-data",
      mode: "readwrite",
    });
    if (dir.name !== "data") {
      throw new Error("Escolha a pasta data/ do projeto.");
    }
    await save_dir(dir);
  }

  let permissao = { mode: "readwrite" };
  let liberado =
    (await dir.queryPermission(permissao)) === "granted" ||
    (await dir.requestPermission(permissao)) === "granted";
  if (!liberado) {
    throw new Error("Permissão para gravar em data/ não foi concedida.");
  }
  return dir;
}

// Lê o JSON, deixa change() adicionar o registro e grava de volta.
// Retorna o que change() devolver, ou null se o navegador não consegue gravar.
async function add_json_record(file_name, change) {
  let dir = await get_data_dir();
  if (!dir) {
    return null;
  }

  let file = await dir.getFileHandle(file_name, { create: true });
  let text = await (await file.getFile()).text();
  let records = text.trim() ? JSON.parse(text) : [];

  let result = change(records);

  let writable = await file.createWritable();
  await writable.write(JSON.stringify(records, null, 2));
  await writable.close();
  return result;
}

function next_id(records) {
  return records.reduce((max, r) => Math.max(max, r.id), 0) + 1;
}
