using System.Data.Common;
using Teste1.Graphics;
using Teste1.Graphics.Scene;
using Teste1.Graphics.UI;

namespace Teste1.Game.Scenes
{
    internal class TestScene : Scene
    {
        public TestScene(Window window) : base(window, "TestScene")
        {
            UIPanel panel1 = new();
            panel1.SetBackgroundImage(new Texture("teste.jpg"));
            panel1.SetPosition(new(50 - (30 / 2), 80 - (30 / 2)));
            panel1.SetScale(new(30, 30));

            uiManager.Add(panel1);
        }
    }
}
