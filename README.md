# Chateeo

Chateeo is a corporate instant messaging app built with ASP.NET Core and SignalR, enabling real-time communication between users within an organization. The application allows creating chat rooms, sending text messages, and integrating with corporate authentication systems.

---

## 🚀 Features

- Real-time communication using SignalR.  
- Support for multiple users and chat rooms.  
- Layered architecture (API, frontend, shared library).  
- Integration with authentication systems (e.g., Identity / JWT).  
- Scalable backend based on ASP.NET Core Web API.

---

## 🧩 Project Structure

- **Chateeo.API** – main backend (ASP.NET Core Web API with SignalR Hub).  
- **Chateeo** – client application (frontend .NET or SPA hosted by the server).  
- **SharedLibrary** – shared data models and helper classes between frontend and backend.

---

## ⚙️ Technologies

- .NET 7 / ASP.NET Core  
- SignalR (real-time communication)  
- Entity Framework Core (database and migrations)  
- C# 11  
- Razor / MVC / HTML / CSS / JS (frontend)

---

## 💻 Installation and Running

1. Clone the repository:
   ```bash
   git clone https://github.com/KokeKoke1/Chateeo.git
   cd Chateeo
