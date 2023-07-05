namespace Teste1.Graphics.Scene
{
    internal class SceneManager
    {
        public Scene? activeScene;
        public Window window;

        private readonly List<Scene> sceneList = new();

        public SceneManager(Window window)
        {
            this.window = window;
        }

        public void AddScene(Scene scene)
        {
            sceneList.Add(scene);
        }

        public void RemoveScene(Scene scene)
        {
            sceneList.Remove(scene);
        }

        public void SetActiveScene(string name)
        {
            Scene? findedScene = sceneList.Find(x => x.name == name);

            if (findedScene == null)
            {
                throw new InvalidOperationException();
            }

            activeScene = findedScene;
        }

        public void UpdateRenderFrame()
        {
            activeScene?.UpdateRenderFrame();
        }

        public void UpdateFrame()
        {
            activeScene?.UpdateFrame();
        }

        public void Refresh()
        {
            activeScene?.Refresh();
        }
    }
}
