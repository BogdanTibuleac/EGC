using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tibuleac_bogdan_3131a_l5
{
    internal class Camera3D
    {
        private const int VISUAL_EDGE = 40;

        private Vector3 eye;
        private Vector3 target;
        private Vector3 up;

        private const int MOVEMENT_UNIT = 3;
        private const int ZOOM_UNIT = 3;

        public Camera3D()
        {
            eye = new Vector3(125, 75, 25);
            target = new Vector3(0, 25, 0);
            up = new Vector3(0, 1, 0);
        }

        public Camera3D(int _eyeX, int _eyeY, int _eyeZ, int _targetX, int _targetY, int _targetZ, int _upX, int _upY, int _upZ)
        {
            eye = new Vector3(_eyeX, _eyeY, _eyeZ);
            target = new Vector3(_targetX, _targetY, _targetZ);
            up = new Vector3(_upX, _upY, _upZ);
        }
        public Camera3D(Vector3 _eye, Vector3 _target, Vector3 _up)
        {
            eye = _eye;
            target = _target;
            up = _up;
        }

        //Initialising
        public void SetCamera()
        {
            Matrix4 camera = Matrix4.LookAt(eye, target, up);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref camera);
        }

        public void MoveRight()
        {
            eye = new Vector3(eye.X, eye.Y, eye.Z - MOVEMENT_UNIT);
            target = new Vector3(target.X, target.Y, target.Z - MOVEMENT_UNIT);
            SetCamera();
        }
        public void MoveLeft()
        {
            eye = new Vector3(eye.X, eye.Y, eye.Z + MOVEMENT_UNIT);
            target = new Vector3(target.X, target.Y, target.Z + MOVEMENT_UNIT);
            SetCamera();
        }

        public void MoveForward()
        {
            eye = new Vector3(eye.X - MOVEMENT_UNIT, eye.Y, eye.Z);
            target = new Vector3(target.X - MOVEMENT_UNIT, target.Y, target.Z);
            SetCamera();
        }

        public void MoveBackward()
        {
            eye = new Vector3(eye.X + MOVEMENT_UNIT, eye.Y, eye.Z);
            target = new Vector3(target.X + MOVEMENT_UNIT, target.Y, target.Z);
            SetCamera();
        }

        public void MoveUp()
        {
            eye = new Vector3(eye.X, eye.Y + MOVEMENT_UNIT, eye.Z);
            target = new Vector3(target.X, target.Y + MOVEMENT_UNIT, target.Z);
            SetCamera();
        }

        public void MoveDown()
        {
            eye = new Vector3(eye.X, eye.Y - MOVEMENT_UNIT, eye.Z);
            target = new Vector3(target.X, target.Y - MOVEMENT_UNIT, target.Z);
            SetCamera();
        }

        public void ZoomOut()
        {
            eye = new Vector3(eye.X + ZOOM_UNIT, eye.Y + ZOOM_UNIT, eye.Z);
            target = new Vector3(target.X + ZOOM_UNIT, target.Y + ZOOM_UNIT, target.Z);
            SetCamera();
        }

        public void ZoomIn()
        {
            eye = new Vector3(eye.X - ZOOM_UNIT, eye.Y - ZOOM_UNIT, eye.Z);
            target = new Vector3(target.X - ZOOM_UNIT, target.Y - ZOOM_UNIT, target.Z);
            SetCamera();
        }

        public void Near()
        {
            eye = new Vector3(125, 100, 25);
            target = new Vector3(0, 25, 0);
            SetCamera();
        }

        public void Far()
        {
            eye = new Vector3(200, 175, 25);
            target = new Vector3(0, 25, 0);
            SetCamera();
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
