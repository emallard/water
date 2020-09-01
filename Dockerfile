FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Water.WebApi/*.csproj ./Water.WebApi/
COPY Water.Domain/*.csproj ./Water.Domain/
COPY Water.Infrastructure/*.csproj ./Water.Infrastructure/
COPY Water.Domain.Test/*.csproj ./Water.Domain.Test/
RUN dotnet restore

# copy everything else and build app
COPY Water.WebApi/. ./Water.WebApi/
COPY Water.Domain/. ./Water.Domain/
COPY Water.Infrastructure/. ./Water.WebInfrastructureApi/
COPY Water.Domain.Test/. ./Water.Domain.Test/

WORKDIR /app/Water.WebApi
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/Water.WebApi/out ./
ENTRYPOINT ["dotnet", "Water.WebApi.dll"]