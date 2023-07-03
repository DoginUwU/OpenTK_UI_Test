using Teste1.Game.Scenes;
using Teste1.Graphics;
using Teste1.Graphics.Scene;

namespace Teste1.Game.Windows
{
    internal class TestWindow: Window
    {
        public TestWindow() : base()
        {
            Resize(new(400, 400));
            Position(new(800, 40));

            Scene testScene = new TestScene(this);

            sceneManager.AddScene(testScene);
            sceneManager.SetActiveScene(testScene.name);
        }
    }
}
