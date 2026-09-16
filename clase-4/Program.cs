class Program
{
    static void Main(string[] args)
    {
        Jugador jugador = new Jugador();
        Zombie zombie1 = new Zombie();
        Zombie zombie2 = new Zombie();
        Esqueleto esqueleto1 = new Esqueleto();

        Random rng = new Random();

        //string identidad = zombie1.ToString();

        


        zombie1.irA(rng.Next(0, Console.WindowWidth), rng.Next(0, Console.WindowHeight));

        zombie2.irA(rng.Next(0, Console.WindowWidth), rng.Next(0, Console.WindowHeight));
        esqueleto1.irA(rng.Next(0, Console.WindowWidth), rng.Next(0, Console.WindowHeight));

        jugador.irA(Console.WindowWidth / 2, Console.WindowHeight / 2);
        
        Console.WriteLine(zombie2);
        Console.WriteLine(jugador);
        Console.ReadKey();
        Console.WriteLine(zombie1.GetType().ToString());    
        zombie1.RecibirAtaque(jugador);
        esqueleto1.RecibirAtaque(zombie1);

        Console.CursorVisible = false;

        while (true)
        {
            Console.Clear();

            Console.SetCursorPosition(jugador.getx(), jugador.gety());
            Console.Write(jugador.getapariencia());
            
            Console.SetCursorPosition(zombie1.getx(), zombie1.gety());
            Console.Write(zombie1.getapariencia());
         
            Console.SetCursorPosition(zombie2.getx(), zombie2.gety());
            Console.Write(zombie2.getapariencia());

            Console.SetCursorPosition(esqueleto1.getx(), esqueleto1.gety());
            Console.Write(esqueleto1.getapariencia());
            
            jugador.Mover();
            zombie1.Perseguir();
            zombie2.Perseguir();
            esqueleto1.Perseguir();

            
            Console.ReadKey();
        }

    }
}

class Personaje
{
    protected int x;
    protected int y;
    private char apariencia;
    protected Personaje? objetivo;

    public Personaje(char apariencia)
    {
        this.apariencia = apariencia;
        this.objetivo = null;
    }
    public int getx() { return x; }
    public int gety() { return y; }
    public char getapariencia() { return apariencia; }

    public void irA(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public void Perseguir()
    {
        if (objetivo == null)
            return;
        if (objetivo.getx() < x) x--;
        if (objetivo.getx() > x) x++;
        if (objetivo.gety() < y) y--;
        if (objetivo.gety() > y) y++;             
    }
    public void Atacar()
    {
        if (objetivo == null)
            return;
        
        objetivo.RecibirAtaque(this);
    }

    virtual public void RecibirAtaque(Personaje atacante)
    {
        Console.WriteLine("Recibir ataque");
    }
}

class Jugador : Personaje
{
    public Jugador() : base('@') 
    {}

    public void Mover()
    {
        x++;
    }

    override public string ToString()
    {
        return $"Soy un jugador, me encontrás en {x},{y}";
    }
}

class Zombie : Personaje 
{
    public Zombie() : base ('Z')
    {}

    override public void RecibirAtaque(Personaje atacante)
    {
        if (atacante is Zombie)
            return;
        objetivo = atacante;
    }

    override public string ToString()
    {
        return "Soy un zombie, pero amigable";
    }
}

class Esqueleto : Personaje
{
    public Esqueleto() : base ('E')
    {}

    override public void RecibirAtaque(Personaje atacante)
    {
        objetivo = atacante;
    }
}