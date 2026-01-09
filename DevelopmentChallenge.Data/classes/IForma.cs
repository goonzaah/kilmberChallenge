using System;

namespace DevelopmentChallenge.Data.Classes
{
    internal interface IForma
    {
        int Tipo { get; }
        decimal CalcularArea();
        decimal CalcularPerimetro();
    }
}
