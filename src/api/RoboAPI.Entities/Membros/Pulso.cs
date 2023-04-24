namespace RoboAPI.Entities;

public class Pulso : EntidadeBase
{
    public Pulso(EstadoPulso estadoPulso)
    {
        EstadoPulso = estadoPulso;
    }

    public EstadoPulso EstadoPulso { get; set; }
}