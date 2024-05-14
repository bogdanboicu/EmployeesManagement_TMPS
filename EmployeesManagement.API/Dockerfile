FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EmployeesManagement.API/EmployeesManagement.API.csproj", "EmployeesManagement.API/"]
COPY ["EmployeesManagement.DataAccess/EmployeesManagement.DataAccess.csproj", "EmployeesManagement.DataAccess/"]
COPY ["EmployeesManagement.Core/EmployeesManagement.Core.csproj", "EmployeesManagement.Core/"]
RUN dotnet restore "EmployeesManagement.API/EmployeesManagement.API.csproj"
COPY . .
WORKDIR "/src/EmployeesManagement.API"
RUN dotnet build "EmployeesManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EmployeesManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeesManagement.API.dll"]
