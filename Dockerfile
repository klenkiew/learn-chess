FROM microsoft/dotnet:2.2-sdk AS build

# install node
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_10.x | bash - && \
    apt-get install -y build-essential nodejs

WORKDIR /app/learn-chess
COPY . ./
RUN dotnet restore .
RUN dotnet publish -c Release -o /app/learn-chess/out ./LearnChess.Web/LearnChess.Web.csproj


FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /app/learn-chess
COPY --from=build /app/learn-chess/out/ ./
ENTRYPOINT ["dotnet", "LearnChess.Web.dll"]