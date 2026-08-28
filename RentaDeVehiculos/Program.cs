// Clase Vehiculo

abstract class Vehiculo
{
    protected string color;
    protected int id;
    protected bool disponible = true;
    protected int velocidad_max;
    protected int capacidad_pasajeros;
    protected float costo_renta;
    protected bool encendido = false;

    public Vehiculo(string color, int id, int velocidad_max,
                int capacidad_pasajeros, float costo_renta)
    {
    this.color = color;
    this.id = id;
    this.velocidad_max = velocidad_max;
    this.capacidad_pasajeros = capacidad_pasajeros;
    this.costo_renta = costo_renta;
    }

    protected void encender()
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

    protected void apagar()
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

    protected void pintar(string new_color)
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

    // Mostrar informacion del vehiculo
    public virtual void MostrarInformacion()
    {
    Console.WriteLine($"ID: {id}");
    Console.WriteLine($"Color: {color}");
    Console.WriteLine($"Velocidad máxima: {velocidad_max} km/h");
    Console.WriteLine($"Capacidad de pasajeros: {capacidad_pasajeros}");
    Console.WriteLine($"Costo de renta: {costo_renta}");
    Console.WriteLine($"Disponible: {(disponible ? "Sí" : "No")}");
    Console.WriteLine($"Encendido: {(encendido ? "Sí" : "No")}");
    }
}

// Clases de todos los tipos de vehiculos

// Terrestre
abstract class VehiculoTerrestre : Vehiculo
{
    protected int num_llantas;

    public VehiculoTerrestre(string color, int id, int velocidad_max,
    int capacidad_pasajeros, float costo_renta, int num_llantas):
    base(color, id, velocidad_max, capacidad_pasajeros, costo_renta)
    {
        this.num_llantas = num_llantas;
    }

    protected virtual void acelerar()
    {
        Console.WriteLine("Acelerando...");
    }

    protected virtual void frenar()
    {
        Console.WriteLine("Frenando...");
    }

    protected virtual void abrir_maletero()
    {
        Console.WriteLine("Abriendo maletero...");
    }
}
// Fin terrestre

// Aereo
abstract class VehiculoAereo : Vehiculo
{
    protected int num_motores;
    protected int altura_max_aprox;
    protected bool tiene_piloto_automatico;

    public VehiculoAereo(string color, int id, int velocidad_max,
    int capacidad_pasajeros, float costo_renta, int num_motores, 
    int altura_max_aprox, bool tiene_piloto_automatico):
    base(color, id, velocidad_max, capacidad_pasajeros, costo_renta)
    {
        this.altura_max_aprox = altura_max_aprox;
        this.num_motores = num_motores;
        this.tiene_piloto_automatico = tiene_piloto_automatico;
    }

    protected void ascender()
    {
        Console.WriteLine("Ascendiendo...");
    }

    protected void descender()
    {
        Console.WriteLine("Descendiendo...");
    }

    protected void activar_piloto_automatico()
    {
        if (this.tiene_piloto_automatico)
        {
            Console.WriteLine("Piloto automatico activo.");
        }
        else
        {
            Console.WriteLine("No tiene piloto automatico.");
        }
    }
}
// Fin aereo


// Subclases vehiculos terrestres
class Coche : VehiculoTerrestre
{
    protected int num_puertas;
    protected bool tiene_aire_acondicionado;

    public Coche(string color, int id, int velocidad_max,
    int capacidad_pasajeros, float costo_renta, int num_llantas,
    int num_puertas, bool tiene_aire_acondicionado):
    base(color, id, velocidad_max, capacidad_pasajeros, costo_renta, num_llantas)
    {
        this.tiene_aire_acondicionado = tiene_aire_acondicionado;
        this.num_puertas = num_puertas;
    }

    protected override void acelerar()
    {
        Console.WriteLine("Metiendo pedal de gas...");
    }

    protected override void frenar()
    {
        Console.WriteLine("Metiendo pedal de frenar...");
    }

    // Mostrar informacion del coche
    public override void MostrarInformacion()
    {
    base.MostrarInformacion();
    Console.WriteLine($"Número de llantas: {num_llantas}");
    Console.WriteLine($"Número de puertas: {num_puertas}");
    Console.WriteLine($"¿Aire acondicionado?: {(tiene_aire_acondicionado ? "Sí" : "No")}");
    }
}

class Moto : VehiculoTerrestre
{
    protected bool tiene_maletero;

    public Moto(string color, int id, int velocidad_max,
    int capacidad_pasajeros, float costo_renta, int num_llantas,
    bool tiene_maletero):
    base(color, id, velocidad_max, capacidad_pasajeros, costo_renta, num_llantas)
    {
        this.tiene_maletero = tiene_maletero;
    }

    protected override void acelerar()
    {
        Console.WriteLine("Girando el gas...");
    }

    protected override void frenar()
    {
        Console.WriteLine("Accionando palanca de frenos...");
    }

    protected override void abrir_maletero()
    {
        if (this.tiene_maletero) {Console.WriteLine("Abriendo maletero...");} else {Console.WriteLine("No tiene maletero.");}
    }

    // Mostrar informacion de la moto
    public override void MostrarInformacion()
    {
    base.MostrarInformacion();
    Console.WriteLine($"Número de llantas: {num_llantas}");
    Console.WriteLine($"¿Maletero?: {(tiene_maletero ? "Sí" : "No")}");
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

    // Mostrar informacion del helicoptero
    public override void MostrarInformacion()
    {
    base.MostrarInformacion();
    Console.WriteLine($"Altura máxima: {altura_max_aprox}");
    Console.WriteLine($"Número de motores: {num_motores}");
    Console.WriteLine($"¿Piloto automático?: {(tiene_piloto_automatico ? "Sí" : "No")}");
    }
}

class Avion : VehiculoAereo
{
    public Avion(string color, int id, int velocidad_max,
    int capacidad_pasajeros, float costo_renta, int num_motores, 
    int altura_max_aprox, bool tiene_piloto_automatico):
    base(color, id, velocidad_max, capacidad_pasajeros, costo_renta,
    num_motores, altura_max_aprox, tiene_piloto_automatico) {}

    // Mostrar informacion del helicoptero
    public override void MostrarInformacion()
    {
    base.MostrarInformacion();
    Console.WriteLine($"Altura máxima: {altura_max_aprox}");
    Console.WriteLine($"Número de motores: {num_motores}");
    Console.WriteLine($"¿Piloto automático?: {(tiene_piloto_automatico ? "Sí" : "No")}");
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

    // Mostrar info del cliente
    public void MostrarInformacionCliente()
    {
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"Nombre: {nombre}");
        Console.WriteLine($"Presupuesto del cliente: ${presupuesto}");

        if (vehiculos_rentados.Count > 0)
        {
            Console.WriteLine("Vehículos rentados:");

            foreach (Vehiculo vehiculo in vehiculos_rentados)
            {
                Console.WriteLine("--------------------------");
                vehiculo.MostrarInformacion();
            }
        }
        else
        {
            Console.WriteLine("Sin vehículos rentados.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // ==========================================
        // CREACIÓN DE VEHÍCULOS
        // ==========================================

        Coche coche = new Coche(
            "Rojo",
            1,
            200,
            5,
            15000,
            4,
            4,
            true
        );

        Moto moto = new Moto(
            "Negro",
            2,
            180,
            2,
            8000,
            2,
            true
        );

        Helicoptero helicoptero = new Helicoptero(
            "Blanco",
            3,
            250,
            6,
            30000,
            2,
            5000,
            true
        );

        Avion avion = new Avion(
            "Azul",
            4,
            900,
            200,
            65000,
            4,
            12000,
            true
        );


        // ==========================================
        // CASO 1: MOSTRAR INFORMACIÓN DE VEHÍCULOS
        // ==========================================

        Console.WriteLine("==========================================");
        Console.WriteLine("CASO 1: INFORMACIÓN DE VEHÍCULOS");
        Console.WriteLine("==========================================");

        coche.MostrarInformacion();

        Console.WriteLine("--------------------------");

        moto.MostrarInformacion();

        Console.WriteLine("--------------------------");

        helicoptero.MostrarInformacion();

        Console.WriteLine("--------------------------");

        avion.MostrarInformacion();


        // ==========================================
        // CASO 2: CREAR CLIENTE
        // ==========================================

        Console.WriteLine("\n==========================================");
        Console.WriteLine("CASO 2: INFORMACIÓN DEL CLIENTE");
        Console.WriteLine("==========================================");

        Cliente cliente = new Cliente(
            100,
            "Mateo",
            60000
        );

        cliente.MostrarInformacionCliente();


        // ==========================================
        // CASO 3: RENTAR UN VEHÍCULO
        // ==========================================

        Console.WriteLine("\n==========================================");
        Console.WriteLine("CASO 3: RENTAR COCHE");
        Console.WriteLine("==========================================");

        cliente.Rentar(coche);

        cliente.MostrarInformacionCliente();


        // ==========================================
        // CASO 4: INTENTAR RENTAR EL MISMO VEHÍCULO
        // ==========================================

        Console.WriteLine("\n==========================================");
        Console.WriteLine("CASO 4: RENTAR COCHE NO DISPONIBLE");
        Console.WriteLine("==========================================");

        cliente.Rentar(coche);


        // ==========================================
        // CASO 5: RENTAR OTROS VEHÍCULOS
        // ==========================================

        Console.WriteLine("\n==========================================");
        Console.WriteLine("CASO 5: RENTAR MOTO Y HELICÓPTERO");
        Console.WriteLine("==========================================");

        cliente.Rentar(moto);
        cliente.Rentar(helicoptero);

        cliente.MostrarInformacionCliente();


        // ==========================================
        // CASO 6: INTENTAR RENTAR VEHÍCULO MUY CARO
        // ==========================================

        Console.WriteLine("\n==========================================");
        Console.WriteLine("CASO 6: PRESUPUESTO INSUFICIENTE");
        Console.WriteLine("==========================================");

        cliente.Rentar(avion);


        // ==========================================
        // CASO 7: DEVOLVER UN VEHÍCULO
        // ==========================================

        Console.WriteLine("\n==========================================");
        Console.WriteLine("CASO 7: DEVOLVER COCHE");
        Console.WriteLine("==========================================");

        cliente.Devolver(coche);

        cliente.MostrarInformacionCliente();


        // ==========================================
        // CASO 8: INTENTAR DEVOLVER VEHÍCULO
        // QUE NO TIENE EL CLIENTE
        // ==========================================

        Console.WriteLine("\n==========================================");
        Console.WriteLine("CASO 8: DEVOLVER VEHÍCULO NO RENTADO");
        Console.WriteLine("==========================================");

        cliente.Devolver(avion);


        // ==========================================
        // CASO 9: RENTAR NUEVAMENTE EL COCHE
        // DESPUÉS DE DEVOLVERLO
        // ==========================================

        Console.WriteLine("\n==========================================");
        Console.WriteLine("CASO 9: VOLVER A RENTAR EL COCHE");
        Console.WriteLine("==========================================");

        cliente.Rentar(coche);

        cliente.MostrarInformacionCliente();


        // ==========================================
        // FINAL
        // ==========================================

        Console.WriteLine("\n==========================================");
        Console.WriteLine("FIN DE LOS CASOS DE PRUEBA");
        Console.WriteLine("==========================================");
    }
}