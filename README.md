# MusicStore

**Inhaltsverzeichnis:**

- [MusicStore](#musicstore)
  - [Einleitung](#einleitung)
  - [Bedienungsanleitung für *TemplateTools*](#bedienungsanleitung-für-templatetools)
  - [Datenstruktur](#datenstruktur)
  - [Kennzahlen](#kennzahlen)
    - [Auswertungen](#auswertungen)
  - [Testen des Systems](#testen-des-systems)

---

## Einleitung

Das Projekt **MusicStore** ist ein kleines datenzentriertes Anwendungsbeispiel mit welchem die Erstellung eines Software-Systems dargestellt werden soll. Aufgrund der Komplexität, die ein Software-System im Allgemeinem darstellt, ist die Erstellung des Beispiels in mehreren Themenbereichen unterteilt. Jedes Thema beginnt mit dieser Vorlage und wird entsprechend der jeweiligen Aufgabenstellung erweitert.

Die Umsetzung kann auf verschiedene Arten erfolgen. Zum einen kann die Aufgabe manuell erfolgen. Das ist sehr aufwendig und nimmt viel Zeit in Anspruch. Zum anderen kann die Umsetzung mit Hilfe der Vorlage **SETemplate** erfolgen. Das ist einfacher, erspart sehr viel Zeit und erhöht die Softwarequalität.

Die Vorlage **SETemplate** ist ein Template, welches die Erstellung von Software-Systemen unterstützt und basiert auf dem Konzept der **SEArchitecture**. Die Dokumentation zur **SEArchitecture** finden Sie [hier](https://github.com/leoggehrer/SEArchitecture) und die Dokumentation zur **SETemplate** finden Sie [hier](https://github.com/leoggehrer/SETemplate).

Mit der Vorlage ist es möglich, einzelnen Themenbereiche zu erstellen und die entsprechenden Projekte zu generieren. Diese Themenbereiche sind in der Regel in einem eigenen Projekt bzw. in einen Repository abgelegt. Die nachfolgende Tabelle zeigt die einzelnen Themenbereiche und deren Beschreibung:

| Thema/Ausbaustufe | Beschreibung        | Umsetzung | Projekt      | Anleitung |
|-------------------|---------------------|-----------|--------------|-----------|
| **Base**          | Definieren die Datenstruktur und das Importieren der csv-Daten. | [SEArchitecture](https://github.com/leoggehrer/SEArchitecture) / [SETemplate](https://github.com/leoggehrer/SETemplate) | [SEMusicStoreBase](https://github.com/leoggehrer/SEMusicStoreBase) | Eine Anleitung für die Erstellung einer Datenstruktur finden Sie [hier](https://github.com/leoggehrer/SEBookStore) |
| **Angular**       | Erstellen von **Angular**-Formularen für die Entitäten **Genre**, **Artist**, **Album** und **Tracks**. | [SEArchitecture](https://github.com/leoggehrer/SEArchitecture) / [SETemplate](https://github.com/leoggehrer/SETemplate) | [SEMusicStoreAngular](https://github.com/leoggehrer/SEMusicStoreAngular) | Anleitung im Projekt |
| **AngularStatistics** | Berechnen von Kennzahlen aus den Daten und in Tabellen anzeigen. | [SEArchitecture](https://github.com/leoggehrer/SEArchitecture) / [SETemplate](https://github.com/leoggehrer/SETemplate) | [SEMusicStoreAngularStatistics](https://github.com/leoggehrer/SEMusicStoreAngularStatistics) | Anleitung im Projekt |
| **Angular**       | Erstellen von **Angular**-Formularen für die Entitäten **Genre**, **Artist**, **Album** und **Tracks**. | [SEArchitecture](https://github.com/leoggehrer/SEArchitecture) / [SETemplate](https://github.com/leoggehrer/SETemplate) | [SEMusicStoreAngular](https://github.com/leoggehrer/SEMusicStoreAngular) | In Bearbeitung |
| **AngularStatistics** | Berechnen von Kennzahlen aus den Daten und in Tabellen anzeigen. | [SEArchitecture](https://github.com/leoggehrer/SEArchitecture) / [SETemplate](https://github.com/leoggehrer/SETemplate) | SEMusicStoreAngularStatistics | In Bearbeitung |
| **AngularAuth**   | Erstellen von **Zugriffrollen** für die Entitäten **Genre**, **Artist**, **Album** und **Tracks**.  | [SEArchitecture](https://github.com/leoggehrer/SEArchitecture) / [SETemplate](https://github.com/leoggehrer/SETemplate) | SEMusicStoreAngularAuth | In Bearbeitung. |

---

## Bedienungsanleitung für *TemplateTools*

Eine ausführliche Bedienungsanleitung für das Programm **TemplateTools** finden Sie [hier](https://github.com/leoggehrer/SETemplate?tab=readme-ov-file#bedienungsanleitung).

## Datenstruktur

Die Datenstruktur vom **MusicStore** ist einfach und besteht im Wesentlichen aus 4 Komponenten welche in der folgenden Tabelle zusammengefasst sind:

| Komponente | Beschreibung | Datentyp | Mussfeld | Eindeutig |
|------------|--------------|----------|----------|-----------|
| **Artist** | Der Artist interpretiert und komponiert unterschiedlichste Musik-Titeln. Diese werden in einer oder mehreren Sammlung(en) (Album) zusammengefasst. | | | |
| *Name*     | Name und des Artisten | Text [1024] | Ja | Ja |
| **Album**  | Das Album beinhaltet eine Sammlung von Musik-Titeln (Track) und ist einem Artisten zugeortnet.| | | |
| *Title*    | Titel des Albums | Text [1024] | Ja | Ja |
| *ArtistId* | Fremdschüssel zum Artisten | int | Ja | Nein |
| **Genre**  | Das Genre definiert eine Musikrichtung und dient zur Klassifikation. Diese Information muss einem Musiktitel (Track) zugeordnet sein. | | | |
| *Name*     | Name vom Genre | Text [256] | Ja | Ja |
| **Track**  | Der Track definiert einen Musik-Titel und ist einem Album zugeordnet. Über das Album kann der Artist ermittelt werden. | | | |
| *Title*    | Titel des Musikstückes | Text [1024] | Ja | Nein |
| *Composer* | Komponist des Musikstückes | Text [512] | Nein | Nein |
| *Bytes*    | Größe, in Bytes, des Titles | long | Ja | Nein |
| *Milliseconds* | Zeit des Titles | long | Ja | Nein |
| *UnitPrice* |Kosten des Titles | double | Ja | Nein |
| *GenreId*  | Fremdschüssel zum Genre | int | Ja | Nein |
| *AlbumId*  | Fremdschüssel zum Album | int | Ja | Nein |
|**Hinweis:**| Alle Komponenten haben eine eindeutige Identität (**Id**) | | | |
|*           | *Natürlich können noch weitere Attribute hinzugefügt werden.* | | | |

Aus dieser Definition kann ein entsprechendes Objektmodell abgeleitet werden, welches in der nachfolgend Abbildung dargestellt ist:

![Objektmodell](img/musicstore.png)

## Kennzahlen

Kennzahlen sind statistische Metriken, die zur Analyse von Daten verwendet werden. Diese Kennzahlen können in verschiedenen Bereichen eingesetzt werden, um Trends zu erkennen, Muster zu identifizieren und Entscheidungen zu treffen. In diesem Projekt werden die Kennzahlen auf Basis der Musikdatenbank erstellt.

### Auswertungen

Die Anzeige der einzelnen Kennzahlen erfolgt in einer Tabelle. Die Tabelle wird mit dem **Angular**-Framework erstellt. Die Daten werden über eine **REST-API** bereitgestellt. Die Auswertungen sind in der folgenden Tabelle zusammengefasst:

| Name                   | Beschreibung                              |
|------------------------|-------------------------------------------|
| *Artist und Album*     | Geben Sie den Artisten (**Name**) und die dazugehörigen Alben (**Title**) aus. |
| *Artist und Songs*     | Geben Sie den Artisten (**Name**), die dazugehörigen Songs (**Title**) und das entsprechende Genre (**Name**) aus. |
| *Artist und Statistik* | Geben Sie den Artisten (**Name**), die Anzahl seiner Songs, die gesamte Songzeit [Sekunden] seiner Songs, und die durchschnittliche Songzeit [Sekunden] aller Songs aus. |
| | |
| *Album und Titeln*     | Geben Sie das Album (**Title**) und deren Songs (**Title**) aus. |
| *Album und Statistik*  | Geben Sie das Album (**Title**), die Anzahl der Songs, die gesamte Songzeit [Sekunden] des Albums, und die durchschnittliche Songzeit [Sekunden] aller Alben aus. |
| | |
| *Genre und Songs*      | Geben Sie das Genre (**Name**) und die Anzahl der Titeln aus. |
| *Genre und Statistik*  | Gesamte Songzeit [Sekunden] eines Genre und die durchschnittliche Songzeit [Sekunden] aller Genres aus. |

> **HINWEIS**: Verwenden Sie für die Berechnung der Kennzahlen **Views** auf der Datenbank.

## Testen des Systems

Überprüfen Sie die Kennzahlen mit Excel!

> **Viel Erfolg!**
