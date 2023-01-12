FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OcelotApi/OcelotApi.csproj", "OcelotApi/"]
RUN dotnet restore "OcelotApi/OcelotApi.csproj"
COPY . .
WORKDIR "/src/OcelotApi"
RUN dotnet build "OcelotApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OcelotApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OcelotApi.dll"]
