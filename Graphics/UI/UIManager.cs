using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using System.Drawing;

namespace Teste1.Graphics.UI
{
    internal class UIManager
    {
        public Window window;
        public readonly ShaderProgram shaderProgram;

        private readonly List<BaseUI> interfaces = new();

        private readonly VAO vao;
        private readonly IBO? ibo = default!;

        public UIManager(Window window)
        {
            this.window = window;

            _ = new Text();

            vao = new();
            GenVBO();

            shaderProgram = new("ui_shader.vert", "ui_shader.frag");
        }

        public BaseUI Add(BaseUI ui)
        {
            ui.InitUI(this);
            interfaces.Add(ui);

            GenVBO();

            return ui;
        }

        public void Render()
        {

            shaderProgram.Bind();

            Matrix4 view = window.camera.GetViewMatrix();
            Matrix4 projection = window.camera.GetProjectionMatrix();

            int projectionLocation = GL.GetUniformLocation(shaderProgram.ID, "projection");
            int viewLocation = GL.GetUniformLocation(shaderProgram.ID, "view");

            GL.UniformMatrix4(projectionLocation, false, ref projection);
            GL.UniformMatrix4(viewLocation, false, ref view);

            interfaces.ForEach(ui => ui.Render());
        }

        public void Update()
        {
            interfaces.ForEach(ui => ui.Update());
        }

        public void ReloadAll()
        {
            GenVBO();
        }

        private void GenVBO()
        {
            interfaces.ForEach(ui => ui.RenderOnce());
        }

        public void Dispose()
        {
            vao.Dispose();
            ibo?.Dispose();

            interfaces.ForEach(ui => ui.Dispose());
        }
    }
}
