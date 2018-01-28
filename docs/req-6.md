# Requisito 6
È arrivato il momento di introdurre la Depedency Injection.

Vorrei che il Samurai ricevesse la propria arma in termini di interfaccia, dal costruttore, così che dal codice produttivo e dai test si possano creare istanze di Samurai armati di Katana o di pistola con il codice

    new Samurai(new Katana());
    new Samurai(new Gun());

Mi piacerebbe anche l'introduzione della Dependency Injection avvenisse senza mai rompere né la compilazione né i test, ma che si proceda a colpi di refactoring.

Anche l'arma `TwoHands` dovrebbe ricevere le proprie dipendenze tramite il costruttore.

## Suggerimenti sulla procedura di refactoring

1. *Object Initializer nei chiamanti*: individuare tutti i punti del codice dove viene invocato `Samurai` e trasformare il set della proprietà `WeaponToUse` in Object initializer, in modo che assomigli al passaggio di parametro dal costruttore;
2. *No `set` e `set` da `WeaponToUse`*: iniziamo ad avvicinare `WeaponToUse` a un field privato, cominciando dall'eliminare i suoi getter e setter
4. *Estrarre `BuildWeapon()`: nel codice di Samurai c'è uno snippet il cui scopo è quello di creare l'istanza corretta di arma. Isoliamo quel codice usando Extract Mehod.
5. *Rendere `BuildWeapon()` pura*: il metodo `BuildWeapon()` accede alla proprietà `WeaponToUse`, per cui non è una funzione pura. Dal momento che il nostro obiettivo è quello di spostare la costruzione delle armi nel chiamante, in modo che l'arma possa essere iniettata, avremo bisogno di spostare `BuildWeapon()`. Non possiamo farlo fintanto che `BuildWeapon()` dipende da variabili diverse dai proprio parametri. Usando  Introduce Variable e Extract Parameter su `WeaponToUse` rendere `BuildWeapon()` pura. Facciamo caso che non possiamo ancora spostare l'invocazioe del metodo nel costruttore, perché `WeaponToUse` viene valorizzato dopo che il costruttore è stato eseguito. 
6. Join declaration and initialization
7. Introdurre il costruttore di default e il costruttore per iniettare WeaponToUse
8. Trasformare gli Object Initializer a chiamate a costruttore
9. WeaponToUse può diventare privata e readonly
10. Eliminare il costruttore di default
11. Adesso possiamo spostare la chiamata a `BuildWeapon` nel costruttore. Per fare questo, introdurre il field `_weapon`. `WeaponToUse` diventa superfluo, e possiamo eliminarlo  con Inline
12. Rendere `BuildWeapon` pubblica e statica per poterla spostare al chiamante. 
13. Spostarla nel chiamante introducendola come parametro
14. Eliminare il dead code, compreso `weaponToUse`, estraendo variabili dai parametri nel chiamante

Per rifattorizzare `TwoHands` si può procedere così:

1. Selezionare le new che istanziano le armi e usare Introduce Field, specificando che si desidera che il valore vanga iniettato dal costruttore.
2. Usare Inline per eliminare le eventuali variabili superflue.


[Indice](../README.md)
