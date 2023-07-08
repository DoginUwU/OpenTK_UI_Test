using Teste1.Game.Scenes;
using Teste1.Graphics;
using Teste1.Graphics.Scene;

namespace Teste1.Game.Windows
{
    internal class TestWindow : Window
    {
        public TestWindow() : base()
        {
            Resize(new(720, 720));
            Position(new(20, 30));

            window.WindowBorder = OpenTK.Windowing.Common.WindowBorder.Hidden;

            Scene testScene = new TestScene(this);

            sceneManager.AddScene(testScene);
            sceneManager.SetActiveScene(testScene.name);
        }
    }
}
