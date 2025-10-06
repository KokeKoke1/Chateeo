[readme (1).md](https://github.com/user-attachments/files/22728851/readme.1.md)
# Chateeo

**Chateeo** to firmowy komunikator internetowy zbudowany w technologii **ASP.NET Core** i **SignalR**, umożliwiający komunikację w czasie rzeczywistym między użytkownikami w ramach jednej organizacji. Aplikacja pozwala na tworzenie pokoi rozmów, przesyłanie wiadomości tekstowych oraz integrację z systemami autoryzacji firmowej.

---

## 🚀 Funkcje

- Komunikacja w czasie rzeczywistym dzięki **SignalR**.
- Obsługa wielu użytkowników i pokoi rozmów.
- Architektura warstwowa (API, frontend, biblioteka współdzielona).
- Możliwość integracji z systemami logowania (np. Identity / JWT).
- Skalowalny backend w oparciu o **ASP.NET Core Web API**.

---

## 🧩 Struktura projektu

- `Chateeo.API` – główny backend (ASP.NET Core Web API z SignalR Hubem).
- `Chateeo` – aplikacja kliencka (frontend .NET lub SPA hostowane przez serwer).
- `SharedLibrary` – modele danych i klasy pomocnicze współdzielone między frontendem i backendem.

---

## ⚙️ Technologie

- **.NET 7 / ASP.NET Core**
- **SignalR** (komunikacja w czasie rzeczywistym)
- **Entity Framework Core** (baza danych i migracje)
- **C# 11**
- **Razor / MVC / HTML / CSS / JS** (frontend)

---

## 💻 Instalacja i uruchomienie

### 1. Klonowanie repozytorium

```bash
git clone https://github.com/KokeKoke1/Chateeo.git
cd Chateeo
```

### 2. Przywracanie zależności i budowanie

```bash
dotnet restore
dotnet build Chateeo.sln
```

### 3. Konfiguracja bazy danych

W pliku `Chateeo.API/appsettings.json` ustaw połączenie w sekcji `ConnectionStrings`, np.:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ChateeoDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

Zastosuj migracje, jeśli projekt używa **Entity Framework Core**:

```bash
cd Chateeo.API
dotnet ef database update
```

### 4. Uruchomienie aplikacji

Uruchom backend:

```bash
dotnet run --project Chateeo.API/Chateeo.API.csproj
```

Domyślnie dostępne pod adresem `https://localhost:5001` lub `http://localhost:5000`.

Frontend uruchom jako osobny projekt (jeśli wymaga):

```bash
dotnet run --project Chateeo/Chateeo.csproj
```

lub, jeśli zawiera plik `package.json`:

```bash
cd Chateeo
npm install
npm run dev
```

---

## 🔧 Konfiguracja środowiska

- **Plik konfiguracyjny:** `Chateeo.API/appsettings.json`
- **Sekrety użytkownika:** przechowuj poufne dane (np. klucze JWT, connection strings) w `dotnet user-secrets` lub zmiennych środowiskowych.
- **Porty:** sprawdź `Chateeo.API/Properties/launchSettings.json`, aby poznać porty lokalne.

---

## 🧪 Testy

Jeśli repo zawiera testy jednostkowe:

```bash
dotnet test
```

---

## 📦 Deployment (opcjonalnie)

Chateeo można wdrożyć jako kontenery Docker:

Przykład `Dockerfile` (API):

```dockerfile
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
```

---

## 👥 Wkład w projekt

1. Forkuj repozytorium.
2. Utwórz nowy branch dla swojej funkcji.
3. Zrób commit i otwórz Pull Request.
4. Upewnij się, że wszystkie testy przechodzą pomyślnie.



---

> Chateeo – bezpieczny, firmowy komunikator czasu rzeczywistego oparty na ASP.NET Core i SignalR.

