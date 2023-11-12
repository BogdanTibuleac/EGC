using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tibuleac_bogdan_3131a_l4
{
    internal class ColorHandler
    {
        private const double COLOR_ADJUSTMENT_STEP = 0.05;
        private RandomColorGenerator colorGenerator = new RandomColorGenerator();
        KeyboardState previousKeyboard;

        /*
            1. Creați o aplicație care la apăsarea unui set de taste va modifica
            culoarea unei fețe a unui cub 3D (coordonatele acestuia vor fi
            încărcate dintr-un fișier text) între valorile minime și maxime, pentru
            fiecare canal de culoare.
         */
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
        /*
         2. Modificați aplicația pentru a manipula valorile RGB pentru fiecare
            vertex ce definește un triunghi. Afișați valorile RGB în consolă.
         */
        public void SetVertexColors(KeyboardState keyboard, ref Color color1, ref Color color2, ref Color color3)
        {
            Color temp_color1 = color1;
            Color temp_color2 = color2;
            Color temp_color3 = color3;

            if (keyboard != previousKeyboard)
            {
                if (keyboard[Key.Number1])
                {
                    color1 = colorGenerator.Generate();
                    Console.WriteLine("Vertex 1: " + color1);
                }
                if (keyboard[Key.Number2])
                {
                    color2 = colorGenerator.Generate();
                    Console.WriteLine("Vertex 2: " + color2);
                }
                if (keyboard[Key.Number3])
                {
                    color3 = colorGenerator.Generate();
                    Console.WriteLine("Vertex 3: " + color3);
                }

                previousKeyboard = keyboard;
            }

        }
    }

}
