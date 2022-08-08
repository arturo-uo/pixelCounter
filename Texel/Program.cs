using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Texel.Core;

namespace Texel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Image path:");
            string path = Console.ReadLine();
            //Obtenemos la ruta de la imagen
            if (!string.IsNullOrEmpty(path))
            {
                //Verificamos que existe la imagen
                if (System.IO.File.Exists(path))
                {
                    StringBuilder filas = new StringBuilder();
                    var colores = Texel.Core.Helpers.Image.Procesar(path);
                    string fileName = path.Split("\\").Last();
                    foreach (var c in colores)
                    {
                        filas.Append($"<tr><td style='background-color:{c.Nombre}'>{c.Nombre}</td><td>{c.Cantidad}</td><td>{c.Porcentaje}</td></tr>");
                    }
                    var img = $"<img src='{fileName}'/><br>";
                    filas.Append($"<tr><td colspan='3' style='text-align:center'>{img}</td></tr>");
                    Texel.Core.Helpers.Template.Guardar(path, "result_1.html", "FILAS", filas.ToString());
                    Console.WriteLine("Done!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("It doesn't exists file");
                }
            }
            else
            {
                Console.WriteLine("Invalid path:");
            }
        }
    }
}
