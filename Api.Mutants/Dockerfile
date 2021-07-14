#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Api.Mutants/Api.Mutants.csproj", "Api.Mutants/"]
RUN dotnet restore "Api.Mutants/Api.Mutants.csproj"
COPY . .
WORKDIR "/src/Api.Mutants"
RUN dotnet build "Api.Mutants.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.Mutants.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.Mutants.dll"]