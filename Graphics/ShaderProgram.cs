using OpenTK.Graphics.OpenGL4;

namespace Teste1.Graphics
{
    internal class ShaderProgram
    {
        public int ID;

        public ShaderProgram(string vertexPath, string fragmentPath)
        {
            // Create shader program
            ID = GL.CreateProgram();

            int vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, LoadShaderSource(vertexPath));
            GL.CompileShader(vertexShader);

            int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, LoadShaderSource(fragmentPath));
            GL.CompileShader(fragmentShader);

            GL.AttachShader(ID, vertexShader);
            GL.AttachShader(ID, fragmentShader);

            GL.LinkProgram(ID);

            // Delete shaders
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);
        }

        public void Bind()
        {
            GL.UseProgram(ID);
        }

        public void Unbind()
        {
            GL.UseProgram(0);
        }

        public void Dispose()
        {
            GL.DeleteShader(ID);
        }

        public static string LoadShaderSource(string filePath)
        {
            string shaderDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Shaders");

            string shaderSource = "";

            try
            {
                using StreamReader reader = new(Path.Combine(shaderDirectory, filePath));
                shaderSource = reader.ReadToEnd();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to load shader source file: " + e.Message);
            }

            return shaderSource;
        }
    }
}
