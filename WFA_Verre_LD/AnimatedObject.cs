using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WFA_Verre_LD
{
    /// <summary>
    /// Classe créant des objet animé, allant d'un point start à un point end avec une taille et une vitesse donnée
    /// Code venant directement de l'exercice "WFRain" avec quelque changement mineur comme la taille et la couleur
    /// </summary>
    class AnimatedObject
    {
        PointF location;
        PointF initialLocation;
        PointF start;
        PointF end;

        Stopwatch sw;

        Size size;


        double d;
        double td;
        float verticalSpeed;
        float horizontalSpeed;

        /// <summary>
        /// Rain drop is an animated graphical object that starts from screen top (y = 0) 
        /// and move down at speed (pixels / seconds).
        /// </summary>
        /// <param name="x"></param>
        /// <param name="speed"></param>
        public AnimatedObject(PointF start, PointF end, Size size, float speed)
        {
            this.start = start;
            this.end = end;
            initialLocation = start;
            location = start;
            verticalSpeed = speed;
            this.size = size;
            sw = new Stopwatch();
            sw.Start();

            d = Math.Sqrt(Math.Pow(end.X - start.X, 2) + Math.Pow(end.Y - start.Y, 2));
            td = d / speed;
            horizontalSpeed = (float)((end.X - start.X) / td);
            verticalSpeed = (float)((end.Y - start.Y) / td);
        }

        public PointF Location
        {
            get
            {
                return new PointF(initialLocation.X + horizontalSpeed * (float)(sw.ElapsedMilliseconds / 1000.0f),
                                  initialLocation.Y + verticalSpeed * (float)(sw.ElapsedMilliseconds / 1000.0f));
            }
        }


        public bool Stopped
        {
            get { return ((sw.ElapsedMilliseconds / 1000.0) >= td); }
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            if (!Stopped)
                location = new PointF(  initialLocation.X + horizontalSpeed * (float)(sw.ElapsedMilliseconds / 1000.0f),
                                        initialLocation.Y + verticalSpeed * (float)(sw.ElapsedMilliseconds / 1000.0f));

            // Rectangle dans lequel sera dessiné la bulle
            Rectangle recDessin = new Rectangle(Point.Round(location), size);

            e.Graphics.FillRectangle(Brushes.White, recDessin);
            e.Graphics.DrawRectangle(Pens.DimGray, recDessin);
        }
    }
}
