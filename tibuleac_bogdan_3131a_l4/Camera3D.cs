using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tibuleac_bogdan_3131a_l4
{
    internal class Camera3D
    {
        private const int VISUAL_EDGE = 40;
        private Vector3 eye = new Vector3(20, 20, 40);
        private Vector3 target = new Vector3(0, 0, 0);
        private Vector3 up = new Vector3(0, 1, 0);
        private const int MOVEMENT_UNIT = 3;

        //Initialising
        public void SetCamera()
        {
            Matrix4 camera = Matrix4.LookAt(eye, target, up);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref camera);
        }

        public void RotateRight()
        {
            Matrix3 rotationMatrix = Matrix3.CreateRotationY(MathHelper.DegreesToRadians(MOVEMENT_UNIT));
            eye = Vector3.Transform(eye - target, rotationMatrix) + target;
            SetCamera();
        }

        public void RotateLeft()
        {
           Matrix3 rotationMatrix = Matrix3.CreateRotationY(MathHelper.DegreesToRadians(-MOVEMENT_UNIT));
            eye = Vector3.Transform(eye - target, rotationMatrix) + target;
            SetCamera();
        }


        //Checking camera status
        public void ControlCamera(MouseState mouse)
        {

            if (mouse[MouseButton.Right])
            {
                this.RotateRight();
            }
            else if (mouse[MouseButton.Left])
            {
                this.RotateLeft();
            }
            else
            {
                // do nothing
            }

        }
    }


}
