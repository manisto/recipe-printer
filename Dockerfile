FROM node:12-alpine AS ng

WORKDIR /build

COPY ./Recipes.Client/package*.json ./
RUN npm ci

COPY ./Recipes.Client/ ./
RUN npm run build

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS api

WORKDIR /build

COPY ./Recipes.Api/*.csproj ./Recipes.Api/
COPY ./Recipes.Application/*.csproj ./Recipes.Application/
COPY ./Recipes.Domain/*.csproj ./Recipes.Domain/
COPY ./Recipes.Infrastructure/*.csproj ./Recipes.Infrastructure/
RUN dotnet restore Recipes.Api

COPY ./Recipes.Api/ ./Recipes.Api/
COPY ./Recipes.Application/ ./Recipes.Application/
COPY ./Recipes.Domain/ ./Recipes.Domain/
COPY ./Recipes.Infrastructure/ ./Recipes.Infrastructure/
RUN dotnet publish Recipes.Api -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
EXPOSE 80
WORKDIR /server
COPY --from=api /build/out/ ./
COPY --from=ng /build/dist/recipes-client/ ./client/

CMD ["dotnet", "Recipes.Api.dll"]