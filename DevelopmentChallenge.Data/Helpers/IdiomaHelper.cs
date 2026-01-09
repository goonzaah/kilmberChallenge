using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;

namespace DevelopmentChallenge.Data.Helpers
{
    public static class IdiomaHelper
    {
        public const int Castellano = FormaGeometrica.Castellano;
        public const int Ingles = FormaGeometrica.Ingles;
        public const int Italiano = FormaGeometrica.Italiano;

        // Map shape type to translation key base
        private static readonly IReadOnlyDictionary<int, string> ShapeKey = new Dictionary<int, string>
        {
            { FormaGeometrica.Cuadrado, "Shape.Cuadrado" },
            { FormaGeometrica.Circulo, "Shape.Circulo" },
            { FormaGeometrica.TrianguloEquilatero, "Shape.TrianguloEquilatero" },
            { FormaGeometrica.Rectangulo, "Shape.Rectangulo" },
            { FormaGeometrica.Trapecio, "Shape.Trapecio" }
        };

        // language -> (key -> value)
        private static readonly IReadOnlyDictionary<int, Dictionary<string, string>> Translations =
            new Dictionary<int, Dictionary<string, string>>
        {
            [Castellano] = new Dictionary<string, string>
            {
                ["Header"] = "<h1>Reporte de Formas</h1>",
                ["EmptyList"] = "<h1>Lista vacía de formas!</h1>",
                ["Perimeter"] = "Perimetro",
                ["Shapes"] = "formas",
                ["Shape.Cuadrado.Singular"] = "Cuadrado",
                ["Shape.Cuadrado.Plural"] = "Cuadrados",
                ["Shape.Circulo.Singular"] = "Círculo",
                ["Shape.Circulo.Plural"] = "Círculos",
                ["Shape.TrianguloEquilatero.Singular"] = "Triángulo",
                ["Shape.TrianguloEquilatero.Plural"] = "Triángulos",
                ["Shape.Rectangulo.Singular"] = "Rectángulo",
                ["Shape.Rectangulo.Plural"] = "Rectángulos",
                ["Shape.Trapecio.Singular"] = "Trapecio",
                ["Shape.Trapecio.Plural"] = "Trapecios"
            },
            [Ingles] = new Dictionary<string, string>
            {
                ["Header"] = "<h1>Shapes report</h1>",
                ["EmptyList"] = "<h1>Empty list of shapes!</h1>",
                ["Perimeter"] = "Perimeter",
                ["Shapes"] = "shapes",
                ["Shape.Cuadrado.Singular"] = "Square",
                ["Shape.Cuadrado.Plural"] = "Squares",
                ["Shape.Circulo.Singular"] = "Circle",
                ["Shape.Circulo.Plural"] = "Circles",
                ["Shape.TrianguloEquilatero.Singular"] = "Triangle",
                ["Shape.TrianguloEquilatero.Plural"] = "Triangles",
                ["Shape.Rectangulo.Singular"] = "Rectangle",
                ["Shape.Rectangulo.Plural"] = "Rectangles",
                ["Shape.Trapecio.Singular"] = "Trapeze",
                ["Shape.Trapecio.Plural"] = "Trapezes"
            },
            [Italiano] = new Dictionary<string, string>
            {
                ["Header"] = "<h1>Rapporto delle Forme</h1>",
                ["EmptyList"] = "<h1>Elenco vuoto di forme!</h1>",
                ["Perimeter"] = "Perimetro",
                ["Shapes"] = "forme",
                ["Shape.Cuadrado.Singular"] = "Quadrato",
                ["Shape.Cuadrado.Plural"] = "Quadrati",
                ["Shape.Circulo.Singular"] = "Cerchio",
                ["Shape.Circulo.Plural"] = "Cerchi",
                ["Shape.TrianguloEquilatero.Singular"] = "Triangolo",
                ["Shape.TrianguloEquilatero.Plural"] = "Triangoli",
                ["Shape.Rectangulo.Singular"] = "Rettangolo",
                ["Shape.Rectangulo.Plural"] = "Rettangoli",
                ["Shape.Trapecio.Singular"] = "Trapezio",
                ["Shape.Trapecio.Plural"] = "Trapezi"
            }
        };

        private const int DefaultLanguage = Ingles;

        private static string GetTranslation(int idioma, string key)
        {
            if (!Translations.TryGetValue(idioma, out var map))
                map = Translations[DefaultLanguage];

            if (map.TryGetValue(key, out var value)) return value;

            // fallback to default language
            if (Translations[DefaultLanguage].TryGetValue(key, out value)) return value;

            return string.Empty;
        }

        public static string MensajeListaVacia(int idioma) => GetTranslation(idioma, "EmptyList");

        public static string Encabezado(int idioma) => GetTranslation(idioma, "Header");

        public static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            if (!ShapeKey.TryGetValue(tipo, out var baseKey)) return string.Empty;

            var key = baseKey + (cantidad == 1 ? ".Singular" : ".Plural");
            return GetTranslation(idioma, key);
        }

        public static string EtiquetaPerimetro(int idioma) => GetTranslation(idioma, "Perimeter");

        public static string PalabraFormas(int idioma) => GetTranslation(idioma, "Shapes");
    }
}
