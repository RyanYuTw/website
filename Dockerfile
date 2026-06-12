FROM ubuntu:22.04

ENV DEBIAN_FRONTEND=noninteractive

RUN apt-get update && apt-get install -y \
    gnupg ca-certificates curl \
    && apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF \
    && echo "deb https://download.mono-project.com/repo/ubuntu stable-focal main" > /etc/apt/sources.list.d/mono-official-stable.list \
    && apt-get update && apt-get install -y \
        mono-complete \
        mono-xsp4 \
        nuget \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /app
COPY . .

RUN nuget restore packages.config -PackagesDirectory packages -NonInteractive

RUN msbuild My.csproj /p:Configuration=Debug /v:m

EXPOSE 8080
CMD ["xsp4", "--port=8080", "--address=0.0.0.0", "--nonstop"]
