using OpenTK.Input;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace tibuleac_bogdan_3131a_l4
{
    class Cube
    {
        
        private List<Vector3> vertices;

        
        private double red = 1, green = 1, blue = 1, alpha = 1;
        private Color tcolor1 = Color.Yellow, tcolor2 = Color.Yellow, tcolor3 = Color.Yellow;
        private RandomColorGenerator colorGenerator;
        private ColorHandler colorhandler;

        public Cube(string caleFisier)
        {
            vertices = new List<Vector3>();

            // Read from "coordonate.txt"
            //-------------------------------------------------------------------------------
            string text = System.IO.File.ReadAllText(@caleFisier);

            System.Console.WriteLine("Contents of coordonate.txt = {0}\n", text);
            
            string[] lines = text.Split('\n');

            for (int i = 0; i < 36; i++)
            {
                string[] coordonate = lines[i].Split(' ');
                vertices.Add(new Vector3(int.Parse(coordonate[0]), int.Parse(coordonate[1]), int.Parse(coordonate[2])));
            }
            //-------------------------------------------------------------------------------

            // random color generator
            colorhandler = new ColorHandler();
            colorGenerator = new RandomColorGenerator();

        }


        //set colors
        public void SetColor()
        {

            
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            colorhandler.SetColor(keyboard, ref alpha, ref red, ref green, ref blue );
            colorhandler.SetVertexColors(keyboard, ref tcolor1, ref tcolor2, ref tcolor3);
        }


        public void Draw()
        {
            GL.Begin(PrimitiveType.Triangles);
            for (int i = 0; i < 36; i = i + 6)  // increment by 6 to consider two triangles forming a face
            {
                // Cerinta 1
                if (i > 28)
                {
                    GL.Color4(red, green, blue, alpha);
                }
                else
                {
                    GL.Color3(Color.Purple);
                }

                // Cerinta 2
                if (i == 18)
                {
                    GL.Color3(tcolor1);
                }
                GL.Vertex3(vertices[i]);
                if (i == 18)
                {
                    GL.Color3(tcolor2);
                }
                GL.Vertex3(vertices[i + 1]);
                if (i == 18)
                {
                    GL.Color3(tcolor3);
                }
                GL.Vertex3(vertices[i + 2]);

                if (i == 18)
                {
                    GL.Color3(tcolor1);
                }
                GL.Vertex3(vertices[i + 3]);
                if (i == 18)
                {
                    GL.Color3(tcolor2);
                }
                GL.Vertex3(vertices[i + 4]);
                if (i == 18)
                {
                    GL.Color3(tcolor3);
                }
                GL.Vertex3(vertices[i + 5]);
            }
            GL.End();
        }

    }
}
