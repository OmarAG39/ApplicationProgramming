FROM mcr.microsoft.com/dotnet/sdk:3.1  as build
WORKDIR /source

EXPOSE 80
EXPOSE 62114

#COPY PROJECT FILES
COPY *.sln .
COPY src/BP.API.Application/*.csproj ./src/BP.API.Application/
COPY src/BP.API.Core/*.csproj ./src/BP.API.Core/
COPY src/BP.API.EntityFrameworkCore/*.csproj ./src/BP.API.EntityFrameworkCore/
COPY src/BP.API.Web/*.csproj ./src/BP.API.Web/
COPY test/BP.API.Tests/*.csproj ./test/BP.API.Tests/
COPY test/BP.API.Web.Tests/*.csproj ./test/BP.API.Web.Tests/

RUN dotnet restore

#COPY EVERYTHING ELSE
COPY src/BP.API.Application/. ./src/BP.API.Application/
COPY src/BP.API.Core/. ./src/BP.API.Core/
COPY src/BP.API.EntityFrameworkCore/. ./src/BP.API.EntityFrameworkCore/
COPY src/BP.API.Web/. ./src/BP.API.Web/
COPY test/BP.API.Tests/. ./test/BP.API.Tests/
COPY test/BP.API.Web.Tests/. ./test/BP.API.Web.Tests/
WORKDIR /source/src/BP.API.Web
RUN dotnet publish BP.API.Web.csproj -c Release -o /app --no-restore 

#Build image 
FROM mcr.microsoft.com/dotnet/sdk:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet","BP.API.Web.dll"]