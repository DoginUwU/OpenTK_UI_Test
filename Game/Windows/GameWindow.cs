using OpenTK.Windowing.Desktop;
using Teste1.Game.Scenes;
using Teste1.Graphics;
using Teste1.Graphics.Scene;

namespace Teste1.Game.Windows
{
    internal class GameWindow : Window
    {
        private float test = 0;
        private bool flip = false;
        private float test2 = 0;
        private bool flip2 = false;
        private MonitorInfo currentMonitor = Monitors.GetPrimaryMonitor();

        public GameWindow() : base()
        {
            Resize(new(800, 600));
            Position(new(10, 40));

            Scene mainMenuScene = new MenuScene(this);

            sceneManager.AddScene(mainMenuScene);
            sceneManager.SetActiveScene(mainMenuScene.name);
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (!flip)
            {
                test += 700 * deltaTime;
            }
            else
            {
                test -= 700 * deltaTime;
            }

            if ((test + 800) >= currentMonitor.ClientArea.Max.X)
            {
                flip = true;
            }
            else if (test <= 0)
            {
                flip = false;
            }

            if (!flip2)
            {
                test2 += 700 * deltaTime;
            }
            else
            {
                test2 -= 700 * deltaTime;
            }

            if ((test2 + 600) >= currentMonitor.ClientArea.Max.Y)
            {
                flip2 = true;
            }
            else if (test2 <= 0)
            {
                flip2 = false;
            }

            // Position(new((int)test, (int)test2));
        }
    }
}
