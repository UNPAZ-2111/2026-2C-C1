// REPASO ARREGLOS

// Declaramos un arreglo
//int[] dados;

// Construimos un arreglo de la longitud deseada
//dados = new int[5];

// Podemos hacer todo de una
/*
int[] dados = new int[10];

Random rng = new Random();

for (int i = 0; i < dados.GetLength(0); i++)
    dados[i] = rng.Next(1, 7);

for (int i = 0; i < dados.GetLength(0); i++)
    Console.WriteLine($"{dados[i]}");


char[,] letras = new char[3, 3];

char letra = 'A';

for (int f = 0; f < 3; f++)
    for (int c = 0; c < 3; c++)
        letras[f, c] = letra++; 

for (int f = 0; f < 3; f++)
{
    for (int c = 0; c < 3; c++)
        Console.Write($"{letras[f, c]} "); 
    Console.WriteLine();
}

//Console.WriteLine($"{letras[6,6]}");
Console.WriteLine($"La longitud del arreglo dados es: {dados.GetLength(0)}");
*/

class Program
{
    static void Main(string[] args)
    {
        Juego juego = new Juego();
    }
}

class Juego
{
    Random rng;
    public Juego()
    {
        rng = new Random();
        Personaje perso = new Personaje(5, 7);
        
    
        //perso.AgarrarItem(new Botella());
        //perso.AgarrarItem(new Pistola());
        for (int i = 0; i < 4; i++)
        {
            int tipoItem = rng.Next(4);

            switch(tipoItem)
            {
                case 0: // Pistola
                    perso.AgarrarItem(new Pistola());
                    break;
                case 1: // Botella
                    perso.AgarrarItem(new Botella());
                    break;
                case 2: // Cargador
                    perso.AgarrarItem(new Cargador());
                    break;
                case 3: // Bala
                    perso.AgarrarItem(new Bala());
                    break;
            }       
        }
        perso.Mostrar();

    }
}

class Item
{
    private string descripcion;
    private int peso;

    public Item(string descripcion, int peso) 
    { 
        this.descripcion = descripcion; 
        this.peso = peso;
    }

    public string getDescripcion() { return descripcion; }
    public int getPeso() { return peso; }
}

class Pistola : Item
{
    public Pistola() : base("Mega pistola", 4) {}

}

class Botella : Item
{
    public Botella() : base("Super botella", 2) {}
}

class Cargador : Item
{
    public Cargador() : base("Cargador", 2) {}
}

class Bala : Item
{
    public Bala() : base("Bala", 1) {}
}

class Personaje
{
    Item[] inventario;
    private int pesoMaximo;

    public Personaje(int capacidadInventario, int pesoMaximo)
    {
        inventario = new Item[capacidadInventario];
        this.pesoMaximo = pesoMaximo;
    }

    public bool AgarrarItem(Item item)
    {
        if (PesoInventario() + item.getPeso() > pesoMaximo)
            return false;
            
        for (int i = 0; i < inventario.GetLength(0); i++)
            if (inventario[i] == null)
            {
                inventario[i] = item;
                return true;
            }
        return false;
    }

    public bool estaArmado()
    {
        for (int i = 0; i < inventario.GetLength(0); i++)
            if (inventario[i] is Pistola)
                return true;
        return false;
    }
    public int PesoInventario()
    {
        int peso = 0;
        for (int i = 0; i < inventario.GetLength(0); i++)
            if (inventario[i] != null)
                peso += inventario[i].getPeso();
        return peso;
    }

    public void Mostrar()
    {
        Console.WriteLine("Inventario:");
        for (int i = 0; i < inventario.GetLength(0); i++)
            if (inventario[i] != null)
                Console.WriteLine($"\t{inventario[i].getDescripcion()} [{inventario[i].getPeso()}]");
        Console.WriteLine($"Peso: {PesoInventario()}");
    }
}
