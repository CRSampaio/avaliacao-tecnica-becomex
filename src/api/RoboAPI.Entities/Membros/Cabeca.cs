namespace RoboAPI.Entities;

public class Cabeca : EntidadeBase
{
    public Cabeca(EstadoInclinacao estadoInclinacao, EstadoRotacao estadoRotacao)
    {
        EstadoInclinacao = estadoInclinacao;
        EstadoRotacao = estadoRotacao;
    }

    public EstadoInclinacao EstadoInclinacao { get; set; }

    public EstadoRotacao EstadoRotacao { get; set; }
}