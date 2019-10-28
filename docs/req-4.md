# Requisito 4

Adesso vorrei poter scegliere se armare il Samurai con una Katana o con una pistola.

Siccome ancora non voglio utilizzare la Dependency Injection, vorrei che il Samurai continuasse a conservare un costruttore di default, senza parametri.

Vorrei poter scegliere l'arma da usare mediante una proprietà pubblica chiamata `WeaponToUse`.<br/>
A seconda che il valore di `WeaponToUse` sia `gun` o `katana`, il Samurai dovrebbe crearsi l'istanza corretta di arma.


## Esempi

    var samurai = new Samurai();
    samurai.WeaponToUse = "gun";
    samurai.Attack("Christian");
    
    => "I'm a Samurai... Raise your hands, Christian, you coward!"
    
    
    var samurai = new Samurai();
    samurai.WeaponToUse = "katana";
    samurai.Attack("Christian");
    
    => "I'm a Samurai... I chop you in 2, Christian!"
    
    
[Indice](../README.md) :: [Requisito 5](req-5.md)
