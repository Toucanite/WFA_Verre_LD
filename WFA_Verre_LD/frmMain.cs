/*
 * Auteur : Lucas Donati
 * Date : 7 mars 2017
 * Description : épreuve c# orienté objet, faire des verre contenant des bulles 
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WFA_Verre_LD
{
    public partial class frmMain : Form
    {
        Verre monVerre = new Verre(new Point(500,50), new Size(600, 800));
        Verre autreVerre = new Verre();
        Random rnd = new Random();
        List<AnimatedObject> bulles = new List<AnimatedObject>();

        public frmMain()
        {
            DoubleBuffered = true; // Permet à l'affichage d'être plus fluide, pas de saccade
            InitializeComponent();
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            // Dessine le verre, et les bulles à l'intérieur
            // Pour un verre sans bulle il est possible d'utiliser le paramètre booléen "AfficheBulles"
            // ou encore d'initialiser le verre avec le champs optionel "afficheBulle" à la valeur false
            monVerre.Paint(sender, e);
            autreVerre.Paint(sender, e);
        }

        private void tmrInvalidate_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
