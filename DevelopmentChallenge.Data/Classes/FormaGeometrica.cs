/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevelopmentChallenge.Data.Helpers;

namespace DevelopmentChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;
        public const int Rectangulo = 5;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Italiano = 3;

        #endregion

        private readonly IForma _forma;

        public int Tipo => _forma?.Tipo ?? 0;

        // Constructor histórico: ancho sirve como lado/diametro según tipo
        public FormaGeometrica(int tipo, decimal ancho)
        {
            _forma = FormaFactory.Create(tipo, ancho);
        }

        // Rectángulo: ancho, alto
        public FormaGeometrica(int tipo, decimal ancho, decimal alto)
        {
            _forma = FormaFactory.Create(tipo, ancho, alto);
        }

        // Trapecio: baseMayor, baseMenor, altura
        public FormaGeometrica(int tipo, decimal baseMayor, decimal baseMenor, decimal altura)
        {
            _forma = FormaFactory.Create(tipo, baseMayor, baseMenor, altura);
        }

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append(IdiomaHelper.MensajeListaVacia(idioma));
                return sb.ToString();
            }

            sb.Append(IdiomaHelper.Encabezado(idioma));

            // Agrupar por tipo usando diccionarios para evitar variables repetitivas
            var tiposOrden = new[] { Cuadrado, Circulo, TrianguloEquilatero, Rectangulo, Trapecio };

            var counts = tiposOrden.ToDictionary(t => t, t => 0);
            var areas = tiposOrden.ToDictionary(t => t, t => 0m);
            var perimeters = tiposOrden.ToDictionary(t => t, t => 0m);

            foreach (var f in formas)
            {
                if (!counts.ContainsKey(f.Tipo)) continue; // ignora tipos desconocidos

                counts[f.Tipo]++;
                areas[f.Tipo] += f.CalcularArea();
                perimeters[f.Tipo] += f.CalcularPerimetro();
            }

            foreach (var tipo in tiposOrden)
            {
                sb.Append(ObtenerLinea(counts[tipo], areas[tipo], perimeters[tipo], tipo, idioma));
            }

            // FOOTER
            var totalCount = counts.Values.Sum();
            var totalPerim = perimeters.Values.Sum();
            var totalArea = areas.Values.Sum();

            sb.Append("TOTAL:<br/>");
            sb.Append(totalCount + " " + IdiomaHelper.PalabraFormas(idioma) + " ");
            sb.Append(IdiomaHelper.EtiquetaPerimetro(idioma) + " " + Formatear(totalPerim) + " ");
            sb.Append("Area " + Formatear(totalArea));

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            if (cantidad <= 0) return string.Empty;

            string areaFormato = Formatear(area);
            string perimetroFormato = Formatear(perimetro);
            
            string perimLabel = IdiomaHelper.EtiquetaPerimetro(idioma).Trim();
            
            string nombre = IdiomaHelper.TraducirForma(tipo, cantidad, idioma);
            if (idioma == Castellano)
                return $"{cantidad} {nombre} | Area {areaFormato} | {perimLabel} {perimetroFormato} <br/>";

            return $"{cantidad} {nombre} | Area {areaFormato} | {perimLabel} {perimetroFormato} <br/>";
        }

        public decimal CalcularArea()
        {
            return _forma?.CalcularArea() ?? throw new ArgumentOutOfRangeException("Forma desconocida");
        }

        public decimal CalcularPerimetro()
        {
            return _forma?.CalcularPerimetro() ?? throw new ArgumentOutOfRangeException("Forma desconocida");
        }

        private static string Formatear(decimal valor)
        {
            return valor.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture).Replace('.', ',');
        }
    }
}
