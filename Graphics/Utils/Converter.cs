using OpenTK.Mathematics;
using System.Drawing;

namespace Teste1.Graphics.Utils
{
    struct Converter
    {
        public static Vector4 ColorToVec4(Color color)
        {
            return new Vector4(
                   color.R / 255f,
                   color.G / 255f,
                   color.B / 255f,
                   color.A / 255f
               );
        }
    }
}
