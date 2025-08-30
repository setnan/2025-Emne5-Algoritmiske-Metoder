# Oppgave 2 – Datastrukturer

## Implementasjoner
- **MyStack<T>**: array-basert stabel (LIFO) med auto-resize (dobling).
- **MyQueue<T>**: sirkulær buffer + auto-resize (FIFO).
- **CircularQueue<T>**: sirkulær buffer med fast kapasitet (kaster ved full/empty).
- **SinglyLinkedList<T>**: enkelt lenket liste med head/tail.

## Kompleksitet
| Datastruktur        | Operasjon                | Kompleksitet |
|---------------------|--------------------------|--------------|
| **Stack**           | Push / Pop / Peek        | O(1) amortisert |
| **Queue**           | Enqueue / Dequeue / Peek | O(1) amortisert (resize sjelden) |
| **CircularQueue**   | Enqueue / Dequeue / Peek | O(1), fast minne |
| **SinglyLinkedList**| AddFirst / AddLast       | O(1) |
|                     | Remove / Contains        | O(n) |

## Designvalg
- **Stack/Queue**: bruker array internt → god cache-lokalitet, enkel å implementere resize (dobling av kapasitet).
- **CircularQueue**: fast kapasitet → egner seg til ringbuffer og sanntidsstrømmer. Kast ved overflow/underflow.
- **SinglyLinkedList**: nodebasert → O(1) innsetting i front/bak, men O(n) søk og svak cache-lokalitet.

## Feilhåndtering
- Underflyt: `InvalidOperationException` kastes på `Pop`, `Peek` og `Dequeue` når tom.
- Overflyt: `InvalidOperationException` kastes i `CircularQueue.Enqueue()` når køen er full.

## Bruksområder
- **Stack**: funksjonskall, undo-funksjoner, parentes-sjekk.
- **Queue**: jobbplanlegging, køsystemer, BFS (graftraversering).
- **CircularQueue**: streaming, sanntidssystemer, nettverksbuffere.
- **SinglyLinkedList**: dynamiske lister med mye innsetting/fjerning uten kjent kapasitet.

## Demo
Se `Program.cs` for små eksempler og kanttilfeller. Programmet skriver ut tester for alle fire datastrukturer.