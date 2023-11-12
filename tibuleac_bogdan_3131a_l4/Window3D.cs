using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;
using tibuleac_bogdan_3131a_l4;

//THE APP WAS CREATED USING OPENTK 3.3.3
//TEMA 4
//Tibuleac Bogdan-Ionut
//Deadline: 12 noiembrie, 23:59

namespace tibuleac_bogdan_3131a_l4
{
    // Class representing the 3D window
    class Window3D : GameWindow
    {
        KeyboardState previousKeyboard;
        private ColorHandler colorhandler;
        private Camera3D camera;
        private Cube cube;
        private Axes axes;

        // Constructor for the 3D window
        public Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

            camera = new Camera3D();
            axes = new Axes();

            cube = new Cube("./../../coordonate.txt");

            // Display initial help menu
            displayHelp();
        }

        // Method called when the window is loaded
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Set the clear color, enable depth testing, and set polygon smoothing hint
            GL.ClearColor(Color.LightBlue);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        // Method called when the window is resized
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // Set viewport and projection matrix based on window dimensions
            GL.Viewport(0, 0, this.Width, this.Height);
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)Width / (float)Height, 1, 256);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
            // Set camera position and orientation
            camera.SetCamera();
        }

        // Method called to update the frame
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            // Handle keyboard and mouse input
            KeyboardState thisKeyboard = Keyboard.GetState();
            MouseState thisMouse = Mouse.GetState();

            // Control camera using mouse input
            camera.ControlCamera(thisMouse);
            cube.SetColor();

            // Check for key presses and perform corresponding actions
            if (thisKeyboard[Key.Escape])
            {
                // Exit the application when Escape key is pressed
                Exit();
                return;
            }
            else if (thisKeyboard[Key.H] && !previousKeyboard[Key.H])
            {
                // Display help menu when 'H' key is pressed
                displayHelp();
            }


            // Update the previous keyboard state for the next frame
            previousKeyboard = thisKeyboard;
        }

        // Method called to render the frame
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            // Clear the color and depth buffers
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            // Draw the coordinate axes and the triangles
            axes.Draw();
            cube.Draw();

            // Swap the front and back buffers to display the rendered image
            SwapBuffers();
        }

        // Method to draw the coordinate axes



        // Method to display help menu in the console
        private void displayHelp()
        {
            // Display help information in the console
            Console.WriteLine("\n__________________________________________________________");
            Console.WriteLine("| MENU                                                    |");
            Console.WriteLine("| --------------------------------------------------------|");
            Console.WriteLine("| ESC - exit application                                  |");
            Console.WriteLine("| H   - display HELP menu                                 |");

            Console.WriteLine("| Instructions                                            |");
            Console.WriteLine("| --------------------------------------------------------|");
            Console.WriteLine("| 1 - Set vertex 1 color to a random color                |");
            Console.WriteLine("| 2 - Set vertex 2 color to a random color                |");
            Console.WriteLine("| 3 - Set vertex 3 color to a random color                |");
            Console.WriteLine("| Up Arrow + R - Increase red component                   |");
            Console.WriteLine("| Up Arrow + R - Increase red component                   |");
            Console.WriteLine("| Down Arrow + R - Decrease red component                 |");
            Console.WriteLine("| Up Arrow + B - Increase blue component                  |");
            Console.WriteLine("| Down Arrow + B - Decrease blue component                |");
            Console.WriteLine("| Up Arrow + G - Increase green component                 |");
            Console.WriteLine("| Down Arrow + G - Decrease green component               |");
            Console.WriteLine("| Up Arrow + A - Increase alpha component                 |");
            Console.WriteLine("| Down Arrow + A - Decrease alpha component               |");
            Console.WriteLine("| Left Mouse Button - Rotate the system to the left       |");
            Console.WriteLine("| Right Mouse Button - Rotate the system to the right     |");

            Console.WriteLine("|_________________________________________________________|");

            Console.WriteLine("\n");
        }
    }
}