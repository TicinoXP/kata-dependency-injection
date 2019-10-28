# Requisito 5

A questo punto dovrebbe essere facile aggiungere armi a piacimento. Creiamo un'ultima arma per il Samurai, applicando il Composite Pattern: dotiamolo della capacità di lottare a due mani, usando sia la Katana che la pistola.

L'arma `TwoHands` risponde alla stessa interfaccia di `Katana` e di `Gun`, e restituisce il messaggio:

    "Raise your hands, <target>, you coward! I chop you in 2, <target>!"

Il valore di `WeaponToUse` per chiedere a un Samurai di lottare a due mani è `katana and gun`.<br />
Non mi interessa che venga gestito il valore con le armi invertite, `gun and katana`.

Di nuovo, vorrei che nessun valore venisse iniettati attraverso i costruttori.

## Esempi

    var samurai = new Samurai();
    samurai.WeaponToUse = "katana and gun";
    samurai.Attack("Christian");
    
    => "I'm a Samurai... Raise your hands, Christian, you coward! I chop you in 2, Christian!"

    
[Indice](../README.md) :: [Requisito 6](req-6.md)
