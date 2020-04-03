using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace Task1
{

    class Parametri
    {
        public Parametri(double gscR, double gscG, double gscB, double gmR, double gmG, double gmB)
        {
            //Parametri za Grayscale
            GrayscaleRed = gscR;
            GrayscaleGreen = gscG;
            GrayscaleBlue = gscB;

            //Parametri za Gamma
            GammaRed = gmR;
            GammaGreen = gmG;
            GammaBlue = gmB;
        }

        public double GrayscaleRed { get; set; }
        public double GrayscaleGreen { get; set; }
        public double GrayscaleBlue { get; set; }
        public double GammaRed { get; set; }
        public double GammaGreen { get; set; }
        public double GammaBlue { get; set; }
    }

    class Obrada
    {
        public Obrada()
        {

        }

        public static Bitmap GrayscaleAndGammma(System.Drawing.Bitmap b, Parametri par)
        {
            byte[] CreateGammaArray(double color)
            {
                byte[] gammaArray = new byte[256];
                for (int i = 0; i < 256; ++i)
                {
                    gammaArray[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / color)) + 0.5));
                }
                return gammaArray;
            }

            Color cGamma;
            byte[] redGamma = CreateGammaArray(par.GammaRed);
            byte[] greenGamma = CreateGammaArray(par.GammaGreen);
            byte[] blueGamma = CreateGammaArray(par.GammaBlue);

            //Grayscale
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    //Grayscale
                    Color c1 = b.GetPixel(i, j);
                    int r1 = c1.R;
                    int g1 = c1.G;
                    int b1 = c1.B;
                    int gray = (byte)(par.GrayscaleRed * r1 + par.GrayscaleGreen * g1 + par.GrayscaleBlue * b1);
                    r1 = gray;
                    g1 = gray;
                    b1 = gray;
                    b.SetPixel(i, j, Color.FromArgb(r1, g1, b1));

                    //Gamma
                    cGamma = b.GetPixel(i, j);
                    b.SetPixel(i, j, Color.FromArgb(redGamma[cGamma.R],
                    greenGamma[cGamma.G], blueGamma[cGamma.B]));
                }
            }

            return b;

        }
    }
}
