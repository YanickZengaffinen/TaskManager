FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["TaskManager.Core/TaskManager.Core.csproj", "TaskManager.Core/"]
RUN dotnet restore "TaskManager.Core/TaskManager.Core.csproj"
COPY . .
WORKDIR "/src/TaskManager.Core"
RUN dotnet build "TaskManager.Core.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TaskManager.Core.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TaskManager.Core.dll"]