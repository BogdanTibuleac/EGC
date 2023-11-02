using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tibuleac_bogdan_3131a_l3
{
    //8,9 - Handle the colors
    internal class ColorHandler
    {
        private const double COLOR_ADJUSTMENT_STEP = 0.05;

        public Color GenerateRandomColor()
        {
            Random random = new Random();
            return Color.FromArgb(255, random.Next(256), random.Next(256), random.Next(256));
        }
        public void SetTriangleToWhite(KeyboardState keyboard, ref Color color1, ref Color color2, ref Color color3)
        {
            if (keyboard[Key.Q])
            {
                color1 = Color.White;
                color2 = Color.White;
                color3 = Color.White;

                Console.WriteLine("Triangle colors set to white!");
            }
        }

        //Requirement 8 - for the right triangle to adjust the color according to ARGB system
        public void SetColor(KeyboardState keyboard, ref double alpha, ref double red, ref double green, ref double blue)
        {
            if (keyboard[Key.Up] && keyboard[Key.R] && red < 1)
            {
                red += COLOR_ADJUSTMENT_STEP;
            }
            else if (keyboard[Key.Down] && keyboard[Key.R] && red > 0)
            {
                red -= COLOR_ADJUSTMENT_STEP;
            }
            else if (keyboard[Key.Up] && keyboard[Key.B] && blue < 1)
            {
                blue += COLOR_ADJUSTMENT_STEP;
            }
            else if (keyboard[Key.Down] && keyboard[Key.B] && blue > 0)
            {
                blue -= COLOR_ADJUSTMENT_STEP;
            }
            else if (keyboard[Key.Up] && keyboard[Key.G] && green < 1)
            {
                green += COLOR_ADJUSTMENT_STEP;
            }
            else if (keyboard[Key.Down] && keyboard[Key.G] && green > 0)
            {
                green -= COLOR_ADJUSTMENT_STEP;
            }
            else if (keyboard[Key.Up] && keyboard[Key.A] && alpha < 1)
            {
                alpha += COLOR_ADJUSTMENT_STEP;
            }
            else if (keyboard[Key.Down] && keyboard[Key.A] && alpha > 0)
            {
                alpha -= COLOR_ADJUSTMENT_STEP;
                if (alpha < COLOR_ADJUSTMENT_STEP)
                {
                    alpha = 0;
                }
            }
        }
        //Requirement9 - for the left triangle, to set its vertices colors
        public void SetVertexColors(KeyboardState keyboard, ref Color color1, ref Color color2, ref Color color3)
        {
            Color temp_color1 = color1;
            Color temp_color2 = color2;
            Color temp_color3 = color3;

            if (keyboard[Key.Number1])
            {
                color1 = Color.FromArgb(255, 255, 0 , 0); //Red1
            }
            else if (keyboard[Key.Number2])
            {
                color1 = Color.FromArgb(255, 0, 255, 0); //Green1
            }
            if (keyboard[Key.Number3])
            {
                color1 = Color.FromArgb(255, 0, 0, 255); //Blue1
            }
            if (keyboard[Key.Number4])
            {
                color2 = Color.FromArgb(255, 255, 0, 0); //Red2
            }
            else if (keyboard[Key.Number5])
            {
                color2 = Color.FromArgb(255, 0, 255, 0); //Green2
            }
            if (keyboard[Key.Number6])
            {
                color2 = Color.FromArgb(255, 0, 0, 255); //Blue2
            }
            if (keyboard[Key.Number7])
            {
                color3 = Color.FromArgb(255, 255, 0, 0); //Red3
            }
            else if (keyboard[Key.Number8])
            {
                color3 = Color.FromArgb(255, 0, 255, 0); //Green3
            }
            if (keyboard[Key.Number9])
            {
                color3 = Color.FromArgb(255, 0, 0, 255); //Blue3
            }


            // Console Print
            if (temp_color1 != color1)
            {
                Console.WriteLine("Vertex 1: " + color1);
            }
            if (temp_color2 != color2)
            {
                Console.WriteLine("Vertex 2: " + color2);
            }
            if (temp_color3 != color3)
            {
                Console.WriteLine("Vertex 3: " + color3);
            }

        }
    }

}
