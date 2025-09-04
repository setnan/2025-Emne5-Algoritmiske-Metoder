# Arbeidskrav 1 – Del 1: Algoritmiske Metoder
av Simon Etnan

Dette prosjektet er en del av innleveringen i faget *Algoritmiske Metoder* ved Gokstadakademiet.  
Oppgaven går ut på å bygge strenger og teste disse oppimot hverandre ved hjelp av Benchmarking 

---

## Oppgave 1 – Bygging av strenger og benchmarking

### 1.1 Implementasjoner
Jeg har brukt syv forskjellige måter å bygge en streng som består av `n` like tegn på:

1. **PlusOperator** – `s += 'x'` i løkke (baseline)  
2. **StringBuilder_NoCapacity** – `new StringBuilder()` + `Append('x')`  
3. **StringBuilder_WithCapacity** – `new StringBuilder(n)` + `Append('x')`  
4. **NewStringCtor** – `new string('x', n)`  
5. **Concat_EnumerableRepeat** – `string.Concat(Enumerable.Repeat("x", n))`  
6. **StringCreate_Fill** – `string.Create(n, c, (span, ch) => span.Fill(ch))`  
7. **ArrayPoolFillThenCtor** – Lei buffer fra `ArrayPool<char>`, fyll og bygg streng  

> Kildekode ligger i `StringBuildBenchmark.cs`. Benchmark-klassen bruker `[MemoryDiagnoser]` og `[RankColumn]`.

---

### 1.2 Benchmark-oppsett
- **Runtime:** .NET 9 (RyuJIT, x64)  
- **Maskin:** AMD Ryzen 7 PRO 6850U (Fedora 42)  
- **Verktøy:** [BenchmarkDotNet] v0.15.2  
- **Parametre (N):** 10, 1 000, 10 000, 100 000  

**Installasjon:**  
Prosjektet bruker BenchmarkDotNet som benchmark-rammeverk. Hvis du ikke har det installert, legg det til slik:  
```bash
cd StringBenchmark
dotnet add package BenchmarkDotNet
```

**Kjøring:**
```bash
cd StringBenchmark
dotnet run -c Release
```

**Rapporter:**  
Genereres i `StringBenchmark/BenchmarkDotNet.Artifacts/results/`

---

### 1.3 Resultater og analyse

#### Resultater (utdrag)
Nedenfor er **Mean** og **Allocated** pr metode og N fra siste kjøring.

##### N = 10
| Metode                     | Mean     | Allocated |
|----------------------------|----------|-----------|
| PlusOperator               | 72.46 ns | 336 B     |
| StringBuilder_NoCapacity   | 38.37 ns | 152 B     |
| StringBuilder_WithCapacity | 37.25 ns | 144 B     |
| NewStringCtor              | 10.16 ns | 48 B      |
| Concat_EnumerableRepeat    | 38.67 ns | 88 B      |
| **StringCreate_Fill**      | **8.72 ns** | **48 B**  |
| ArrayPoolFillThenCtor      | 25.15 ns | 48 B      |

##### N = 1 000
| Metode                     | Mean       | Allocated   |
|----------------------------|------------|-------------|
| PlusOperator               | 46.03 µs   | 1 025 976 B |
| StringBuilder_NoCapacity   | 1.325 µs   | 4 576 B     |
| StringBuilder_WithCapacity | 1.242 µs   | 4 096 B     |
| NewStringCtor              | 72.49 ns   | 2 024 B     |
| Concat_EnumerableRepeat    | 1.537 µs   | 2 064 B     |
| **StringCreate_Fill**      | **72.90 ns** | **2 024 B** |
| ArrayPoolFillThenCtor      | 513.07 ns  | 2 024 B     |

##### N = 10 000
| Metode                     | Mean       | Allocated   |
|----------------------------|------------|-------------|
| PlusOperator               | 5.780 ms   | 100 259 976 B |
| StringBuilder_NoCapacity   | 19.49 µs   | 53 200 B    |
| StringBuilder_WithCapacity | 17.62 µs   | 40 096 B    |
| NewStringCtor              | 1.053 µs   | 20 024 B    |
| Concat_EnumerableRepeat    | 23.14 µs   | 20 064 B    |
| StringCreate_Fill          | 1.117 µs   | 20 024 B    |
| ArrayPoolFillThenCtor      | 4.975 µs   | 20 024 B    |

##### N = 100 000
| Metode                     | Mean        | Allocated     |
|----------------------------|-------------|---------------|
| PlusOperator               | 899.1 ms    | 10 004 310 888 B |
| StringBuilder_NoCapacity   | 334.8 µs    | 410 034 B     |
| StringBuilder_WithCapacity | 413.2 µs    | 400 180 B     |
| NewStringCtor              | 128.1 µs    | 200 066 B     |
| Concat_EnumerableRepeat    | 354.9 µs    | 200 106 B     |
| **StringCreate_Fill**      | **88.49 µs** | **200 066 B** |
| ArrayPoolFillThenCtor      | 114.9 µs    | 200 066 B     |

> For de fulle benchmark-rapportene generert av BenchmarkDotNet, kan du se i mappen `BenchmarkDotNet.Artifacts/results/` 
  Der finner du alle detaljerte målinger og tabeller for hver kjøring.

---

#### Analyse og diskusjon

**Hvilken metode er raskest for små N?**  
`StringCreate_Fill` er raskest allerede ved N=10 (~8.7 ns). `new string('x', n)` er nesten like rask.  

**Hvilken metode er raskest for store N?**  
Ved N=100 000 er `StringCreate_Fill` raskest (~88 µs), fulgt av `ArrayPoolFillThenCtor` og `NewStringCtor`.  

**Hvordan påvirker kapasitet i `StringBuilder` resultatene?**  
Som forventet: `WithCapacity` er mer effektiv enn `NoCapacity` for moderate størrelser, men forskjellene kan være små.  

**Hvorfor er `PlusOperator` treg og minnekrevende?**  
Strenger er uforanderlige. `s += c` lager ny streng for hver iterasjon → *O(n²)* tidsbruk og enorme allokeringer (opptil ~10 GB ved N=100 000).  

**Hvilke metoder gir minst allokeringer?**  
`StringCreate_Fill`, `NewStringCtor` og `ArrayPoolFillThenCtor` allokerer bare sluttstrengen. De er mest minneeffektive.  

**Anbefaling:**  
- Kun en streng av samme tegn → `string.Create` eller `new string(c, n)`  
- Bygger du gradvis → `StringBuilder(n)` hvis du vet størrelse, ellers `StringBuilder()`  

## Bruk av AI
- AI er brukt aktivt for problemsøking og for å få bedre konseptuell forståelse. Jeg spurte også AI om tips til hvilke andre metoder som kunne være raskere i forhold til de som var nevnt i oppgaven. Basert på disse spørringene og litt ekstre research fant jeg frem til StringCreate_Fill og ArrayPoolFillThenCtor som jeg har brukt her.
- Jeg brukte også AI for å generere en mal for README.md filen med riktig formatering og uthenting av resultatdata som senere er tilpasset til å matche mitt spesifikke prosjekt.

## Egne refleksjoner
Det var morro å jobbe med denne oppgaven og sammenlikne de forskjellige variantene for ikke å snakke om prosessen med å forsøke å optimalisere hastigheten. Jeg synes det er et veldig stilig verktøy som jeg ser frem til å bruke videre.