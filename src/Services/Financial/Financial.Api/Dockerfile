FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["Services/Financial/Financial.Api/Financial.Api.csproj", "Services/Financial/Financial.Api/"]
COPY ["BuildingBlocks/AspNetHelpers/WebApplicationHelpers.csproj", "BuildingBlocks/AspNetHelpers/"]
COPY ["BuildingBlocks/DataAccessHelper.EntityFramework/DataAccessHelper.EntityFramework.csproj", "BuildingBlocks/DataAccessHelper.EntityFramework/"]
COPY ["BuildingBlocks/DataAccessHelper.Abstraction/DataAccessHelper.Abstraction.csproj", "BuildingBlocks/DataAccessHelper.Abstraction/"]
COPY ["BuildingBlocks/DomainHelpers/DomainHelpers.csproj", "BuildingBlocks/DomainHelpers/"]
COPY ["BuildingBlocks/GeneralHelpers/GeneralHelpers.csproj", "BuildingBlocks/GeneralHelpers/"]
COPY ["BuildingBlocks/EventBus.Messages/EventBus.Messages.csproj", "BuildingBlocks/EventBus.Messages/"]
COPY ["Services/Financial/Financial.Application/Financial.Application.csproj", "Services/Financial/Financial.Application/"]
COPY ["BuildingBlocks/MediatRHelpers/MediatRHelpers.csproj", "BuildingBlocks/MediatRHelpers/"]
COPY ["BuildingBlocks/ValidationHelpers/ValidationHelpers.csproj", "BuildingBlocks/ValidationHelpers/"]
COPY ["Services/Financial/Financial.Domain/Financial.Domain.csproj", "Services/Financial/Financial.Domain/"]
COPY ["Services/Financial/Financial.Infrastructure/Financial.Infrastructure.csproj", "Services/Financial/Financial.Infrastructure/"]

RUN dotnet restore "Services/Financial/Financial.Api/Financial.Api.csproj"

COPY . .
WORKDIR "/src/Services/Financial/Financial.Api"
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS run-env

EXPOSE 80
EXPOSE 443

WORKDIR /app
COPY --from=build /src/Services/Financial/Financial.Api/out .
ENTRYPOINT ["dotnet", "Financial.Api.dll"]