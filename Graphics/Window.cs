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

        public int width = 800;
        public int height = 600;

        public Window()
        {
            window = new(GameWindowSettings.Default, NativeWindowSettings.Default);

            window.MakeCurrent();

            window.Resize += OnResize;

            window.ClientRectangle = new(100, 100, width, height);

            uiManager = new(this);
            camera = new(this);

            // Temp
            UIColumn? column = (UIColumn)uiManager.Add(new UIColumn());
            column.SetPosition(new(10, 10));
            column.SetScale(new(80, 80));
            column.SetGap(2);

            UIPanel firstPanel = new();
            firstPanel.SetBackgroundColor(Color.Blue);

            column.AddChildren(firstPanel);
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
