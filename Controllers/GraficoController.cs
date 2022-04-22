using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CursoGraficos.Controllers
{
    public class GraficoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string graficoInicial()
        {
            Bitmap oBitmap = new Bitmap(800, 400);
            Graphics grafico = Graphics.FromImage(oBitmap);
            Rectangle rec;
            using (MemoryStream ms = new MemoryStream())
            {
                rec = new Rectangle(0, 0, 800, 400);
                grafico.FillRectangle(Brushes.CornflowerBlue, rec);
                rec = new Rectangle(100, 100, 100, 50);
                grafico.FillRectangle(Brushes.White, rec);
                oBitmap.Save(ms, ImageFormat.Png);
                byte[] data = ms.ToArray();
                return Convert.ToBase64String(data);
            }
        }
    }
}
