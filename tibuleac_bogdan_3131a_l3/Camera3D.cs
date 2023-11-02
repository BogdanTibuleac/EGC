using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tibuleac_bogdan_3131a_l3
{
    // Requirement 8 - Implementation of the feature to modify the camera angle using the mouse.  
    internal class Camera3D
    {
        private const int VISUAL_EDGE = 40;
        private Vector3 eye = new Vector3(0, 10, 30);
        private Vector3 target = new Vector3(0, 0 , 0);
        private Vector3 up = new Vector3(0, 1 , 0);
        private const int MOVEMENT_UNIT = 1;

        //Initialising
        public void SetCamera()
        {
            Matrix4 camera = Matrix4.LookAt(eye, target, up);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref camera);
        }

        // Checking the camera position and moving the camera eye by one unit to the right
        public void RotateRight()
        {
            if(eye.X < VISUAL_EDGE && eye.Z >= VISUAL_EDGE)
            {
                eye = new Vector3(eye.X + MOVEMENT_UNIT, eye.Y, eye.Z);
            }
            else if (eye.X >= VISUAL_EDGE && eye.Z> -VISUAL_EDGE)
            {
                eye = new Vector3(eye.X, eye.Y, eye.Z - MOVEMENT_UNIT);
            }
            else if(eye.X > -VISUAL_EDGE && eye.Z<= VISUAL_EDGE) 
            {
                eye = new Vector3(eye.X - MOVEMENT_UNIT, eye.Y, eye.Z);
            }
            else
            {
                eye = new Vector3(eye.X, eye.Y, eye.Z + MOVEMENT_UNIT);
            }
            SetCamera();
        }

        // Checking the camera position and moving the camera eye by one unit to the left
        public void RotateLeft()
        {
            if (eye.X < -VISUAL_EDGE && eye.Z >= VISUAL_EDGE)
            {
                eye = new Vector3(eye.X - MOVEMENT_UNIT, eye.Y, eye.Z);
            }
            else if (eye.X <= -VISUAL_EDGE && eye.Z > -VISUAL_EDGE)
            {
                eye = new Vector3(eye.X, eye.Y, eye.Z - MOVEMENT_UNIT);
            }
            else if (eye.X < VISUAL_EDGE && eye.Z <= -VISUAL_EDGE)
            {
                eye = new Vector3(eye.X + MOVEMENT_UNIT, eye.Y, eye.Z);
            }
            else
            {
                eye = new Vector3(eye.X, eye.Y, eye.Z + MOVEMENT_UNIT);
            }
            SetCamera();
        }

        //Checking camera status
        public void ControlCamera(MouseState mouse)
        {
            if (mouse[MouseButton.Left] && mouse.X > 100)
            {
                this.RotateRight();
            }
            else if (mouse[MouseButton.Left] && mouse.X < 100)
            {
                this.RotateLeft();
            }
            else
            {
                //do nothing
            }
        } 
    }


}
