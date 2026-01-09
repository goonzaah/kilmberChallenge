using System;

namespace DevelopmentChallenge.Data.Classes.Formas
{
    internal class Trapecio : IForma
    {
        public int Tipo => FormaGeometrica.Trapecio;
        private readonly decimal _baseMayor;
        private readonly decimal _baseMenor;
        private readonly decimal _altura;
        public Trapecio(decimal baseMayor, decimal baseMenor, decimal altura)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
        }

        public decimal CalcularArea() => ((_baseMayor + _baseMenor) / 2) * _altura;

        public decimal CalcularPerimetro()
        {
            // asumimos trapecio isósceles para calcular lados iguales
            var mitadDif = Math.Abs((double)((_baseMayor - _baseMenor) / 2));
            var lado = (decimal)Math.Sqrt(mitadDif * mitadDif + (double)(_altura * _altura));
            return _baseMayor + _baseMenor + 2 * lado;
        }
    }
}
