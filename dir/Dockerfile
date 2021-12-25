FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base

WORKDIR /app
COPY bin/Debug/net5.0 .
ENTRYPOINT ["dotnet", "dir.dll"]
