using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    internal class TrianguloEquilatero : IForma
    {
        public int Tipo => FormaGeometrica.TrianguloEquilatero;
        private readonly decimal _lado;
        public TrianguloEquilatero(decimal lado) { _lado = lado; }
        public decimal CalcularArea() => ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        public decimal CalcularPerimetro() => _lado * 3;
    }
}
