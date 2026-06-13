# syntax=docker/dockerfile:1
FROM ubuntu:20.04

ENV DEBIAN_FRONTEND=noninteractive

RUN apt-get update && apt-get install -y \
    gnupg ca-certificates curl \
    && mkdir -p /etc/apt/keyrings \
    && curl -fsSL https://download.mono-project.com/repo/xamarin.gpg | gpg --dearmor -o /etc/apt/keyrings/mono.gpg \
    && echo "deb [signed-by=/etc/apt/keyrings/mono.gpg] https://download.mono-project.com/repo/ubuntu stable-focal main" > /etc/apt/sources.list.d/mono-official-stable.list \
    && apt-get update && apt-get install -y \
        mono-complete \
        mono-xsp4 \
        nuget \
        imagemagick \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /app
COPY . .

RUN nuget restore My.sln -NonInteractive

RUN msbuild My.csproj /p:Configuration=Release /v:m /p:VisualStudioVersion=14.0

RUN <<'RESIZE'
#!/bin/sh
IMG=/app/Content/images

crop() {
    src="$1"; w="$2"; h="$3"; sfx="$4"
    [ -f "$src" ] || return
    base="${src%.*}"; ext="${src##*.}"
    convert "$src" -resize "${w}x${h}^" -gravity Center -extent "${w}x${h}" "${base}_${sfx}.${ext}"
}

for f in "$IMG/products/"*; do
    [ -f "$f" ] || continue
    crop "$f" 640 427 list
    crop "$f" 1280 853 detail
done

for f in "$IMG/blog/"*; do
    [ -f "$f" ] || continue
    crop "$f" 640 360 list
    crop "$f" 1280 720 detail
done

[ -f "$IMG/banner.jpg" ] && crop "$IMG/banner.jpg" 1280 480 desktop && crop "$IMG/banner.jpg" 640 240 mobile || true
[ -f "$IMG/no-image.png" ] && crop "$IMG/no-image.png" 640 427 list && crop "$IMG/no-image.png" 1280 853 detail || true
echo "Image resize done"
RESIZE

EXPOSE 8080
COPY entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh
ENTRYPOINT ["/entrypoint.sh"]
