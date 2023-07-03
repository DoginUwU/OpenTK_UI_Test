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
            // sceneList.ForEach(scene => scene.UpdateRenderFrame());
            activeScene?.UpdateRenderFrame();
        }

        public void UpdateFrame()
        {
            // sceneList.ForEach(scene => scene.UpdateFrame());
            activeScene?.UpdateFrame();
        }

        public void Refresh()
        {
            // sceneList.ForEach(scene => scene.Refresh());
            activeScene?.Refresh();
        }
    }
}
