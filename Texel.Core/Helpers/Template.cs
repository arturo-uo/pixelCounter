using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Texel.Core.Helpers
{
    public class Template
    {
        public static void Guardar(string imagePath, string templateName, string oldText, string newText)
        {
            string templatesPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Templates");
            if (!Directory.Exists(templatesPath))
                Directory.CreateDirectory(templatesPath);
            string template = System.IO.File.ReadAllText(Path.Combine(templatesPath, templateName));
            template = template.Replace($"{oldText}", $"{newText}");
            string resultName = $"result_{DateTime.Now.Year}{string.Format("{0:00}", DateTime.Now.Month)}{string.Format("{0:00}", DateTime.Now.Day)}{string.Format("{0:00}", DateTime.Now.Hour)}{string.Format("{0:00}", DateTime.Now.Minute)}{string.Format("{0:00}", DateTime.Now.Second)}.html";
            string fileName = imagePath.Split("\\").Last();
            System.IO.File.WriteAllText(Path.Combine(imagePath.Remove(imagePath.IndexOf(fileName), fileName.Length), resultName), template);
        }

        
    }
}
