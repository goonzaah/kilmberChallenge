using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    internal class Circulo : IForma
    {
        public int Tipo => FormaGeometrica.Circulo;
        private readonly decimal _diametro;
        public Circulo(decimal diametro) { _diametro = diametro; }
        public decimal CalcularArea() => (decimal)Math.PI * (_diametro / 2) * (_diametro / 2);
        public decimal CalcularPerimetro() => (decimal)Math.PI * _diametro;
    }
}
