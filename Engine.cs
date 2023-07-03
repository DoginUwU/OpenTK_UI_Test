using Teste1.Graphics;

namespace Teste1
{
    internal class Engine
    {
        private static Engine instance = default!;

        private readonly List<Window> windows = new();

        private bool isRunning = false;

        public Engine() 
        {
            instance = this;
        }

        public static Engine Instance()
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

        public static void Init()
        {
            instance.isRunning = true;

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
