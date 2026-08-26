class Program
{
    static void Main(string[] args)
    {
        Goblin goblinBlanco = new Goblin();
        goblinBlanco.Mostrar();

        Goblin goblinRojo = new Goblin(ConsoleColor.Red);
        goblinRojo.Mostrar();

        Goblin goblinAzul = new Goblin(50, 50, ConsoleColor.Blue);
        goblinAzul.Mostrar();
    
        Pocion fernet = new Pocion();
        fernet.Mostrar();

        Pocion manaos = new Pocion(20, ConsoleColor.Blue);
        manaos.Mostrar();

        goblinAzul.TomarPocion(manaos);
        goblinAzul.TomarPocion(manaos);
        goblinAzul.TomarPocion(manaos);
        goblinAzul.TomarPocion(fernet);    
        goblinAzul.Mostrar();
        fernet.Mostrar();
        manaos.Mostrar();

    } 
}
class Goblin
{
    private int vida;
    private int energia;
    private ConsoleColor color;

    public Goblin()
    {
        vida = 100;
        energia = 100;
        color = ConsoleColor.Black;
    }

    public Goblin(ConsoleColor color) 
    { 
        this.color = color;
        setVida(100);
        setEnergia(100);
    }

    public Goblin(int vida, int energia, ConsoleColor color)
    {
        this.vida = vida;
        this.energia = energia;
        this.color = color;
    }

    public void setVida(int vida) { this.vida = vida; }

    public void setEnergia(int energia) { this.energia = energia; }

    public void TomarPocion(Pocion unaPocion)
    {
        int coeficiente = 1;
        if (color == unaPocion.getColor())
            coeficiente = 2;

        // si tenés ganas revisá la documentación de la función "min"
        vida += unaPocion.AportarPoder() * coeficiente;
        if (vida > 100)
            vida = 100;
    
    }
    public void Mostrar()
    {
        Console.BackgroundColor = color;
        Console.WriteLine($"Vida:{vida} Energia:{energia}");
        Console.ResetColor();
    }
}

class Pocion
{
    private int poder;
    private ConsoleColor color;
    private bool activa;

    public Pocion()
    {
        poder = 20;
        color = ConsoleColor.Black;
        Activar();
    }
    public Pocion(int poder, ConsoleColor color)
    {
        this.poder = poder;
        this.color = color;
        Activar();
    }
    private void Activar() { activa = true; }
    
    public  void Desactivar() 
    { 
        activa = false; 
    }

    public int getPoder() 
    { 
        return poder; 
    }
    public int AportarPoder()
    {
        if (activa)
        {
            activa = false;
            return poder;
        }
        return 0;
    }
    public ConsoleColor getColor() { return color; }

    public void Mostrar()
    {
        Console.BackgroundColor = color;
        if (activa)
            Console.WriteLine($"Poder:[{poder}");
        else
            Console.WriteLine("Poder:[0]");
        Console.ResetColor();
    }
}