# Projekt-dotnet
Projekt na przedmiot dotnet

Komunikacja powinna być zaabezpieczona systemem uwieżytelniania użytkowników.

### Ogólny schemat strony
Home page 
          - logo 
          - zaloguj 
          - moje kursy (zakupione kursy / stworzone kursy)
          - profil
          - polecane kursy 
          - filtrowanie 
          - wyszukiwanie 

Profil (zwykły) 
          - szczegóły profilu
          - możliwość zmiany danych profilu
          - panel z statystykami
          - historia transakcji
          - ostatnio odwiedzone
          
Profil (business) 
          - szczegóły profilu
          - możliwość zmiany danych profilu
          - panel z statystykami business
          - ostatnio odwiedzone
          - tworzenie nowego kursu
          - dostęp do multimediów (pokateryzowane po nazwach stworzonych kursów)
          
Moje kursy (zwykły)
          - zakupione kursy
          - wyszukiwanie
          - filtrowanie
          
Moje kursy (business)
          - stworzone kursy
          - wyszukiwanie
          - filtrowanie        
          - edytowanie kursów
          
Tworzenie kursu (business)
          - Ilość lekcji
          - Tytuł 
          - Opis 
          - Demo
          
Tworzenie lekcji (business)
          - Tytuł
          - Treść
          - Multimedia
          
Tworzenie quizu (business)
          - Tytuł
          - Opis 
          - Pytania 
          - Określenie minimalnego progu 
Wgranie certyfikatu ukończenia kursu (business)

Otworzenie kursu (zwykły)
          - Tytuł 
          - Treść
          - Demo 
          
Dostęp lekcji (zwykły, po zakupie)
          - Możliwe do wyboru konkretne lekcje z kursu
          - Przeglądanie materiałów
          - Przejście do quizu
          
Rozwiązanie quizu (zwykły)
          - Pytanie 
          - Odpowiedz radio 1 z wielu 
          - Zdanie lub powtórzenie testu
          
Ukończenie wszystkich lekcji odblokowuje certyfikat zdania kursu (zwykły)

### COURSE HOUSE

### Funkcjonalności 
1. Logowanie i rejestracja - użytkownika ma możliwość zalogowania na swoje konto użytkownika i założenia konta zwykłego lub business
2. Ocena kursów - widoczna średnia pod każdym kursem, zalogowany użytkownik który zakupił dany kurs może dodać jego ocenę
3. Komentarze do kursu - widoczna po wejściu w szczegóły danego kurs, dostępne tylko dla zalogowanego użytkownika, który zakupił kurs 
4. Strona główna z kursami do wyboru - home page z osobnymi kafelkami dla każdego kursu, po kliknięciu w kurs pojawia się okno z szczegółami 
5. Wyszukiwanie kursów - pole wyszukiwania w home page i zakupionych kursach. Zapewnia szybkie znalezienie kursów w dostępnych lub zakupionych kursach
6. Szczegóły kursów - okno zapewniające dokładne szczegóły danego kursu, zawiera sekcję komentarzy i oceny
7. Filtry - sortowanie kursów po kategorii, cenie, popularności w home page i zakupionych kursach
8. Realizowanie płatności - możliwość zakupienia wybranego kursu realizowane przez zewnętrzną bramkę płatności (lub odpowiednie api)
9. Dodawanie filmów i zdjęć - podczas tworzenia kursu/lekcji. Materiały sa dodawane na serwer do którego użytkownik ma dostęp.
10. Panel kontroli kursu - analiza danych kursu (zapisane ososby, zarobki, średni progres etc.). Znajduje się on w kursach użytkownika.
11. Tworzenie, edycja, usuwanie - kursów stworzonych przez danego użytkownika.
12. Tworzenie, edycja, usuwanie - widoków danego kursu (dodanie lekcji, materiałów wideo, zdjęć i treści)
13. Tworzenie, edycja, usuwanie - trestów dla każdej lekcji kursu
14. Historia płatności wraz z szczegółami transakcji - historia zakupów w profilu użytkownika 
15. Historia ostatnio odwiedzonych kursów/lekcji - ostatnie w profilu użytkownika
16. Panel statystyk użytkownika - zrealizowane kursy, ilość rozwiązanych quizów, uzyskane certyfikaty - panel z informacjami pojawiający się w profilu użytkonika jako element główny
17. Zakupione kursy - wyświetlanie zakupionych kursów. Zakładka w menu głównym.
18. Filtrowanie zakupionych kursów
19. Eksport uzyskanych certyfikatów - odblokowuje się po przejściu danego kursu.
20. Zaawansowane szczegóły kursów - dostęp dla twóry kursu. Umożliwia pogląd zaawansowanych statystyk oraz inne zaawansowane opcje np. wyłączenie komentarzy.
