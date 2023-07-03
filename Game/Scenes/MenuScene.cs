using Teste1.Graphics;
using Teste1.Graphics.Scene;
using Teste1.Graphics.UI;

namespace Teste1.Game.Scenes
{
    internal class MenuScene : Scene
    {
        public MenuScene(Window window) : base(window, "MenuScene")
        {
            UIColumn? column = (UIColumn)uiManager.Add(new UIColumn());
            column.SetPosition(new(10, 50));
            column.SetScale(new(30, 40));
            column.SetGap(2);

            column.AddChildren(new UIPanel());
            column.AddChildren(new UIPanel());
            column.AddChildren(new UIPanel());
            column.AddChildren(new UIPanel());
        }
    }
}
