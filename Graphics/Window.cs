using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using Teste1.Graphics.Scene;

namespace Teste1.Graphics
{
    internal abstract class Window
    {
        public readonly Camera camera;
        public bool isRunning = false;

        protected readonly GameWindow window;
        protected readonly SceneManager sceneManager;

        protected int posX = 0;
        protected int posY = 0;
        protected int width = 0;
        protected int height = 0;

        public int Width
        {
            get
            {
                return width;
            }
        }

        public int Height
        {
            get 
            { 
                return height; 
            }
        }

        public Window()
        {
            window = new(GameWindowSettings.Default, NativeWindowSettings.Default);

            window.MakeCurrent();

            sceneManager = new(this);
            camera = new(this);

            window.Resize += OnResize;

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        }

        ~Window()
        {
            window.Resize += OnResize;

            Dispose();
        }

        public void Run()
        {
            isRunning = true;
        }

        public virtual void Update(float deltaTime)
        {
            window.MakeCurrent();

            UpdateRenderFrame();
            UpdateFrame();
        }

        public GameWindow OpenGLWindow()
        {
            return window;
        }

        private void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, e.Width, e.Height);

            width = e.Width;
            height = e.Height;

            camera?.Setup();
            sceneManager.Refresh();
        }

        private void UpdateRenderFrame()
        {
            GL.ClearColor(0.52f, 0.89f, 1f, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            sceneManager.UpdateRenderFrame();

            window.Context.SwapBuffers();
        }

        private void UpdateFrame()
        {
            NativeWindow.ProcessWindowEvents(false);
            window.ProcessInputEvents();

            sceneManager.UpdateFrame();

            if (!window.IsFocused)
            {
                return;
            }

            KeyboardState input = window.KeyboardState;

            if(input.IsKeyDown(Keys.Escape))
            {
                Dispose();
            }
        }

        private void Dispose()
        {
            isRunning = false;

            window.Close();
            window.Dispose();
        }

        protected void Resize(Vector2i size)
        {
            width = size.X;
            height = size.Y;

            window.Bounds = new(0, 0, width, height);
        }

        protected void Position(Vector2i pos)
        {
            window.Location = pos;
        }
    }
}
