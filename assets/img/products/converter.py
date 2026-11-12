# Converte as antigas imagens png para webp
from pathlib import Path

from PIL import Image

diretorio = Path(".")
for caminho_png in diretorio.glob("*.png"):
    caminho_webp = caminho_png.with_suffix(".webp")
    with Image.open(caminho_png) as img:
        img.save(caminho_webp, format='WEBP', quality=85)

    print(f'Convertido: {caminho_png.name} -> {caminho_webp.name}')

