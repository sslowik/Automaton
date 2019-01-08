Playing with C#. 

Examples ToDo: 

[cut]
Zadanie 2
-- ZABAWA Z INTERFEJSAMI --
1. Zaprojektuj interfejs definiujący metodę SayHello()
2. Zaprojektuj kilka klas (3-4) implementujące dany interfejs. Metoda SayHello powinna wypisywać na ekran "Hello World" w kilku różnych językach świata.
3. Zaprojektuj klasę korzystającą ze wzorca Factory. Jej metoda Create powinna zwracać odpowiedni obiekt w zależności od podanego języka w parametrze (niech to będzie Enum).
Np.
var factory = new HelloFactory();
var hello = factory.Create(Languages.Polish);
hello.SayHello();
// wypisze na ekran "Witaj Świecie"
4. Wygeneruj kolekcję w pętli foreach dla każdego języka. Skorzystaj z Enum.GetValues.
5. Przeiteruj po kolekcji i wykonaj metodę SayHello na każdym obiekcie.

Zadanie 3
--ZABAWA Z Plikami--
1. Stwórz folder z plikami w rozszerzeniach: *.txt, *.zip, *.xml - po 5 plików na każde rozszerzenie, losowe nazwy
2. Wczytaj listę plików (tip: skorzystaj z Directory.GetFiles lub Directory.GetFileSystemEntries)
- usuń wszystkie pliki xml
- zmień nazwę każdego pliku zip na: test_nr - gdzie nr to kolejna liczba naturalna
- do każdego pliku txt wklej kolekcję losowych liczb z zakresu 1-100 oddzielonych spacją, skorzystaj z klasy Random
Użyj LINQ tam gdzie to możliwe.

Zadanie 4
-- ZABAWA Z PROCESAMI--
1. Używając klasy Process wykonaj komendę "ipconfig /all"
2. Wyświetl rezultat komendy w konsoli
3. Sparsuj output - wyświetl wszystkie adresy IPv4 jakie zostały wypisane w rezultacie komendy

4. Uruchom Windows Media Player przekazując mu plik muzyczny - dłuższy niż 10 sekund
5. Zakończ proces po 10 sekundach.

Zadanie 5
-- INNE --
1. Sprawdź co oferuje wbudowana klasa Environment
2. Wypisz na ekranie wersję OS, nazwę komputera, nazwę użytkownika i informację czy system jest 64 bitowy.
3. Napisz metody rozszerzające klasę string (extension method):
- metoda która usuwa spacje ze stringa
- metoda, która zwraca true lub false jeżeli string jest nullem albo jest pusty
- metoda, która zamienia taby na spacje
4. Sprawdź co oferuje Action i Func w C#, napisz ktrótką metodę, która przyjmuje inną metodę jako parametr, skorzystaj z wyrażeń lambda.

Koniecznie korzystaj z gita. Każde zadanie to osobny branch "feature-ex-[numer_zadania]". W miarę możliwości niech każdy podpunkt będzie osobnym commitem z odpowiednim commit message.
Kiedy przetestujesz swoje rozwiązanie - domerguj swój feature branch na gałąź develop.
Kiedy ukończysz wszystko: domerguj develop do mastera lub umieść swoje repo na GitHubie (lub innym serwisie) i stwórz pull requesta.

[cut]


