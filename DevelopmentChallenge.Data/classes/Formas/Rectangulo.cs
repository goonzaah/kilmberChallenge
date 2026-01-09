using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    internal class Rectangulo : IForma
    {
        public int Tipo => FormaGeometrica.Rectangulo;
        private readonly decimal _ancho;
        private readonly decimal _alto;
        public Rectangulo(decimal ancho, decimal alto) { _ancho = ancho; _alto = alto; }
        public decimal CalcularArea() => _ancho * _alto;
        public decimal CalcularPerimetro() => 2 * (_ancho + _alto);
    }
}
