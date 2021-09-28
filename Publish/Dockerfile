FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
EXPOSE 80
EXPOSE 443
EXPOSE 8081
COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Web.dll