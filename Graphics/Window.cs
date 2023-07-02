using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Drawing;
using Teste1.Graphics.UI;

namespace Teste1.Graphics
{
    internal class Window
    {
        public bool isRunning = false;

        private readonly GameWindow window;
        private readonly UIManager uiManager;

        public readonly Camera camera;

        private int posX = 100;
        private int posY = 100;
        private int width = 800;
        private int height = 600;

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

            window.Resize += OnResize;

            window.ClientRectangle = new(posX, posY, width, height);

            uiManager = new(this);
            camera = new(this);

            // Temp
            UIColumn? column = (UIColumn)uiManager.Add(new UIColumn());
            column.SetPosition(new(10, 50));
            column.SetScale(new(30, 40));
            column.SetGap(2);

            column.AddChildren(new UIPanel());
            column.AddChildren(new UIPanel());
            column.AddChildren(new UIPanel());
            column.AddChildren(new UIPanel());
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

        public void Update(float deltaTime)
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
            uiManager?.ReloadAll();
        }

        private void UpdateRenderFrame()
        {
            GL.ClearColor(0.52f, 0.89f, 1f, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            uiManager.Render();

            window.Context.SwapBuffers();
        }

        private void UpdateFrame()
        {
            NativeWindow.ProcessWindowEvents(false);
            window.ProcessInputEvents();

            uiManager.Update();

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
    }
}
