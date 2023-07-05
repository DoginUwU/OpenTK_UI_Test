using System.Drawing;
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

            UIPanel panel1 = new();
            panel1.SetBackgroundImage(new Texture("teste.jpg"));
            UIPanel panel2 = new();
            panel2.SetBackgroundImage(new Texture("teste2.jpg"));
            UIPanel panel3 = new();
            panel3.SetBackgroundImage(new Texture("teste3.jpg"));

            column.AddChildren(panel1);
            column.AddChildren(panel2);
            column.AddChildren(panel3);
            column.AddChildren(new UIPanel());
        }
    }
}
