FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base

RUN apt-get update && apt-get install -y curl; \
    mkdir /root/bin && cd /root/bin && curl -JLO https://aka.ms/dotnet-trace/linux-x64 && chmod +x ./dotnet-trace; \
    echo 'export PATH="$PATH:/root/bin"' >> /root/.bashrc

WORKDIR /app
COPY bin/Debug/net5.0 .
ENTRYPOINT ["dotnet", "helloserver.dll"]
