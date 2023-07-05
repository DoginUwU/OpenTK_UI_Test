using OpenTK.Graphics.OpenGL4;

namespace Teste1.Graphics
{
    internal class VAO
    {
        public int ID;
        
        private readonly List<VBO> vBOs = new();

        public VAO()
        {
            ID = GL.GenVertexArray();
        }

        public void Link(int location, int size, VBO vbo)
        {
            vBOs.Add(vbo);

            Bind();
            vbo.Bind();

            GL.VertexAttribPointer(location, size, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexAttribArray(location);

            Unbind();
        }

        public void Bind()
        {
            GL.BindVertexArray(ID);
        }

        public void Unbind()
        {
            vBOs.ForEach(vbo => vbo.Unbind());
            GL.BindVertexArray(0);
        }

        public void Dispose()
        {
            vBOs.ForEach(vbo => vbo.Dispose());
            vBOs.Clear();

            GL.DeleteVertexArray(ID);
        }
    }
}
