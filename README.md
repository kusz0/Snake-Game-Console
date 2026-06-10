# SnakeGame

Prosta gra Snake w konsoli napisana w C# (.NET 8). Projekt został przygotowany do współpracy zespołowej na GitHub — każdy uczestnik pracuje na osobnej gałęzi i wysyła zgłoszenia zmian (Pull Request).

## Funkcje gry

- **Tryb solo** — jeden wąż sterowany strzałkami
- **Tryb wieloosobowy** — dwa węże na jednej planszy:
  - Gracz 1: strzałki (↑ ↓ ← →)
  - Gracz 2: klawisze WASD
- **Jedzenie** — zbieranie `*` zwiększa wynik i wydłuża węża
- **Kolizje** — ściany, własne ciało oraz ciało drugiego gracza kończą grę
- **Punktacja** — wynik wyświetlany na dole ekranu

## Uruchomienie

### Wymagania

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Uruchomienie z terminala

```bash
git clone https://github.com/<twoj-uzytkownik>/SnakeGame.git
cd SnakeGame
dotnet run --project SnakeGame
```

### Uruchomienie w Visual Studio

1. Otwórz plik `SnakeGame.sln`
2. Ustaw projekt `SnakeGame` jako projekt startowy
3. Naciśnij **F5**

## Struktura projektu

| Plik | Opis |
|------|------|
| `Program.cs` | Menu gry, wybór trybu solo / multiplayer |
| `Game.cs` | Pętla gry, rysowanie, kolizje, obsługa wielu graczy |
| `Snake.cs` | Logika węża: ruch, rośnięcie, kolizje |
| `Obstakel.cs` | Jedzenie na planszy |
| `Pixel.cs` | Pozycja i kolor segmentu węża |

## Podział zadań w zespole

Każdy uczestnik realizuje jedno zadanie na osobnej gałęzi:

| Uczestnik | Gałąź | Zadanie |
|-----------|-------|---------|
| Osoba A | `feature/snake-movement` | Ruch węża i śledzenie ciała |
| Osoba B | `feature/keyboard-input` | Obsługa klawiszy (solo + multiplayer) |
| Osoba C | `feature/food-scoring` | Jedzenie, punktacja, losowe pozycje |
| Osoba D | `feature/collisions` | Kolizje ze ścianami, sobą i innymi graczami |
| Osoba E | `feature/multiplayer` | Tryb wieloosobowy — dwa węże na planszy |
| Osoba F | `feature/ui-menu` | Menu startowe i ekran końca gry |

## Współpraca na GitHub

### 1. Sklonuj repozytorium

```bash
git clone https://github.com/<twoj-uzytkownik>/SnakeGame.git
cd SnakeGame
```

### 2. Utwórz gałąź dla swojego zadania

```bash
git checkout -b feature/nazwa-zadania
```

### 3. Wprowadź zmiany i wyślij na GitHub

```bash
git add .
git commit -m "Dodaj obsługę klawiszy dla gracza 2"
git push -u origin feature/nazwa-zadania
```

### 4. Utwórz Pull Request

1. Wejdź na stronę repozytorium na GitHub
2. Kliknij **Compare & pull request**
3. Opisz wprowadzone zmiany
4. Poproś innych uczestników o recenzję

### 5. Recenzja i scalenie

- Co najmniej jeden inny uczestnik przegląda kod i dodaje komentarze
- Po akceptacji właściciel PR scala zmiany do gałęzi `main`
- Po scaleniu wszyscy testują grę: `dotnet run --project SnakeGame`

### 6. Issues — zgłaszanie problemów i pomysłów

Przykładowe issue do utworzenia na GitHub:

- **Tytuł:** Dodaj poziomy trudności (szybkość węża)
- **Opis:** Gra powinna oferować wolny / normalny / szybki tryb
- **Przypisanie:** wybierz siebie jako Assignee
- **Rozwiązanie:** utwórz gałąź `fix/difficulty-levels`, zaimplementuj, wyślij PR

## Zasady współpracy

1. Gałąź `main` musi zawsze zawierać działającą grę
2. Każda funkcja = osobna gałąź + osobny Pull Request
3. Przed wysłaniem PR uruchom `dotnet build` i przetestuj grę
4. Komentarze w PR traktuj konstruktywnie — sugeruj poprawki, nie odrzucaj bez uzasadnienia
5. Po scaleniu PR wszyscy robią `git pull origin main`

## Sterowanie

| Tryb | Gracz | Klawisze |
|------|-------|----------|
| Solo | Gracz 1 | ↑ ↓ ← → |
| Multiplayer | Gracz 1 | ↑ ↓ ← → |
| Multiplayer | Gracz 2 | W A S D |

## Licencja

Projekt edukacyjny — Uniwersytet.
