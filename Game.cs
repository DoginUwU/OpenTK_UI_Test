using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using Teste1.Graphics;

namespace Teste1
{
    internal class Game
    {
        private static Game instance = default!;

        private readonly List<Window> windows = new();

        private bool isRunning = false;

        public Game() 
        {
            Game.instance = this;

            Window? mainWindow = new();

            // mainWindow.OpenGLWindow().WindowBorder = WindowBorder.Hidden;

            AddWindow(mainWindow);

            Init();
        }

        public static Game Instance()
        {
            return instance;
        }

        public static void AddWindow(Window window, bool runOnAdd = true)
        {
            if (runOnAdd)
            {
                window.Run();
            }

            instance.windows.Add(window);
        }

        public static void RemoveWindow(Window window) {
            instance.windows.Remove(window);
        }

        private static void Init()
        {
            instance.isRunning = true;

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            GameLoop();
        }

        private static void GameLoop()
        {
            DeltaTime? deltaTimePointer = new();

            while (instance.isRunning)
            {
                UpdateWindows(deltaTimePointer.GetDeltaTime());
            }
        }

        private static void UpdateWindows(float deltaTime)
        {
            List<Window> windowsRunning = instance.windows.FindAll(x => x.isRunning);

            windowsRunning.ForEach(x => x.Update(deltaTime));

            if (windowsRunning.Count == 0)
            {
                instance.isRunning = false;
            }
        }
    }
}
