FROM ubuntu:22.04

ENV DEBIAN_FRONTEND=noninteractive

RUN apt-get update && apt-get install -y \
    gnupg ca-certificates curl \
    && curl -fsSL https://download.mono-project.com/repo/xamarin.gpg -o /etc/apt/keyrings/mono.gpg \
    && echo "deb [signed-by=/etc/apt/keyrings/mono.gpg] https://download.mono-project.com/repo/ubuntu stable-focal main" > /etc/apt/sources.list.d/mono-official-stable.list \
    && apt-get update && apt-get install -y \
        mono-complete \
        mono-xsp4 \
        nuget \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /app
COPY . .

RUN nuget restore packages.config -PackagesDirectory packages -NonInteractive

RUN msbuild My.csproj /p:Configuration=Release /v:m

EXPOSE 8080
COPY entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh
ENTRYPOINT ["/entrypoint.sh"]
