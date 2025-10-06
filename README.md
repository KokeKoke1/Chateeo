[readme.md](https://github.com/user-attachments/files/22728806/readme.md)
# Chateeo

> **Uwaga:** Na podstawie struktury repo (foldery `Chateeo.API`, `Chateeo`, `SharedLibrary`, plik `.sln`) przygotowałem poniższy README. Nie wszystkie pliki źródłowe załadowały się w przeglądarce, więc tam, gdzie konieczne, zostawiłem czytelne miejsca na uzupełnienie (TODO). Jeśli chcesz, mogę automatycznie dopracować README po wskazaniu zawartości `appsettings`/konkretnych portów lub popełnieniu plików, które chcesz, żebym uwzględnił.

---

## Opis projektu

**Chateeo** to aplikacja (frontend + API) zbudowana w technologii .NET/C# (rozszerzenia w repo: `C#`, `HTML`, `CSS`). Projekt zawiera co najmniej trzy projekty/warstwy:

- `Chateeo.API` — backend / Web API (ASP.NET Core).
- `Chateeo` — aplikacja kliencka (może to być ASP.NET MVC / Razor / statyczne pliki frontendowe). Sprawdź zawartość folderu, żeby potwierdzić typ (MVC / SPA).
- `SharedLibrary` — biblioteka współdzielona (modele, DTO, helpery).

Celem README jest szybkie uruchomienie projektu lokalnie, wskazanie najważniejszych plików konfiguracyjnych oraz instrukcji rozwoju.

---

## Wymagania

- .NET SDK 7.0+ (dopasuj wersję do projektu; sprawdź `global.json`, jeśli jest obecny).
- Visual Studio 2022 / Rider / VS Code (opcjonalnie).
- (Opcjonalnie) SQL Server / PostgreSQL / Inna baza danych — sprawdź `appsettings.json` w `Chateeo.API`.
- Git.

---

## Szybki start (CLI)

1. Sklonuj repo:

```bash
git clone https://github.com/KokeKoke1/Chateeo.git
cd Chateeo
```

2. Przywróć pakiety i zbuduj rozwiązanie:

```bash
dotnet restore
dotnet build Chateeo.sln
```

3. Skonfiguruj połączenie z bazą danych dla `Chateeo.API`:

- Otwórz `Chateeo.API/appsettings.json` i ustaw `ConnectionStrings` (np. `DefaultConnection`).
- Jeśli używasz migracji EF Core: uruchom migracje (przykład):

```bash
cd Chateeo.API
# przykładowo dla EF Core CLI
dotnet ef database update
```

**TODO:** Uzupełnij konkretną instrukcję migracji zależnie od użytej bazy i konfiguracji w projekcie.

4. Uruchom API:

```bash
dotnet run --project Chateeo.API/Chateeo.API.csproj
```

Domyślnie API powinno wystartować na porcie podanym w `launchSettings.json` (np. `https://localhost:5001`). Jeśli nie znasz portu, sprawdź `Chateeo.API/Properties/launchSettings.json`.

5. Uruchom aplikację kliencką (jeśli to osobny projekt .NET):

```bash
dotnet run --project Chateeo/Chateeo.csproj
```

Lub jeśli frontend to statyczne/SPA, uruchom serwer dev (np. `npm`/`ng`/`vite`) — sprawdź folder `Chateeo`.

---

## Konfiguracja

- `Chateeo.API/appsettings.json` — główne ustawienia aplikacji (ConnectionStrings, JWT, inne klucze). Upewnij się, że poufne dane przechowujesz w `user secrets` lub zmiennych środowiskowych.

- `Chateeo/` — sprawdź, czy projekt wymaga Node/NPM do budowy frontendu. Jeśli tak, wykonaj:

```bash
cd Chateeo
npm install
npm run dev
```

(Jeśli nie ma `package.json`, wtedy frontend jest najpewniej częścią projektu .NET i uruchamia się przez `dotnet run`.)

---

## Dev: testy i lint

- Jeśli projekt zawiera testy — poszukaj folderu `Tests` lub projektów `*.Tests`. Uruchom testy poleceniem:

```bash
dotnet test
```

- Linter/formatowanie — zależy od repo (EditorConfig, dotnet-format, ESLint). Jeśli chcesz, mogę dodać konfigurację przykładową.

---

## Najważniejsze pliki / gdzie szukać

- `Chateeo.API/Controllers/` — kontrolery Web API.
- `Chateeo.API/Properties/launchSettings.json` — porty i profile uruchomieniowe.
- `Chateeo/` — frontend / UI.
- `SharedLibrary/` — wspólne modele/enumy.
- `Chateeo.sln` — rozwiązanie .NET.

---

## Propozycja struktury README (do ewentualnego rozszerzenia)

1. Opis projektu
2. Technologie
3. Instalacja i uruchomienie (lokalnie)
4. Konfiguracja (baza danych, klucze)
5. Jak rozwijać (branching, testy)
6. Wskazówki dotyczące wdrożenia (Docker/Kubernetes) — jeśli potrzebujesz, mogę dodać przykładowy `Dockerfile` i `docker-compose`.

---

## Wkład / Contributing

1. Fork → branch → PR.
2. Zadbaj o testy dla nowych funkcji.
3. Opisz większe zmiany w `CHANGELOG.md` lub w opisie PR.

---

## Licencja

Brak pliku `LICENSE` w repo (na dzień przygotowania tego README). Jeżeli chcesz, mogę dodać przykładową licencję (MIT/Apache2.0). Wybierz którą preferujesz.

---

## Kontakt

Masz dodatkowe wymagania co do README (np. angielska wersja, badge'y CI, instrukcja Docker), napisz — dopracuję od ręki.

---

### Co znalazłem i co jest niepełne

Sprawdziłem repo pod adresem `https://github.com/KokeKoke1/Chateeo`. Widoczna struktura projektu zawiera foldery: `Chateeo.API`, `Chateeo`, `SharedLibrary` oraz plik `Chateeo.sln`. Nie widziałem pliku README lub LICENSE w repo. Podczas przeglądania GitHub część zawartości (szczegółowe pliki) nie załadowała się z powodów renderera strony (strona zwróciła komunikat "There was an error while loading. Please reload this page."). Dlatego nie mogłem przeczytać szczegółowych plików konfiguracyjnych (np. `appsettings.json`, `launchSettings.json`) — zostawiłem więc w README czytelne `TODO` i wskazówki, gdzie uzupełnić wartości (porty, connection stringi, instrukcje migracji).

Jeśli chcesz, mogę teraz:

- dodać plik `README.md` bezpośrednio do repo (potrzebowałbym uprawnień lub PR z Twojego forka),
- albo jeśli wkleisz zawartość `Chateeo.API/appsettings.json` oraz `Chateeo/` (krótki opis), dopracuję README z dokładnymi portami i komendami.

---

Powiedz jak chcesz dalej: wrzucić README do repo (przez PR) czy tylko przygotować plik lokalnie do wklejenia?  

