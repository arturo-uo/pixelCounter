using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Drawing.Imaging;
using Texel.Core.Model;

namespace Texel.Core.Helpers
{
    public class Image
    {
        public static IEnumerable<TexelColor> Procesar(string ruta)
        {
            List<TexelColor> colores = new List<TexelColor>();
            if (!string.IsNullOrEmpty(ruta))
            {
                Bitmap myBitmap = new Bitmap(ruta);
                for (int i = 0; i < myBitmap.Width; i++)
                {
                    for (int j = 0; j < myBitmap.Height; j++)
                    {
                        var color = myBitmap.GetPixel(i, j);
                        TexelColor entidad = new TexelColor() { Nombre = $"#{color.Name.Substring(2, 6)}" };
                        var existe = (from c in colores where c.Nombre == entidad.Nombre select c).FirstOrDefault();
                        if (existe != null)
                        {
                            existe.Cantidad += 1;
                        }
                        else
                        {
                            colores.Add(entidad);
                        }
                    }
                }
                colores = colores.OrderByDescending(c => c.Cantidad).Take(100).ToList();
                int totalPixels = myBitmap.Height * myBitmap.Width;
                for (int i = 0; i < colores.Count - 1; i++)
                {
                    colores[i].Porcentaje = (100m / totalPixels) * colores[i].Cantidad;
                }
            }
            return colores;
        }
    }
}
