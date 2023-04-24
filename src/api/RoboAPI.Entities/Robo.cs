namespace RoboAPI.Entities;

public class Robo : EntidadeBase
{
    internal Robo()
    {
    }

    public Robo(Braco bracoDireito, Braco bracoEsquerdo, Cabeca cabeca)
    {
        BracoDireito = bracoDireito;
        BracoEsquerdo = bracoEsquerdo;
        Cabeca = cabeca;
    }

    public Braco BracoDireito { get; set; } = null!;

    public Braco BracoEsquerdo { get; set; } = null!;

    public Cabeca Cabeca { get; set; } = null!;
}