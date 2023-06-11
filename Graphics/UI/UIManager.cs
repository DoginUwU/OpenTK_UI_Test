﻿using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace Teste1.Graphics.UI
{
    internal class UIManager
    {
        public Window window;

        private readonly List<BaseUI> interfaces = new();

        private readonly ShaderProgram shaderProgram;
        private readonly VAO vao;
        private VBO? vbo;
        private IBO? ibo;

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

            if (ibo == null) return;

            vao.Bind();
            ibo.Bind();

            GL.DrawElements(PrimitiveType.Triangles, ibo.data.Count, DrawElementsType.UnsignedInt, 0);
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
            vbo?.Dispose();

            interfaces.ForEach(ui => ui.RenderOnce());

            List<Vector2> allVertices = new();
            List<int> allIndices = new();

            int indexCount = 0;

            interfaces.ForEach(ui =>
            {
                allVertices.AddRange(ui.vertices);

                ui.indices.ForEach(i => allIndices.Add(i + indexCount));

                indexCount += ui.vertices.Count;
            });

            vbo = new(allVertices);
            vbo.Bind();
            vao.Link(0, 2, vbo);

            ibo = new(allIndices);
        }

        public void Dispose()
        {
            vao.Dispose();
            vbo?.Dispose();
            ibo?.Dispose();

            interfaces.ForEach(ui => ui.Dispose());
        }
    }
}
