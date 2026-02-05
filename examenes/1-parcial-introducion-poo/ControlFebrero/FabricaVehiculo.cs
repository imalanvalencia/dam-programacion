public class FabricaVehiculo
{
    public List<Vehiculo> Vehiculos { get; }


    public FabricaVehiculo()
    {
        Vehiculos = [];
    }

    public void AnyadeVehiculo(Vehiculo v) => Vehiculos.Add(v);
    public void AnyadeVehiculo(Vehiculo v, bool extra)
    {
        if (v is Coche vc) vc.Airbag = extra;
        if (v is Moto vm) vm.Sidecar = extra;

        /*FIXME: se añade el vehiculo */
        Vehiculos.Add(v);
    }

    public override string ToString() => $"""
    Vehiculos en la fabrica
    {(Vehiculos.Count == 0 ?
    "No hay vehiculos" :
    /* FIXME:Vehiculos.ConvertAll(v => $"\n{v}")  */
    string.Join("\n", Vehiculos.Select(v => $"\n{v}"))
    )}
    """;

}
