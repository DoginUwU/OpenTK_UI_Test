using Teste1.Graphics;
using Teste1.Graphics.Scene;
using Teste1.Graphics.UI;

namespace Teste1.Game.Scenes
{
    internal class TestScene : Scene
    {
        public TestScene(Window window) : base(window, "TestScene")
        {
            UIPanel? panel = (UIPanel)uiManager.Add(new UIPanel());
            panel.SetPosition(new(10, 10));
            panel.SetScale(new(80, 80));
            panel.SetBackgroundImage(new Texture("teste.jpg"));
        }
    }
}
