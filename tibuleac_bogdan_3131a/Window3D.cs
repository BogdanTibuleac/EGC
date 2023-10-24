using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//THE APP WAS CREATED USING OPENTK 3.3.3

namespace tibuleac_bogdan_3131a
{
    class Window3D : GameWindow
    {
        KeyboardState previousKeyboard;
        bool showCube = true;
        float XcubeRotation = 0;
        float XcubeTranslation = 0;

        public Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;
            displayHelp();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.LightBlue);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Set viewport and projection matrix
            GL.Viewport(0, 0, this.Width, this.Height);
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)Width / (float)Height, 1, 256);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            // Set camera position and orientation
            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            // Handle keyboard and mouse input
            KeyboardState thisKeyboard = Keyboard.GetState();
            MouseState thisMouse = Mouse.GetState();

            // Check for Escape key press to exit the application
            if (thisKeyboard[Key.Escape])
            {
                Exit();
                return;
            }
            else if (thisKeyboard[Key.H] && !previousKeyboard[Key.H])
            {
                displayHelp();
            }
            else if (thisKeyboard[Key.P] && !previousKeyboard[Key.P])
            {
                if (showCube == true)
                {
                    // Toggle cube visibility
                    showCube = false;
                }
                else
                {
                    showCube = true;
                }
            }
            // Move the cube in the negative X direction when 'A' key is pressed
            if (thisKeyboard[Key.A] && !previousKeyboard[Key.A])
            {
                XcubeTranslation += 0.10f;
            }

            // Move the cube in the positive X direction when 'D' key is pressed
            if (thisKeyboard[Key.D] && !previousKeyboard[Key.D])
            {
                XcubeTranslation -= 0.10f;
            }

            // Rotate the cube in the X-axis direction when left mouse button is pressed
            if (thisMouse[MouseButton.Left] && XcubeRotation < 2)
            {
                XcubeRotation += 0.50f;
            }

            // Update the previous keyboard state for the next frame
            previousKeyboard = thisKeyboard;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            // Clear the color and depth buffers
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            // Apply translation and rotation to the modelview matrix
            GL.Translate(new Vector3(XcubeTranslation, 0, 0));
            GL.Rotate(XcubeRotation, 1, 0, 0);

            if (showCube == true)
            {
                DrawCube();
            }
            // Swap the front and back buffers to display the rendered image
            SwapBuffers();
        }
        private void DrawCube()
        {
            GL.Begin(PrimitiveType.Quads);
            // Draw the cube using GL.Begin and GL.Vertex3 calls
            // The cube has 6 faces

            GL.Color3(Color.AliceBlue);
            GL.Vertex3(-10.0f, -10.0f, -10.0f);
            GL.Vertex3(-10.0f, 10.0f, -10.0f);
            GL.Vertex3(10.0f, 10.0f, -10.0f);
            GL.Vertex3(10.0f, -10.0f, -10.0f);

            GL.Color3(Color.AntiqueWhite);
            GL.Vertex3(-10.0f, -10.0f, -10.0f);
            GL.Vertex3(10.0f, -10.0f, -10.0f);
            GL.Vertex3(10.0f, -10.0f, 10.0f);
            GL.Vertex3(-10.0f, -10.0f, 10.0f);

            GL.Color3(Color.Beige);

            GL.Vertex3(-10.0f, -10.0f, -10.0f);
            GL.Vertex3(-10.0f, -10.0f, 10.0f);
            GL.Vertex3(-10.0f, 10.0f, 10.0f);
            GL.Vertex3(-10.0f, 10.0f, -10.0f);

            GL.Color3(Color.LightSalmon);
            GL.Vertex3(-10.0f, -10.0f, 10.0f);
            GL.Vertex3(10.0f, -10.0f, 10.0f);
            GL.Vertex3(10.0f, 10.0f, 10.0f);
            GL.Vertex3(-10.0f, 10.0f, 10.0f);

            GL.Color3(Color.PaleVioletRed);
            GL.Vertex3(-10.0f, 10.0f, -10.0f);
            GL.Vertex3(-10.0f, 10.0f, 10.0f);
            GL.Vertex3(10.0f, 10.0f, 10.0f);
            GL.Vertex3(10.0f, 10.0f, -10.0f);

            GL.Color3(Color.Yellow);
            GL.Vertex3(10.0f, -10.0f, -10.0f);
            GL.Vertex3(10.0f, 10.0f, -10.0f);
            GL.Vertex3(10.0f, 10.0f, 10.0f);
            GL.Vertex3(10.0f, -10.0f, 10.0f);

            GL.End();
        }

        private void displayHelp()
        {
            // Display help information in the console
            Console.WriteLine(" Menu");
            Console.WriteLine(" ESC - exit application");
            Console.WriteLine(" H   - display HELP menu");
            Console.WriteLine(" A   - Move the cube in the negative X direction");
            Console.WriteLine(" D   - Move the cube in the positive X direction");
            Console.WriteLine(" Left Mouse Button - Rotate the cube around X-axis");
            Console.WriteLine("\n");
        }
    }
}