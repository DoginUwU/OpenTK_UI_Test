using Teste1.Game.Windows;

namespace Teste1.Game
{
    public class Game
    {
        public Game()
        {
            _ = new Engine();

            Engine.AddWindow(new GameWindow());
            Engine.AddWindow(new TestWindow());

            Engine.Init();
        }
    }
}
