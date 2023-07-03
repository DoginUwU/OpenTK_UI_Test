using Teste1.Graphics.UI;

namespace Teste1.Graphics.Scene
{
    internal abstract class Scene
    {
        public string name;
        public Window window;

        protected readonly UIManager uiManager;

        public Scene(Window window, string name)
        {
            this.window = window;
            this.name = name;

            uiManager = new(window);
        }

        public void UpdateRenderFrame()
        {
            uiManager.Render();
        }

        public void UpdateFrame()
        {
            uiManager.Update();
        }

        public void Refresh()
        {
            uiManager.ReloadAll();
        }
    }
}
