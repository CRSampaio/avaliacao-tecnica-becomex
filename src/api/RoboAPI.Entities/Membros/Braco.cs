using RoboAPI.Entities.Membros.Estados;

namespace RoboAPI.Entities;

public class Braco : EntidadeBase
{
    internal Braco()
    {
    }

    public Braco(Cotovelo cotovelo, Pulso pulso)
    {
        Cotovelo = cotovelo;
        Pulso = pulso;
    }

    public Cotovelo Cotovelo { get; set; } = null!;

    public Pulso Pulso { get; set; } = null!;
}