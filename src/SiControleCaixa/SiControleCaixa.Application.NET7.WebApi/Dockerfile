#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SiControleCaixa.Application.NET7.WebApi/SiControleCaixa.Application.NET7.WebApi.csproj", "SiControleCaixa.Application.NET7.WebApi/"]
RUN dotnet restore "SiControleCaixa.Application.NET7.WebApi/SiControleCaixa.Application.NET7.WebApi.csproj"
COPY . .
WORKDIR "/src/SiControleCaixa.Application.NET7.WebApi"
RUN dotnet build "SiControleCaixa.Application.NET7.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SiControleCaixa.Application.NET7.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SiControleCaixa.Application.NET7.WebApi.dll"]