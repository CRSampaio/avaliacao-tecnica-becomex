namespace RoboAPI.Entities;

public class Cotovelo : EntidadeBase
{
    public Cotovelo(EstadoCotovelo estadoCotovelo)
    {
        EstadoCotovelo = estadoCotovelo;
    }

    public EstadoCotovelo EstadoCotovelo { get; set; }
}