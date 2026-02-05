public class Moto : Vehiculo
{
    public bool Sidecar { get; set; }
    public override float Precio => Sidecar ? (int)Marca * 1000 + (Km * 10) + 500 : (int)Marca * 1000 + (Km * 10);

    public Moto(string id, string marca, string modelo, int km) : base(id, marca, modelo, km)
    {
        Sidecar = false;
    }

    public Moto(Moto c) : base(c.ID, c.MarcaVehiculo, c.Modelo, c.Km)
    {
        Sidecar = false;
    }

    public override string ToString() => base.ToString() + $" | Airbag: {Sidecar}";

}