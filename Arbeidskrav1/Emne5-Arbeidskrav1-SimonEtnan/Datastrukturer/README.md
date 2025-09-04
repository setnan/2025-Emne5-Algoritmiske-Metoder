# Arbeidskrav 1 – Del 2: Datastrukturer
Samarbeid mellom Ørjan Sønvisen og Simon Etnan  

Dette prosjektet er en del av innleveringen i faget *Algoritmiske Metoder* ved Gokstadakademiet.  
Oppgaven går ut på å implementere og teste datastrukturer i C#.

## Innhold

- **CircularQueue<T>**
  - En generisk, sirkulær kø med fast kapasitet.
  - Støtter `Enqueue`, `Dequeue`, `Peek`, og utskrift via `PrintCircularQueue`.
  - **Fordeler:** Rask tilgang og forutsigbar ytelse, siden elementene ligger i et sammenhengende array i minnet. Ingen minnefragmentering.
  - **Ulemper:** Fast størrelse – dersom en legger til elementer utover kapasiteten vil disse ikke bli lagt til med en beskjed om at det er fullt. 

- **SinglyLinkedList<T>**
  - En generisk, enkeltlenket liste.
  - Støtter `AddFirst`, `AddLast`, `Remove`, `Contains`, og `PrintContent`.
  - **Fordeler** Dynamisk størrelse, kan utvides både forran, bak og inni. Kan vokse uten å allokere nytt array.
  - **Ulemper** Liniært søk blir tregere fordi den må gå igjennom hver node sekvensielt for å finne et ellement og flytte alle de andre nodene når vi sletter et sted inne i lista. Den bruker også mer minne enn arrays fordi den lagrer en referanse til neste node.

- **Program.cs**
  - Kjører tester på både kø og lenket liste, og viser hvordan metodene fungerer i praksis.

## Eksempel på kjøring

```text
Circular Queue test:
-----------------------------
Kapasitet er satt til 4
Kunne ikke legge til alle elementer: Queue is full
Nåværende elementer: 10, 20, 30, 40
Dequeue: 10
Etter dequeue: 20, 30, 40
Etter enqueue(50): 20, 30, 40, 50
Peek (topp element): 20
Dequeue: 20
Dequeue: 30
Dequeue: 40
Dequeue: 50
Er køen tom? True
```

```text
Singly linked list test:
-----------------------------
Contains(33): False
Antall elementer i listen? 2
Elementer i listen:
Index: 0, Verdi: 30
Index: 1, Verdi: 20
Index: 2, Verdi: 10
Index: 3, Verdi: 230
Index: 4, Verdi: 231
-----------------
```

## Hvordan kjøre prosjektet

1. Klon repoet eller last ned filene.
2. Bygg prosjektet:
   ```bash
   dotnet build
   ```
3. Kjør programmet:
   ```bash
   dotnet run
   ```

## Forbedringer og potensielt Videre arbeid
- Legge til flere datastrukturer (Stack og Queue).
- Benchmarking med [BenchmarkDotNet](https://benchmarkdotnet.org/) for å sammenligne ytelse.
- Legge til diagrammer/illustrasjoner av hvordan strukturene fungerer.

## Teknologi

- Språk: C# (.NET 9)
- IDE: Visual Studio Code / JetBrains Rider
- Prosjektform: Console Application

## Arbeidsmetodikk
- Vi har jobbet mye utifra XP prinsippet hvor en koder og den andre følger med på at koden blir riktig skrevet med tanke på syntaks og logikk. Noe av koden er litt forskjellig siden vi begynte å kode hver for oss, men har etterhvert synkronisert både funksjonsnavn og generell kode.

## Bruk av AI
- AI er brukt aktivt for problemsøking og for å få bedre konseptuell forståelse. 
- Vi har også brukt AI for å generere en mal for README.md filen med riktig formatering som senere er tilpasset til å matche vårt spesifikke prosjekt.


## Egne refleksjoner

**Simon:**  
Veldig fin og utfordrene oppgave hvor vi måtte dykke inn i logikken bak de forskjellige datastrukturene. Jeg synes spesielt at det å samarbeide med Ørjan var fint med tanke på at vi stadig måtte drøfte, tegne opp på whiteboard og prøve å forstå hva vi faktisk skulle gjøre før vi faktisk kodet. Jeg likte spesielt alt knotet vi hadde med ***list.Remove()*** i ***SinglyLinkedList.cs*** hvor vi etter mye kluss på tavla fant ut hvordan koden skulle være og klarte å få den til å virke. Veldig morsom og lærerik prosess.

**Ørjan:**  
Veldig lærerikt. Vi har jobbet jevnt og trutt gjennom uka, både fysisk på Campus og via Teams, og sett til at vi begge forstår alt vi har drevet på med. 
Simon snakker og tenker mye i bilder, så det belyser egentlig ting på en veldig fin måte. Alt i alt er jeg kjempefornøyd med å jobbe på denne måten. 
Jeg føler at vi begge har vokst i hvordan vi forstår konseptene vi har jobbet med denne uka. 