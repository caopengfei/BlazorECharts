############################################################
# Dockerfile to build Rakor.Blazor.ECharts Demo images
############################################################
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
MAINTAINER Rakor.Cao
COPY . /demo
WORKDIR /demo
EXPOSE 88
CMD ["dotnet", "Demo.dll"]