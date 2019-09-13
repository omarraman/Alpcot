FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Alpcot.Api/Alpcot.Api.csproj", "Alpcot.Api/"]
RUN dotnet restore "Alpcot.Api/Alpcot.Api.csproj"
COPY . .
WORKDIR "/src/Alpcot.Api"
RUN dotnet build "Alpcot.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Alpcot.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Alpcot.Api.dll"]