using System.Text.RegularExpressions;

public enum Marcas
{
    Desconocida,
    BMW = 50,
    Suzuki = 35,
    Onda = 27,
    Peugeot = 20,
    Invicta = 15,
    Seat = 25
}

public abstract class Vehiculo
{
    public string ID { get; }
    protected Marcas Marca { get; private set; }

    private string _modelo;
    public string Modelo { get => _modelo.ToUpper(); private set => _modelo = value; }
    public string MarcaVehiculo
    {
        get => Marca.ToString(); 
        private set
        {
            if (Enum.TryParse(value, true, out Marcas marquinha)) Marca = marquinha;
            else Marca = Marcas.Desconocida;
        }
    }

    public int Km { get; private set; }
    public abstract float Precio { get; }

    public string CompruebaID(string id)
    {

        string patronMarca = @$"{Marca.ToString().ToUpper(),3}{Modelo.ToString().ToUpper(),3}\d\d"; /* FIXME: el ",3" no toma los tres primeros lo que hace es identarlo en salido (consola)*/

        if (Regex.IsMatch(id, patronMarca)) return id;

        else
        {
            Random aleatorio = new();
            return $"{Marca.ToString().ToUpper(),3}{Modelo.ToString().ToUpper(),3}{aleatorio.Next(10)}{aleatorio.Next(10)}";
        }
    }

    public Vehiculo(string id, string marca, string modelo, int km)
    {
        ID = CompruebaID(id);
        MarcaVehiculo = marca;
        _modelo = modelo; /* FIXME: esto no se puede hacer (se resuelve arriba) modelo.ToUpper();  */
        Km = km;
        /*  
        FIXME: (arriba esta)
        Marcas marquinha;
        if (Enum.TryParse(MarcaVehiculo, true, out marquinha)) Marca = marquinha; 
        */
    }

    public Vehiculo(Vehiculo c)
    {
        ID = c.ID;
        MarcaVehiculo = c.MarcaVehiculo;
        _modelo = c._modelo;
        Km = c.Km;
    }

    public override string ToString() => $"{ID} | {Marca} - {Modelo} | Km: {Km} | Precio: {Precio}€";
}