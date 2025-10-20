Chateeo

Chateeo is a corporate instant messaging app built with ASP.NET Core and SignalR, enabling real-time communication between users within an organization. The application allows creating chat rooms, sending text messages, and integrating with corporate authentication systems.

🚀 Features

Real-time communication using SignalR.

Support for multiple users and chat rooms.

Layered architecture (API, frontend, shared library).

Integration with authentication systems (e.g., Identity / JWT).

Scalable backend based on ASP.NET Core Web API.

🧩 Project Structure

Chateeo.API – main backend (ASP.NET Core Web API with SignalR Hub).

Chateeo – client application (frontend .NET or SPA hosted by the server).

SharedLibrary – shared data models and helper classes between frontend and backend.

⚙️ Technologies

.NET 7 / ASP.NET Core

SignalR (real-time communication)

Entity Framework Core (database and migrations)

C# 11

Razor / MVC / HTML / CSS / JS (frontend)

💻 Installation and Running
1. Clone the repository
git clone https://github.com/KokeKoke1/Chateeo.git
cd Chateeo

2. Restore dependencies and build
dotnet restore
dotnet build Chateeo.sln

3. Database configuration

In Chateeo.API/appsettings.json, set your connection string under ConnectionStrings, for example:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ChateeoDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}


Apply migrations if using Entity Framework Core:

cd Chateeo.API
dotnet ef database update

4. Run the application

Run the backend:

dotnet run --project Chateeo.API/Chateeo.API.csproj


Default URLs: https://localhost:5001 or http://localhost:5000.

Run the frontend as a separate project (if required):

dotnet run --project Chateeo/Chateeo.csproj


Or, if it has package.json:

cd Chateeo
npm install
npm run dev

🔧 Environment Configuration

Config file: Chateeo.API/appsettings.json

User secrets: store sensitive data (JWT keys, connection strings) in dotnet user-secrets or environment variables

Ports: check Chateeo.API/Properties/launchSettings.json for local ports

🧪 Tests

If the repo contains unit tests:

dotnet test

📦 Deployment (Optional)

Chateeo can be deployed as Docker containers:

Example Dockerfile (API):

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . . 
RUN dotnet restore Chateeo.sln
RUN dotnet publish Chateeo.API/Chateeo.API.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Chateeo.API.dll"]

👥 Contributing

Fork the repository

Create a new branch for your feature

Commit your changes and open a Pull Request

Ensure all tests pass