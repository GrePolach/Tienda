
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app


COPY *.sln ./
COPY Tienda/*.csproj ./Tienda/
RUN dotnet restore


COPY Tienda/. ./Tienda/


RUN dotnet publish Tienda/Tienda.csproj -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app


COPY --from=build /app/out ./


ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
ENV DOTNET_HOST_PATH=/usr/share/dotnet/dotnet

ENV ASPNETCORE_URLS=http://+:$PORT


EXPOSE 8080


ENTRYPOINT ["dotnet", "Tienda.dll"]
