using OpenTK.Mathematics;
using Teste1.Graphics.UI;

namespace Teste1.Graphics
{
    internal class Camera
    {
        private readonly Window window;

        private Matrix4 projection;
        private Matrix4 view;

        public Camera(Window window)
        {
            this.window = window;

            Setup();
        }

        public void Setup()
        {
            view = Matrix4.Identity;
            projection = Matrix4.CreateOrthographicOffCenter(-window.width / 2f, window.width / 2f, -window.height / 2f, window.height / 2f, 0f, 1f);
        }

        public Matrix4 GetViewMatrix()
        {
            return view;
        }

        public Matrix4 GetProjectionMatrix()
        {
            return projection;
        }
    }
}
