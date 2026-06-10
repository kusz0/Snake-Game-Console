# Współpraca w projekcie SnakeGame

## Przepływ pracy (Git Flow)

```
main ─────────────────────────────────────────────►
         \                    /
          feature/snake-movement (PR #1)
                    \
                     feature/food-scoring (PR #2)
```

## Konwencje nazewnictwa gałęzi

| Prefiks | Przykład | Kiedy używać |
|---------|----------|--------------|
| `feature/` | `feature/multiplayer` | Nowa funkcja |
| `fix/` | `fix/wall-collision` | Naprawa błędu |
| `docs/` | `docs/readme-update` | Zmiany w dokumentacji |

## Szablon Pull Request

```markdown
## Co zostało zrobione
- Krótki opis zmian

## Jak przetestować
1. dotnet run --project SnakeGame
2. Wybierz tryb X
3. Sprawdź, czy Y działa

## Przypisane zadanie
- Osoba X — opis zadania z README
```

## Szablon Issue

```markdown
**Opis problemu / pomysłu:**
...

**Oczekiwane zachowanie:**
...

**Kroki reprodukcji (jeśli błąd):**
1. ...
2. ...
```

## Checklist przed wysłaniem PR

- [ ] `dotnet build` przechodzi bez błędów
- [ ] Gra uruchamia się i nowa funkcja działa
- [ ] Nie usunięto funkcji innych uczestników
- [ ] Kod jest w odpowiednim pliku (np. ruch → `Snake.cs`, nie `Program.cs`)
