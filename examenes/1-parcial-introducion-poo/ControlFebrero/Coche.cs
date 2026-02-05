public class Coche : Vehiculo
{
    public bool Airbag { get; set; }
    public override float Precio => Marca == Marcas.Desconocida ? 0 : Airbag ? (int)Marca * 1000 + (Km * 10) + 200 : ((int)Marca * 1000 + (Km * 10));

    public Coche(string id, string marca, string modelo, int km) : base(id, marca, modelo, km)
    {
        Airbag = false;
    }

    public Coche(Coche c) : base(c) /* FIXME: base(c.ID, c.MarcaVehiculo, c.Modelo, c.Km) */
    {
        Airbag = c.Airbag; /* FIXME: false; */
    }

    public override string ToString() => base.ToString() + $" | Airbag: {Airbag}";
}
