FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /App

COPY . .

RUN dotnet restore

RUN dotnet publish -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /App

COPY bin/docker-entrypoint.sh entrypoint
RUN chmod +x entrypoint

COPY --from=build /App/out .

EXPOSE 5000
ENV ENTRYPOINT="./Fiicode25Auth.API.dll"
ENTRYPOINT ["./entrypoint"]
CMD [ "start-server" ]
