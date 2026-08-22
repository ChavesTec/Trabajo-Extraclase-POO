// Clase Vehiculo

class Vehiculo
{
    private string color;
    private int id;
    private bool disponible = true;
    private int velocidad_max;
    private int capacidad_pasajeros;
    private float costo_renta;
    private bool encendido = false;

    public Vehiculo(string color, int id, int velocidad_max,
                int capacidad_pasajeros, float costo_renta)
    {
    this.color = color;
    this.id = id;
    this.velocidad_max = velocidad_max;
    this.capacidad_pasajeros = capacidad_pasajeros;
    this.costo_renta = costo_renta;
    }

    private void encender()
    {
        if (this.encendido == true)
        {
            Console.WriteLine("Ya estaba encendido");
        }
        else
        {
            this.encendido = true;
            Console.WriteLine("Encendido");
        }
    }

    private void apagar()
    {
        if (this.encendido == false)
        {
            Console.WriteLine("Ya estaba apagado");
        }
        else
        {
            this.encendido = false;
            Console.WriteLine("Apagado");
        }
    }

    private void pintar(string new_color)
    {
        if (new_color == this.color)
        {
            Console.WriteLine("No se puede pintar un vehiculo del mismo color del que estaba pintado");
        }
        else
        {
            this.color = new_color;
            Console.WriteLine($"Pintado de {this.color}.");
        }
    }

    public float CostoRenta
    {
        get { return costo_renta;}
    }
    public bool Disponible
    {
        get { return disponible;}
    }
    internal void MarcarRentado()
    {
        this.disponible = false;
    }
    internal void MarcarDevuelto()
    {
        this.disponible = true;
    }
}

// Clases de todos los tipos de vehiculos

// Marino
class VehiculoMarino : Vehiculo
{
    private int capacidad_carga;
    private int num_motores;

    public VehiculoMarino(string color, int id, int velocidad_max,
    int capacidad_pasajeros, float costo_renta, int capacidad_carga, int num_motores):
    base(color, id, velocidad_max, capacidad_pasajeros, costo_renta)
    {
        this.capacidad_carga = capacidad_carga;
        this.num_motores = num_motores;
    }
}
// Fin marino

// Terrestre
class VehiculoTerrestre : Vehiculo
{
    private int num_llantas;

    public VehiculoTerrestre(string color, int id, int velocidad_max,
    int capacidad_pasajeros, float costo_renta, int num_llantas):
    base(color, id, velocidad_max, capacidad_pasajeros, costo_renta)
    {
        this.num_llantas = num_llantas;
    }
}
// Fin terrestre

// Aereo
class VehiculoAereo : Vehiculo
{
    private int num_motores;
    private int altura_max_aprox;
    private bool tiene_piloto_automatico;

    public VehiculoAereo(string color, int id, int velocidad_max,
    int capacidad_pasajeros, float costo_renta, int num_motores, 
    int altura_max_aprox, bool tiene_piloto_automatico):
    base(color, id, velocidad_max, capacidad_pasajeros, costo_renta)
    {
        this.altura_max_aprox = altura_max_aprox;
        this.num_motores = num_motores;
        this.tiene_piloto_automatico = tiene_piloto_automatico;
    }
}
// Fin aereo


// Subclases vehiculos terrestres
class Coche : VehiculoTerrestre
{
    private int num_puertas;
    private bool tiene_aire_acondicionado;

    public Coche(string color, int id, int velocidad_max,
    int capacidad_pasajeros, float costo_renta, int num_llantas,
    int num_puertas, bool tiene_aire_acondicionado):
    base(color, id, velocidad_max, capacidad_pasajeros, costo_renta, num_llantas)
    {
        this.tiene_aire_acondicionado = tiene_aire_acondicionado;
        this.num_puertas = num_puertas;
    }
}

class Moto : VehiculoTerrestre
{
    private bool tiene_maletero;

    public Moto(string color, int id, int velocidad_max,
    int capacidad_pasajeros, float costo_renta, int num_llantas,
    bool tiene_maletero):
    base(color, id, velocidad_max, capacidad_pasajeros, costo_renta, num_llantas)
    {
        this.tiene_maletero = tiene_maletero;
    }
}


// Subclases vehiculos aereos
class Helicoptero : VehiculoAereo
{
    public Helicoptero(string color, int id, int velocidad_max,
    int capacidad_pasajeros, float costo_renta, int num_motores, 
    int altura_max_aprox, bool tiene_piloto_automatico):
    base(color, id, velocidad_max, capacidad_pasajeros, costo_renta,
    num_motores, altura_max_aprox, tiene_piloto_automatico) {}
}

class Avion : VehiculoAereo
{
    public Avion(string color, int id, int velocidad_max,
    int capacidad_pasajeros, float costo_renta, int num_motores, 
    int altura_max_aprox, bool tiene_piloto_automatico):
    base(color, id, velocidad_max, capacidad_pasajeros, costo_renta,
    num_motores, altura_max_aprox, tiene_piloto_automatico) {}
}


// Subclases vehiculos marinos
class Barco : VehiculoMarino
{
    public Barco(string color, int id, int velocidad_max,
    int capacidad_pasajeros, float costo_renta, int capacidad_carga, int num_motores):
    base(color, id, velocidad_max, capacidad_pasajeros, costo_renta, capacidad_carga,
    num_motores) {}
}

class Submarino : VehiculoMarino
{
    private int profundidad_maxima_aprox;
    private float capacidad_oxigeno;

    public Submarino(string color, int id, int velocidad_max,
    int capacidad_pasajeros, float costo_renta, int capacidad_carga, int num_motores,
    int profundidad_maxima_aprox, float capacidad_oxigeno):
    base(color, id, velocidad_max, capacidad_pasajeros, costo_renta, capacidad_carga,
    num_motores)
    {
        this.profundidad_maxima_aprox = profundidad_maxima_aprox;
        this.capacidad_oxigeno = capacidad_oxigeno;
    }
}


// Clase Cliente
class Cliente
{
    private int id;
    private string nombre;
    private float presupuesto;
    private List<Vehiculo> vehiculos_rentados = new List<Vehiculo>();

    public Cliente(int id, string nombre, float presupuesto)
    {
        this.id = id;
        this.nombre = nombre;
        this.presupuesto = presupuesto;
    }

    public void Rentar(Vehiculo vehiculo)
    {
        if (!vehiculo.Disponible)
        {
            Console.WriteLine("El vehiculo no está disponible.");
        }
        else if (this.presupuesto < vehiculo.CostoRenta)
        {
            Console.WriteLine($"No tiene suficiente presupuesto, minimo: {vehiculo.CostoRenta}.");
        }
        else
        {
            this.presupuesto -= vehiculo.CostoRenta;
            vehiculo.MarcarRentado();
            vehiculos_rentados.Add(vehiculo);
            Console.WriteLine("Vehiculo rentado con exito.");
        }
    }

    public void Devolver(Vehiculo vehiculo)
    {
        if (!vehiculos_rentados.Contains(vehiculo))
        {
        Console.WriteLine("Este vehículo no está rentado por este cliente.");
        }
        else
        {
            vehiculo.MarcarDevuelto();
            vehiculos_rentados.Remove(vehiculo);
            Console.WriteLine("Vehículo devuelto con éxito.");
        }
    }
}