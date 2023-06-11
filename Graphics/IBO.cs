using OpenTK.Graphics.OpenGL4;

namespace Teste1.Graphics
{
    internal class IBO
    {
        public int ID;
        public List<int> data;

        public IBO(List<int> data)
        {
            ID = GL.GenBuffer();
            this.data = data;

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ID);
            GL.BufferData(BufferTarget.ElementArrayBuffer, data.Count * sizeof(int), data.ToArray(), BufferUsageHint.StaticDraw);
        }

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ID);
        }

        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        public void Dispose()
        {
            GL.DeleteBuffer(ID);
        }
    }
}
