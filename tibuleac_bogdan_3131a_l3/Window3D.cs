using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;

//THE APP WAS CREATED USING OPENTK 3.3.3
//TEMA 3
//Tibuleac Bogdan-Ionut
//Deadline: 05 noiembrie, 23:59

namespace tibuleac_bogdan_3131a_l3
{
    // Class representing the 3D window
    class Window3D : GameWindow
    {
        // Variables for managing keyboard state and cube rotation
        KeyboardState previousKeyboard;
        float XcubeRotation = 0;
        float XcubeTranslation = 0;

        // Initial color components for the triangle
        private double red = 1, green = 1, blue = 1, alpha = 1;

        // Constant size for the axes
        public const int XYZ_SIZE = 75;

        // Array to store triangle vertices' coordinates
        private Vector3[] coordonate = new Vector3[3];

        // Camera and color handler objects
        private Camera3D camera;
        private ColorHandler colorhandler;

        // Colors for the triangle vertices
        private Color color1, color2, color3;

        // Constructor for the 3D window
        public Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            // Read triangle vertices' coordinates from a file
            string text = System.IO.File.ReadAllText(@"./../../coordonate.txt");
            string[] lines = text.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                string[] textCoord = lines[i].Split(' ');
                coordonate[i][0] = int.Parse(textCoord[0]);
                coordonate[i][1] = int.Parse(textCoord[1]);
                coordonate[i][2] = int.Parse(textCoord[2]);
            }

            // Set vertical synchronization and initialize camera and color handler
            VSync = VSyncMode.On;
            camera = new Camera3D();
            colorhandler = new ColorHandler();

            // Generate random colors for the upper triangle vertices
            color1 = colorhandler.GenerateRandomColor();
            color2 = colorhandler.GenerateRandomColor();
            color3 = colorhandler.GenerateRandomColor();

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

            // Adjust triangle colors based on keyboard input
            colorhandler.SetColor(thisKeyboard, ref alpha, ref red, ref blue, ref green);
            // Set triangle vertex colors based on keyboard input
            colorhandler.SetVertexColors(thisKeyboard, ref color1, ref color2, ref color3);

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
            else if (thisKeyboard[Key.Q] && !previousKeyboard[Key.Q])
            {
                // Set triangle color to white when 'Q' key is pressed
                colorhandler.SetTriangleToWhite(thisKeyboard, ref color1, ref color2, ref color3);
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
            DrawAxes();
            DrawObjects();

            // Swap the front and back buffers to display the rendered image
            SwapBuffers();
        }

        // Method to draw the coordinate axes
        private void DrawAxes()
            
        {
            // Requirement 1 - Drawing the axes using a single GL.Begin() call
            GL.Begin(PrimitiveType.Lines);

            // Draw the positive X-axis in black
            GL.Color3(Color.Black);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(XYZ_SIZE, 0, 0);

            // Draw the negative X-axis in black
            GL.Color3(Color.Black);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(-XYZ_SIZE, 0, 0);

            // Draw the Y-axis in black
            GL.Color3(Color.Black);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, XYZ_SIZE, 0);

            // Draw the Z-axis in black
            GL.Color3(Color.Black);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, XYZ_SIZE);

            GL.End();
        }

        // Method to draw the triangles
        private void DrawObjects()
        {
            // Draw the first triangle using coordinates from the file and adjusted color
            GL.Begin(PrimitiveType.Triangles);
            GL.Color4(alpha, red, green, blue);
            GL.Vertex3(coordonate[0][0], coordonate[0][1], coordonate[0][2]);
            GL.Vertex3(coordonate[1][0], coordonate[1][1], coordonate[1][2]);
            GL.Vertex3(coordonate[2][0], coordonate[2][1], coordonate[2][2]);
            GL.End();

            // Draw the second triangle using TriangleStrip primitive with different colors for vertices
            GL.Begin(PrimitiveType.TriangleStrip);
            GL.Color3(color1);
            GL.Vertex3(0, 0, 0);
            GL.Color3(color2);
            GL.Vertex3(-10, 0, 0);
            GL.Color3(color3);
            GL.Vertex3(0, 10, 0);
            GL.End();
        }

        // Method to display help menu in the console
        private void displayHelp()
        {
            // Display help information in the console
            Console.WriteLine("\n_______________________________________________________________________________");
            Console.WriteLine("| MENU                                                                         |");
            Console.WriteLine("| -----------------------------------------------------------------------------|");
            Console.WriteLine("| ESC - exit application                                                       |");
            Console.WriteLine("| H   - display HELP menu                                                      |");

            Console.WriteLine("| Q   - set the triangle color to white                                        |");

            Console.WriteLine("| Instructions                             | Keyboard Actions                  |");
            Console.WriteLine("| -----------------------------------------|-----------------------------------|");
            Console.WriteLine("| Up Arrow + R - Increase red component    | 1 - Set vertex 1 color to Red     |");
            Console.WriteLine("| Down Arrow + R - Decrease red component  | 2 - Set vertex 1 color to Green   |");
            Console.WriteLine("| Up Arrow + B - Increase blue component   | 3 - Set vertex 1 color to Blue    |");
            Console.WriteLine("| Down Arrow + B - Decrease blue component | 4 - Set vertex 2 color to Red     |");
            Console.WriteLine("| Up Arrow + G - Increase green component  | 5 - Set vertex 2 color to Green   |");
            Console.WriteLine("| Down Arrow + G - Decrease green component| 6 - Set vertex 2 color to Blue    |");
            Console.WriteLine("| Up Arrow + A - Increase alpha component  | 7 - Set vertex 3 color to Red     |");
            Console.WriteLine("| Down Arrow + A - Decrease alpha component| 8 - Set vertex 3 color to Green   |");
            Console.WriteLine("| Left Mouse Button - Rotate the system    | 9 - Set vertex 3 color to Blue    |");

            Console.WriteLine("|______________________________________________________________________________|");


            Console.WriteLine("\n*Note: \nThe left triangle will have a random color, \nwhile the right one is white in the beginning");

            Console.WriteLine("\n");
        }
    }
}
