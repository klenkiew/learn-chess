# Learn chess

This is a simple application showing possible moves of a few chess pieces. You can select a chess piece, place it on a chessboard and move it according to the chess game rules. Possible moves are provided by the server and displayed on the chessboard.

## Used technology stack

Backend:
- ASP.NET CORE 2.2
- MediatR
- NUit

Frontend:
- Angular 7
- Bootstrap 4

## How to build & run

### With Docker
Prerequisites: Docker & Docker Compose installed
```
docker-compose upW
start firefox/chrome localhost:5000
```

### Without Docker
Prerequisites: node.js 10+, npm 6.4+, .NET Core 2.2 SDK installed
```
dotnet restore .
dotnet publish -c Release -o ../out ./LearnChess.Web/LearnChess.Web.csproj
dotnet out/LearnChess.Web.dll
start firefox/chrome localhost:5000
```

## Project structure

- LearnChess.Application - application and domain logic for the application, mainly calculating and validating possible chess piece moves
- LearnChess.Application.UnitTest - unit tests for the application logic
- LearnChess.Web - a web interface for the application - 1 simple ASP.NET Core controller and a frontend written in Angular
- LearnChess.IntegrationTests - a few simple happy-path integration tests to test the interactions between all the backend layers