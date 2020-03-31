#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-nanoserver-1809 AS build
WORKDIR /src
COPY ["TaskManager.Core/TaskManager.Core.csproj", "TaskManager.Core/"]
COPY ["TaskManager.Storage.JSON/TaskManager.Storage.JSON.csproj", "TaskManager.Storage.JSON/"]
COPY ["TaskManager.Storage/TaskManager.Storage.csproj", "TaskManager.Storage/"]
COPY ["TaskManager.Data/TaskManager.Data.csproj", "TaskManager.Data/"]
COPY ["TaskManager.Base/TaskManager.Base.csproj", "TaskManager.Base/"]
RUN dotnet restore "TaskManager.Core/TaskManager.Core.csproj"
COPY . .
WORKDIR "/src/TaskManager.Core"
RUN dotnet build "TaskManager.Core.csproj" -c Release -o /app -v C:\Users\docker_data\:/storage

FROM build AS publish
RUN dotnet publish "TaskManager.Core.csproj" -c Release -o /app -v C:\Users\docker_data\:/storage

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

WORKDIR /storage
ENTRYPOINT ["dotnet", "TaskManager.Core.dll"]