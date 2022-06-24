FROM mcr.microsoft.com/dotnet/sdk:3.1  as build
WORKDIR /source

EXPOSE 80
EXPOSE 62114

#COPY PROJECT FILES

COPY /*.csproj ./

RUN dotnet restore

#COPY EVERYTHING ELSE

COPY . .
WORKDIR /source/
RUN dotnet publish BP.API.Web.csproj -c Release -o ./app

#Build image 
FROM mcr.microsoft.com/dotnet/sdk:3.1
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet","BP.API.Web.dll"]