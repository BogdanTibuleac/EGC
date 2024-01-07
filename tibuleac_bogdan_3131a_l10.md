
  # Intrebari laborator 10

``` Care este rolul comenzilor GL.Push() și GL. Pop()? De ce este necesară utilizarea lor? ``` 


Comenzile GL.Push() și GL.Pop() sunt utilizate în OpenGL pentru a gestiona stiva de matrice de transformare a scenei.

GL.Push() este folosit pentru a salva starea matricei de transformare actuală pe stivă. Aceasta înseamnă că puteți aplica transformări noi fără a afecta sau modifica matricea curentă.
GL.Pop() este folosit pentru a elimina matricea de transformare curentă de pe stivă și pentru a reveni la starea salvată anterior cu GL.Push().

```Explicați efectul rulării metodelor GL.Rotate(), GL.Translate() și GL.Scale(). Furnizați câte un exemplu comentat!```


Comenzile GL.Push() și GL.Pop() sunt utilizate în OpenGL pentru a gestiona stiva de matrice de transformare a scenei.

GL.Push() este folosit pentru a salva starea matricei de transformare actuală pe stivă. Aceasta înseamnă că puteți aplica transformări noi fără a afecta sau modifica matricea curentă.
GL.Pop() este folosit pentru a elimina matricea de transformare curentă de pe stivă și pentru a reveni la starea salvată anterior cu GL.Push().
Aceste comenzi sunt esențiale pentru că permit programatorilor să controleze și să gestioneze modificările aduse matricelor de transformare într-un mod organizat și reversibil.

Metodele GL.Rotate(), GL.Translate() și GL.Scale() sunt utilizate pentru a aplica transformări asupra obiectelor desenate în OpenGL.

GL.Rotate(angle, x, y, z) rotește obiectul cu un unghi dat în jurul axei definite de coordonatele (x, y, z).
GL.Translate(x, y, z) translează obiectul cu valorile x, y și z pe cele trei axe.
GL.Scale(x, y, z) scalează obiectul cu factorii x, y și z pe fiecare axă.

```cpp
using System;
using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace SimpleOpenGLExample
{
    class Program : GameWindow
    {
        private bool rotateEnabled = false;
        private bool translateEnabled = false;
        private bool scaleEnabled = false;

        public Program() : base(800, 600, GraphicsMode.Default, "Lab10")
        {
            VSync = VSyncMode.On;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color4.Black);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Key.Escape))
                Exit();

            if (keyboardState.IsKeyDown(Key.R))
            {
                rotateEnabled = true;
                translateEnabled = false;
                scaleEnabled = false;
            }
            else if (keyboardState.IsKeyDown(Key.T))
            {
                rotateEnabled = false;
                translateEnabled = true;
                scaleEnabled = false;
            }
            else if (keyboardState.IsKeyDown(Key.S))
            {
                rotateEnabled = false;
                translateEnabled = false;
                scaleEnabled = true;
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            if (rotateEnabled)
                GL.Rotate(1, 1, 1, 1); // Rotate by 1 degree on the x, y, and z axis
            else if (translateEnabled)
                GL.Translate(0.01, 0, 0); // Translate the object
            else if (scaleEnabled)
                GL.Scale(1.01, 1.01, 1.01); // Scale the object

            // Draw a simple cube
            GL.Begin(PrimitiveType.Quads);
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(Color4.Red);
            // Front face
            GL.Vertex3(-1, 1, 1);
            GL.Vertex3(1, 1, 1);
            GL.Vertex3(1, -1, 1);
            GL.Vertex3(-1, -1, 1);
            
            GL.Color3(Color4.Green);
            // Back face
            GL.Vertex3(-1, 1, -1);
            GL.Vertex3(1, 1, -1);
            GL.Vertex3(1, -1, -1);
            GL.Vertex3(-1, -1, -1);
            
            GL.Color3(Color4.Blue);
            // Top face
            GL.Vertex3(-1, 1, 1);
            GL.Vertex3(1, 1, 1);
            GL.Vertex3(1, 1, -1);
            GL.Vertex3(-1, 1, -1);
            
            GL.Color3(Color4.Yellow);
            // Bottom face
            GL.Vertex3(-1, -1, 1);
            GL.Vertex3(1, -1, 1);
            GL.Vertex3(1, -1, -1);
            GL.Vertex3(-1, -1, -1);
            
            GL.Color3(Color4.Orange);
            // Right face
            GL.Vertex3(1, 1, 1);
            GL.Vertex3(1, 1, -1);
            GL.Vertex3(1, -1, -1);
            GL.Vertex3(1, -1, 1);
            
            GL.Color3(Color4.Purple);
            // Left face
            GL.Vertex3(-1, 1, 1);
            GL.Vertex3(-1, 1, -1);
            GL.Vertex3(-1, -1, -1);
            GL.Vertex3(-1, -1, 1);
            GL.End();

            GL.End();

            SwapBuffers();
        }

        static void Main(string[] args)
        {
            using (var program = new Program())
            {
                program.Run(60.0);
            }
        }
    }
}

```


```Câte nivele de manipulări ierarhice (folosindu-se GL.Push()/GL.Pop()) suportă o scenă OpenGL?```

În ceea ce privește numărul de niveluri de manipulare ierarhică suportate de o scenă OpenGL, aceasta poate varia în funcție de implementare și de resursele hardware disponibile. În general, OpenGL permite o adâncime de stivă pentru manipulări de transformare, dar limita reală poate fi influențată de resursele sistemului și de configurația hardware. De obicei, însă, este posibil să folosiți o adâncime de stivă suficient de mare pentru majoritatea scenelor și aplicațiilor.
