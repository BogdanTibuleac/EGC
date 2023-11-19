using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tibuleac_bogdan_3131a_l5
{
    class Axes
    {
        public const int XYZ_SIZE = 75;
        private bool myVisibility;

        public Axes()
        {
            myVisibility = true;
        }


        public void Draw()
        {
            if(myVisibility)
            {
                GL.LineWidth(1);
                GL.Begin(PrimitiveType.Lines);

                // Ox.
                GL.Color3(Color.Red);
                GL.Vertex3(0, 0, 0);
                GL.Color3(Color.Blue);
                GL.Vertex3(XYZ_SIZE, 0, 0);

                // Oy.
                GL.Color3(Color.ForestGreen);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, XYZ_SIZE, 0);

                // Oz.
                GL.Color3(Color.Blue);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, 0, XYZ_SIZE);
                GL.End();
            }
        }

        public void Show()
        {
            myVisibility= true;
        }

        public void Hide()
        {
            myVisibility= false;
        }

        public void ToggleVisibility()
        { 
            myVisibility = !myVisibility;
        }
    }
}
