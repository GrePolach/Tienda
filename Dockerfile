
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app


COPY *.sln .
COPY *.csproj ./
RUN dotnet restore


COPY . .
RUN dotnet publish Tienda.csproj -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app


COPY --from=build /app/out .


ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
CMD ["dotnet", "Tienda.dll"]
