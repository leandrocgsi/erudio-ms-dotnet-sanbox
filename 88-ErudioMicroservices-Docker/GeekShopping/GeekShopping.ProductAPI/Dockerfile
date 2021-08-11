#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
RUN dotnet tool install --global nbgv --version 3.4.231    
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GeekShopping.ProductAPI/GeekShopping.ProductAPI.csproj", "GeekShopping.ProductAPI/"]
RUN dotnet restore "GeekShopping.ProductAPI/GeekShopping.ProductAPI.csproj"
COPY . .
WORKDIR "/src/GeekShopping.ProductAPI"
RUN dotnet build "GeekShopping.ProductAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GeekShopping.ProductAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GeekShopping.ProductAPI.dll"]