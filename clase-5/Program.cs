class Program
{
    static void Main(string[] args)
    {
        Jugador jugador = new Jugador();
        Personaje enemigo; // Declaramos una referencia de la clase "base"

        Random rng = new Random();
        // Dependiendo de la suerte construimos un objeto de clase 
        // Esqueleto o Zombie (ambas derivadas)
        if (rng.Next(10) < 5)
            enemigo = new Esqueleto();
        else
            enemigo = new Zombie();

        jugador.irA(Console.WindowWidth / 2, Console.WindowHeight / 2);
        enemigo.irA(17, 17);

        Console.CursorVisible = false;
        Console.Title = "Minecraft (UNPAZ)";
        while (true)
        {
            Console.Clear();

            Console.SetCursorPosition(jugador.getx(), jugador.gety());
            Console.Write(jugador.getapariencia());
            
            Console.SetCursorPosition(enemigo.getx(), enemigo.gety());
            //Console.Write(enemigo.getapariencia());
            Console.Write(enemigo.Apariencia);
            
            jugador.Mover();

            if (enemigo is Zombie)
            {
                Zombie? enemigoZombie; // Declaro una referencia de la clase indicada 
                enemigoZombie = enemigo as Zombie; // obtengo la referencia "como"
                if (enemigoZombie != null)
                    enemigoZombie.Teleportar();
            }

            Esqueleto? enemigoEsqueleto;
            enemigoEsqueleto = enemigo as Esqueleto;
            if (enemigoEsqueleto != null)
                enemigoEsqueleto.Ocultar();

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
    public void setapariencia(char apariencia) { this.apariencia = apariencia; }
    // Declaramos la "propiedad" pública Apariencia
    public char Apariencia
    {
        set 
        { 
            //if (value != 'Z')
            apariencia = '?'; 
        }
        get { return apariencia; }
    }
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
    Random rng;

    public Zombie() : base ('Z')
    {
        rng = new Random();
    }

    override public void RecibirAtaque(Personaje atacante)
    {
        if (atacante is Zombie)
            return;
        objetivo = atacante;
    }
    public void Teleportar()
    {
        irA(rng.Next(80), rng.Next(24));
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
    public void Ocultar() 
    {
        //setapariencia(' ');
        Apariencia = 'A';
    }
}