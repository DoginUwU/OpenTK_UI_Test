using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Teste1.Graphics
{
    internal class VBO
    {
        public int ID;

        public VBO(List<Vector4> data)
        {
            ID = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Count * Vector4.SizeInBytes, data.ToArray(), BufferUsageHint.StaticDraw);
        }

        public VBO(List<Vector3> data)
        {
            ID = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Count * Vector3.SizeInBytes, data.ToArray(), BufferUsageHint.StaticDraw);
        }

        public VBO(List<Vector2> data)
        {
            ID = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Count * Vector2.SizeInBytes, data.ToArray(), BufferUsageHint.StaticDraw);
        }

        public VBO(float[] data)
        {
            ID = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
            GL.BufferData(BufferTarget.ArrayBuffer, data.Length * sizeof(float), data.ToArray(), BufferUsageHint.StaticDraw);
        }

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
        }

        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public void Dispose()
        {
            GL.DeleteBuffer(ID);
        }
    }
}
