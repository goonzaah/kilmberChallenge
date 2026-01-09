using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    internal class Cuadrado : IForma
    {
        public int Tipo => FormaGeometrica.Cuadrado;
        private readonly decimal _lado;
        public Cuadrado(decimal lado) { _lado = lado; }
        public decimal CalcularArea() => _lado * _lado;
        public decimal CalcularPerimetro() => _lado * 4;
    }
}
