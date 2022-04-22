using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        public IActionResult GraficoBarra()
        {
            return View();
        }

        // public string graficoBarras()
        // {
        // }
        public string graficoInicial()
        {
            Bitmap oBitmap = new Bitmap(800, 400);
            Graphics grafico = Graphics.FromImage(oBitmap);
            Rectangle rec;
            using (MemoryStream ms = new MemoryStream())
            {
                rec = new Rectangle(0, 50, 800, 350);
                LinearGradientBrush gradiente =
                    new LinearGradientBrush(rec,
                        Color.Tomato,
                        Color.Teal,
                        LinearGradientMode.BackwardDiagonal);

                grafico.FillRectangle (gradiente, rec);
                rec = new Rectangle(0, 0, 800, 50);
                grafico.FillRectangle(Brushes.White, rec);

                rec = new Rectangle(100, 100, 100, 50);
                grafico.FillRectangle(Brushes.White, rec);

                rec = new Rectangle(600, 100, 100, 50);
                grafico.FillRectangle(Brushes.White, rec);

                rec = new Rectangle(300, 200, 200, 50);
                grafico.FillRectangle(Brushes.White, rec);

                rec = new Rectangle(100, 300, 600, 50);
                grafico.FillRectangle(Brushes.White, rec);

                StringFormat formato =
                    new StringFormat(StringFormatFlags.NoClip);

                formato.Alignment = StringAlignment.Center;

                grafico
                    .DrawString("Mi primer gráfico",
                    new Font("Arial", 14),
                    Brushes.Black,
                    new Point(400, 0),
                    formato);

                oBitmap.Save(ms, ImageFormat.Png);
                byte[] data = ms.ToArray();
                return Convert.ToBase64String(data);
            }
        }
    }
}
