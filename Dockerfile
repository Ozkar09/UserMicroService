FROM mcr.microsoft.com/dotnet/core/sdk:3.1  AS build-env

WORKDIR /UserMicroService/UserMicroService
COPY ./UserMicroService/*.csproj ./
WORKDIR /UserMicroService/UserMicroService.API
COPY ./UserMicroService.API/*.csproj ./
WORKDIR /UserMicroService
COPY nuget.config ./
WORKDIR /UserMicroService/UserMicroService.API
RUN dotnet restore

WORKDIR /UserMicroService/UserMicroService
COPY ./UserMicroService/ ./
WORKDIR /UserMicroService/UserMicroService.API
COPY ./UserMicroService.API/ ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /UserMicroService/UserMicroService.API
ENV ASPNETCORE_ENVIRONMENT="Local"
COPY --from=build-env /UserMicroService/UserMicroService.API/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "UserMicroService.API.dll"]