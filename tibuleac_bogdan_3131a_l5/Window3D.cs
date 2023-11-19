using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using tibuleac_bogdan_3131a_l4;
using tibuleac_bogdan_3131a_l5;

//THE APP WAS CREATED USING OPENTK 3.3.3
//TEMA 5
//Tibuleac Bogdan-Ionut
//Deadline: 19 noiembrie, 23:59

namespace tibuleac_bogdan_3131a_l5
{
    // Class representing the 3D window
    class Window3D : GameWindow
    {
        private KeyboardState previousKeyboard;
        private MouseState previousMouse;
        private readonly Randomizer rando;
        private readonly Axes ax;
        private readonly Grid grid;
        private readonly Camera3D cam;
        private bool displayMarker;
        private ulong updatesCounter;
        private ulong framesCounter;
        private MassiveObject objy;

        private List<SomeObject> objectsList;
 
        private List<Vector3> vertices;
        private List<MassiveObject> massiveObjectsList;

        // DEFAULTS
        private readonly Color DEFAULT_BKG_COLOR = Color.FromArgb(49, 50, 51);


        // Constructor for the 3D window
        public Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;

            rando = new Randomizer();
            ax = new Axes();
            grid = new Grid();
            cam = new Camera3D();
            objy = new MassiveObject(Color.Yellow);

            vertices = readVerticesFromFile(@"./../../coordonate.txt");

            objectsList = new List<SomeObject>();

            massiveObjectsList = new List<MassiveObject>();

            displayHelp();
            displayMarker = false;
            updatesCounter = 0;
            framesCounter = 0;
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
            cam.SetCamera();
        }

        // Method called to update the frame
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            updatesCounter++;

            if (displayMarker)
            {
                TimeStampIt("update", updatesCounter.ToString());
            }

            // Handle keyboard and mouse input
            KeyboardState thisKeyboard = Keyboard.GetState();
            MouseState thisMouse = Mouse.GetState();


            // Check for key presses and perform corresponding actions
            if (thisKeyboard[Key.Escape])
            {
                // Exit the application when Escape key is pressed
                Exit();
                return;
            }
            if (thisKeyboard[Key.R] && !previousKeyboard[Key.R])
            {
                GL.ClearColor(DEFAULT_BKG_COLOR);
                ax.Show();
                grid.Show();
            }

            if (thisKeyboard[Key.K] && !previousKeyboard[Key.K])
            {
                ax.ToggleVisibility();
            }

            if (thisKeyboard[Key.B] && !previousKeyboard[Key.B])
            {
                GL.ClearColor(rando.RandomColor());
            }

            if (thisKeyboard[Key.V] && !previousKeyboard[Key.V])
            {
                grid.ToggleVisibility();
            }

            if (thisKeyboard[Key.O] && !previousKeyboard[Key.O])
            {
                objy.ToggleVisibility();
            }

            // camera control (isometric mode)
            if (thisKeyboard[Key.W])
            {
                cam.MoveForward();
            }
            if (thisKeyboard[Key.S])
            {
                cam.MoveBackward();
            }
            if (thisKeyboard[Key.A])
            {
                cam.MoveLeft();
            }
            if (thisKeyboard[Key.D])
            {
                cam.MoveRight();
            }
            if (thisKeyboard[Key.Q])
            {
                cam.MoveUp();
            }
            if (thisKeyboard[Key.E])
            {
                cam.MoveDown();
            }
            if (thisKeyboard[Key.KeypadMinus])
            {
                cam.ZoomOut();
            }

            if (thisKeyboard[Key.KeypadPlus])
            {
                cam.ZoomIn();
            }

            if (thisKeyboard[Key.M])
            {
                cam.Far();
            }

            if (thisKeyboard[Key.N])
            {
                cam.Near();
            }
            if (thisMouse[MouseButton.Left] && !previousMouse[MouseButton.Left])
            {
                objectsList.Add(new SomeObject(true, vertices));
            }


            foreach (SomeObject obj in objectsList)
            {
                obj.UpdatePosition(true);
            }

            foreach (MassiveObject obj in massiveObjectsList)
            {
                obj.UpdatePosition(true);
            }

            // object spam cleanup
            if (thisMouse[MouseButton.Right] && !previousMouse[MouseButton.Right])
            {
                objectsList.Clear();
                //listaMassiveObj.Clear();
            }

            // helper functions
            if (thisKeyboard[Key.L] && !previousKeyboard[Key.L])
            {
                displayMarker = !displayMarker;
            }

            previousKeyboard = thisKeyboard;
            previousMouse = thisMouse;
            // END logic code
        }

        // Method called to render the frame
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            // Clear the color and depth buffers
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            // Draw the coordinate axes and the triangles
            grid.Draw();
            ax.Draw();
            objy.Draw();

            foreach (SomeObject obj in objectsList)
            {
                obj.Draw();
            }

            foreach (MassiveObject obj in massiveObjectsList)
            {
                obj.Draw();
            }

            // Swap the front and back buffers to display the rendered image
            SwapBuffers();
        }

        // Method to draw the coordinate axes
        public List<Vector3> readVerticesFromFile(string numeFisier)
        {
            List<Vector3> vertexuriDinFisier = new List<Vector3>();

            using (StreamReader sr = new StreamReader(numeFisier))
            {
                string linie;
                while ((linie = sr.ReadLine()) != null)
                {
                    var numere = linie.Split(',');
                    int i = 0;
                    float[] coordonate = new float[3];
                    foreach (var nr in numere)
                    {
                        coordonate[i++] = float.Parse(nr);

                        if (coordonate[i - 1] < 0 || coordonate[i - 1] > 250)
                        {
                            throw new ArithmeticException("Invalid vertex !");
                        }
                    }
                    vertexuriDinFisier.Add(new Vector3(coordonate[0], coordonate[1], coordonate[2]));
                }
            }

            return vertexuriDinFisier;
        }

        private void TimeStampIt(String source, String counter)
        {
            String dt = DateTime.Now.ToString("hh:mm:ss.ffff");
            Console.WriteLine("     TSTAMP from <" + source + "> on iteration <" + counter + ">: " + dt);
        }


        // Method to display help menu in the console
        private void displayHelp()
        {
            Console.WriteLine("\n______________________________________________________");
            Console.WriteLine("| MENU                                                |");
            Console.WriteLine("| ---------------------------------------------------- |");
            Console.WriteLine("| (ESC) - exit application                             |");
            Console.WriteLine("| (H)   - display HELP menu                            |");
            Console.WriteLine("| (K)   - toggle axis visibility                       |");
            Console.WriteLine("| (R)   - reset scene to default values                |");
            Console.WriteLine("| (B)   - change background color                      |");
            Console.WriteLine("| (V)   - toggle line visibility                       |");
            Console.WriteLine("| (W,A,S,D) - move camera                              |");
            Console.WriteLine("| (M,N) - set camera to predefined locations           |");
            Console.WriteLine("| (+, -) - numeric keyboard - zoom camera              |");
            Console.WriteLine("| Right click - generate a random object               |");
            Console.WriteLine("|______________________________________________________|\n");
        }

    }
}