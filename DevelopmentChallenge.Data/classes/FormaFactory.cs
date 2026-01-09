using System;
using DevelopmentChallenge.Data.Classes.Formas;

namespace DevelopmentChallenge.Data.Classes
{
    internal static class FormaFactory
    {
        public static IForma Create(int tipo, decimal ancho)
        {
            switch (tipo)
            {
                case FormaGeometrica.Cuadrado:
                    return new Cuadrado(ancho);
                case FormaGeometrica.Circulo:
                    return new Circulo(ancho);
                case FormaGeometrica.TrianguloEquilatero:
                    return new TrianguloEquilatero(ancho);
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipo), "Forma desconocida");
            }
        }

        public static IForma Create(int tipo, decimal ancho, decimal alto)
        {
            if (tipo != FormaGeometrica.Rectangulo)
                throw new ArgumentException("Constructor inválido para este tipo de forma", nameof(tipo));

            return new Rectangulo(ancho, alto);
        }

        public static IForma Create(int tipo, decimal baseMayor, decimal baseMenor, decimal altura)
        {
            if (tipo != FormaGeometrica.Trapecio)
                throw new ArgumentException("Constructor inválido para este tipo de forma", nameof(tipo));

            return new Trapecio(baseMayor, baseMenor, altura);
        }
    }
}
