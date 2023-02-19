FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["Services/University/University.Api/University.Api.csproj", "Services/University/University.Api/"]
COPY ["BuildingBlocks/AspNetHelpers/WebApplicationHelpers.csproj", "BuildingBlocks/AspNetHelpers/"]
COPY ["BuildingBlocks/DataAccessHelper.EntityFramework/DataAccessHelper.EntityFramework.csproj", "BuildingBlocks/DataAccessHelper.EntityFramework/"]
COPY ["BuildingBlocks/DataAccessHelper.Abstraction/DataAccessHelper.Abstraction.csproj", "BuildingBlocks/DataAccessHelper.Abstraction/"]
COPY ["BuildingBlocks/DomainHelpers/DomainHelpers.csproj", "BuildingBlocks/DomainHelpers/"]
COPY ["BuildingBlocks/GeneralHelpers/GeneralHelpers.csproj", "BuildingBlocks/GeneralHelpers/"]
COPY ["Services/University/University.Application/University.Application.csproj", "Services/University/University.Application/"]
COPY ["BuildingBlocks/EventBus.Messages/EventBus.Messages.csproj", "BuildingBlocks/EventBus.Messages/"]
COPY ["BuildingBlocks/MediatRHelpers/MediatRHelpers.csproj", "BuildingBlocks/MediatRHelpers/"]
COPY ["BuildingBlocks/ValidationHelpers/ValidationHelpers.csproj", "BuildingBlocks/ValidationHelpers/"]
COPY ["Services/University/University.Domain/University.Domain.csproj", "Services/University/University.Domain/"]
COPY ["Services/University/University.Infrasturcture/University.Infrasturcture.csproj", "Services/University/University.Infrasturcture/"]

RUN dotnet restore "Services/University/University.Api/University.Api.csproj"

COPY . .
WORKDIR "/src/Services/University/University.Api"
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS run-env

EXPOSE 80
EXPOSE 443

WORKDIR /app
COPY --from=build /src/Services/University/University.Api/out .
ENTRYPOINT ["dotnet", "University.Api.dll"]