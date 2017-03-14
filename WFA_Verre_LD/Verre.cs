using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WFA_Verre_LD
{
    class Verre
    {
        Point position;
        Size taille;

        List<AnimatedObject> bulles = new List<AnimatedObject>(100);
        bool afficheBulle;
        Random rnd = new Random();

        public Verre() : this(new Point(60,60), new Size(200,500))
        {

        }

        /// <summary>
        /// Construit un objet Verre
        /// </summary>
        /// <param name="position">Determine le point à partir du quel le Verre va être dessiné</param>
        /// <param name="taille">Determine la taille du verre</param>
        /// <param name="afficheBulle">Paramètre optionnel, fait apparaitre des bulles on non</param>
        public Verre(Point position, Size taille, bool afficheBulle = true)
        {
            this.position = position;
            this.taille = taille;
            this.afficheBulle = afficheBulle;
        }

        /// <summary>
        /// Construit un objet Verre
        /// </summary>
        /// <param name="posX">Determine la valeur x du point qui sert a dessiner le verre</param>
        /// <param name="posY">Determine la valeur y du point qui sert a dessiner le verre</param>
        /// <param name="width">Determine la largeur du verre</param>
        /// <param name="height">Determine la hauteur du verre</param>
        /// <param name="afficheBulle">Paramètre optionnel, fait apparaitre des bulles on non</param>
        public Verre(int posX, int posY, int width, int height, bool afficheBulle = true)
        {
            this.position = new Point(posX, posY);
            this.taille = new Size(width, height);
            this.afficheBulle = afficheBulle;
        }

        public Size Taille
        {
            get { return taille; }
        }

        public Point Position
        {
            get { return position; }
        }

        /// <summary>
        /// Paramètre Booléen
        /// Affiche ou pas les bulles dans le verre
        /// </summary>
        public bool AfficheBulles
        {
            get { return afficheBulle; }
            set { afficheBulle = value; }
        }

        
        public void Paint(object sender, PaintEventArgs e)
        {
            Rectangle Verre = new Rectangle(position, taille);

            e.Graphics.FillRectangle(Brushes.SkyBlue, Verre);
            e.Graphics.DrawRectangle(Pens.White, Verre);

            if (afficheBulle)
            {
                if (bulles.Count < 100)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        // Determine la taille de la bulle de facon aléatoire
                        int tailleBulle = rnd.Next(this.Taille.Width / 40, this.Taille.Width / 20);

                        // Determine l'axe sur lequel la bulle va monter à la surface
                        int x = rnd.Next(this.Position.X, this.Position.X + this.Taille.Width - tailleBulle);

                        // Determine le point de départ et le point d'arrivée de la bulle
                        PointF start = new PointF(x, this.Position.Y + this.Taille.Height - tailleBulle);
                        PointF end = new PointF(x, this.Position.Y);

                        // Ajoute un Objet animé -une bulle dans le cas présent- à la liste
                        bulles.Add(new AnimatedObject(start, end, new Size(tailleBulle, tailleBulle), (float)rnd.Next(100, 200)));
                    }
                    
                }
                bulles.RemoveAll(p => p.Stopped);

                foreach (AnimatedObject bulle in bulles)
                    bulle.Paint(sender, e); // Dessine les bulles
            }
        }
    }
}
