FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["CleanArchMvc.WebUI/CleanArchMvc.WebUI.csproj", "CleanArchMvc.WebUI/"]
COPY ["CleanArchMvc.Infra.IoC/CleanArchMvc.Infra.IoC.csproj", "CleanArchMvc.Infra.IoC/"]
COPY ["CleanArchMvc.Application/CleanArchMvc.Application.csproj", "CleanArchMvc.Application/"]
COPY ["CleanArchMvc.Domain/CleanArchMvc.Domain.csproj", "CleanArchMvc.Domain/"]
COPY ["CleanArchMvc.Infra.Data/CleanArchMvc.Infra.Data.csproj", "CleanArchMvc.Infra.Data/"]
RUN dotnet restore "CleanArchMvc.WebUI/CleanArchMvc.WebUI.csproj"
COPY . .
WORKDIR "/src/CleanArchMvc.WebUI"
RUN dotnet build "CleanArchMvc.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanArchMvc.WebUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY cert.pfx cert.pfx

ENV ASPNETCORE_Kestrel__Certificates__Default__Path=cert.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=Cert123
ENV ASPNETCORE_URLS=https://+:443;http://+:80

RUN mkdir -p /keys
VOLUME /keys

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArchMvc.WebUI.dll"]
