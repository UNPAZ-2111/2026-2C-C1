class Pogram
{
    /*static void Main(string[] args)
    {
        for (int i = 0; i < args.GetLength(0); i++)
            Console.WriteLine($"args[{i}]={args[i]}");
    }
    */
    static void Main()
    {
        //Carta carta1 = new Carta(1, "Espadas");
        //Console.WriteLine(carta1.Descripcion());

        Mazo mazo = new Mazo();
        mazo.Generar();
        //Console.WriteLine(mazo.CantidadCartas());
        //mazo.Mostrar();

        //Carta miCarta = mazo.QuitarCartaAlAzar();
        //Console.WriteLine($"Tengo el {miCarta.Descripcion()}");
        //mazo.Mostrar();

        /*
        Jugador dario = new Jugador();

        while (!dario.ManoCompleta())
            dario.RecibirCarta(mazo.QuitarCartaAlAzar());

        dario.Mostrar();
        */
        Carta carta1 = new Carta(7, "Oros");
        Carta carta2 = new Carta(7, "Oros");

        if (carta1 == carta2)
            Console.WriteLine("Son igualitas");
        else
            Console.WriteLine("Ni ahí. ¡ESTÄS COMPARANDO REFERENCIAS!");
    
        if (carta1.esIgualA(carta2))
            Console.WriteLine("Claro que sí");
    
    }
}

class Mazo
{
    private List<Carta> cartas;

    public Mazo()
    {
        cartas = new List<Carta>();
    }

    public void Generar()
    {
       string[] palos = { "Bastos", "Copas", "Espadas", "Oros"};

        for (int i = 0; i < palos.GetLength(0); i++)
            Generar12Cartas(palos[i]);
            //Console.WriteLine($"palos[{i}]={palos[i]}");
    }

    private void Generar12Cartas(string palo)
    {
        for (int i = 0; i < 3; i++)
            cartas.Add(new Carta(i+1, palo));
            
    }
    public int CantidadCartas()
    {
        return cartas.Count();
    }
    public Carta QuitarCartaAlAzar()
    {
        Random rng = new Random();

        int ubicacionCarta = rng.Next(CantidadCartas());
        Carta carta = cartas[ubicacionCarta]; 
        cartas.RemoveAt(ubicacionCarta);
        return carta;
    }

    public void Mostrar()
    {
        /*
        for (int i = 0; i < CantidadCartas(); i++)
            Console.WriteLine(cartas[i].Descripcion());
        */
        // Alternativa con iteradores
        foreach (Carta estaCarta in cartas)
            Console.WriteLine(estaCarta.Descripcion());

    }
}

class Carta
{
    private int valor;
    private string palo;

    public Carta(int valor, string palo)
    {
        this.valor = valor;
        this.palo = palo;
    }
    public int getValor()   { return valor; } // podríamos utilizar propiedades
    public string getPalo() { return palo; }
    public string Descripcion() { return $"{valor} de {palo}"; }

    public bool esIgualA(Carta otraCarta)
    {
        return (valor == otraCarta.getValor() && palo == otraCarta.getPalo());
    }
}

class Jugador
{
    private List<Carta> mano;

    public Jugador()
    {
        mano = new List<Carta>();
    }
    public bool RecibirCarta(Carta unaCarta)
    {
        if (ManoCompleta())
            return false;
        mano.Add(unaCarta);
        return true;
    }
    public bool ManoCompleta()
    {
        return mano.Count() == 3;
    }
    public void Mostrar()
    {
        foreach (Carta estaCarta in mano)
            Console.WriteLine(estaCarta.Descripcion());
    }
}
