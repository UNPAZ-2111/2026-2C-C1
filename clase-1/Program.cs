// Controlador
class Program
{
    void Main(string[] args)
    {
        // Repasito interpolación de cadenas de caracteres
        //Console.WriteLine($"1+1={1+1}");

        // Definimos una variable para referir al objeto
        //Auto duna;
        // creamos (construimos) un objeto de esa clase
        //duna = new Auto();

        // todo de una vez
        Auto duna = new Auto();

        // Podemos invocar comportamientos (enviando mensajes)

        duna.Mostrar();
        Console.WriteLine($"{duna.Circular(10)}");
        duna.CargarCombustible(90);
        Console.WriteLine($"{duna.Circular(10)}");
        duna.Mostrar();
    }
}

// Modelo
// Definimos y declaramos las clases

class Auto // Definicion
// Declaración
{
    // Definimos una variable "de clase" para cada atributo
    //private int capacidadTanque;
    // podemos inicializar al mismo tiempo
    private int capacidadTanque = 100;
    private int nivelCombustible = 0;

    // Declaramos y definimos una función "de clase" para cada método
    public void CargarCombustible(int cantidad) // Declaración (método)
    {
        //nivelCombustible = nivelCombustible + cantidad; // Definición (comportamiento)
        nivelCombustible += cantidad; // forma abreviada
    }

    public bool Circular(int distancia)
    {
        if (nivelCombustible < distancia)
        {    
            return false;
        }
        nivelCombustible -= distancia;
        return true;
    }

    public void Mostrar()
    {
        Console.WriteLine($"Combustible:{nivelCombustible}/{capacidadTanque}");
    }
}
