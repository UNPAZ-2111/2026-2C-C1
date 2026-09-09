class Program
{
    static void Main(string[] args)
    {
        Hormiga brunilda = new Hormiga(50, 30);
        Hormiga hernesto = new Hormiga(0, 0);
        brunilda.Mostrar();
        hernesto.Mostrar();

        Hoja tilo = new Hoja(10, 2);
        //Hoja mate = new Hoja(50, 3);

        brunilda.AgarrarHoja(tilo);
        brunilda.Mostrar();
        
        // BONUS TRACK
        hernesto.AgarrarHoja(brunilda.EntregarHoja());

        hernesto.Mostrar();

        //brunilda.AgarrarHoja(mate);
        //brunilda.Mostrar();

        //brunilda.ComerHoja();
        
        //brunilda.Mostrar();

        //brunilda.EntregarHoja();
        //brunilda.Mostrar();

    }
}

class Hormiga
{
    private int puntosEnergia;
    private int puntosFelicidad;
    private Hoja? miHoja;

    public Hormiga(int puntosEnergia, int puntosFelicidad)
    {
        this.puntosEnergia = puntosEnergia;
        this.puntosFelicidad = puntosFelicidad;
        miHoja = null; 
    }
    public void AgarrarHoja(Hoja unaHoja)
    {
        if (miHoja != null)
        { 
            if (miHoja.getValorEnergetico() < unaHoja.getValorEnergetico()) 
                miHoja = unaHoja;
        }
        else
        {
            miHoja = unaHoja;       
        }
    }
    public void SoltarHoja()
    {
        miHoja = null;
    }
    public void ComerHoja()
    {
        if (miHoja != null)
            miHoja.serComida(this);
    }
    public void RecibirEnergia(int puntosEnergia)
    {
        this.puntosEnergia += puntosEnergia;
    }
    public Hoja? EntregarHoja()
    {
        // Bonus TRACK
        // copiamos la referencia
        Hoja? hojaEntregada = miHoja;

        if (miHoja != null)
        {
            puntosFelicidad += miHoja.getValorEnergetico();
            SoltarHoja();
        }
        return hojaEntregada;
    }
    public void Mostrar()
    {
        Console.WriteLine($"Energia:{puntosEnergia} Felicidad:{puntosFelicidad}");
        if (miHoja != null)
            Console.WriteLine($"\tEnergia de mi hoja:{miHoja.getValorEnergetico()}");
    }

}

class Hoja
{
    private int valorEnergetico;
    private int porciones;

    public Hoja(int valorEnergetico, int porciones)
    {
        this.valorEnergetico = valorEnergetico;
        this.porciones = porciones;
    }

    public int getValorEnergetico() { return valorEnergetico; }

    public void serComida(Hormiga unaHormiga)
    {
        if (porciones > 0)
        {   
            unaHormiga.RecibirEnergia(valorEnergetico);
            porciones--;
        }
    }
}