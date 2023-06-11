using OpenTK.Graphics.OpenGL4;
using FreeTypeSharp.Native;
using static FreeTypeSharp.Native.FT;
using System.Runtime.InteropServices;
using System.Numerics;

namespace Teste1.Graphics
{
    internal class Text
    {
        private static Text instance = default!;

        private readonly IntPtr library;
        private readonly IntPtr face;
        private List<TextCharacter> characters = new();

        public Text()
        {
            if (instance != null) return;

            instance = this;

            FT_Error error;

            error = FT_Init_FreeType(out library);
            error = FT_New_Face(library, "../../../Assets/Fonts/inter.ttf", 0, out face);

            if (error != FT_Error.FT_Err_Ok)
            {
                throw new Exception(error.ToString());
            }

            GenPixels();

            FT_Done_Face(face);
            FT_Done_FreeType(library);
        }

        private void GenPixels()
        {
            FT_Set_Pixel_Sizes(face, 0, 24);

            GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1);

            for (uint c = 0; c < 128; c++)
            {
                FT_Load_Char(face, c, FT_LOAD_RENDER);

                int texture = GL.GenTexture();

                GL.BindTexture(TextureTarget.Texture2D, texture);

                IntPtr glyphPtr = IntPtr.Add(face, (int)Marshal.OffsetOf<FT_FaceRec>("glyph"));
                FT_GlyphSlotRec slot = Marshal.PtrToStructure<FT_GlyphSlotRec>(glyphPtr);
                FT_Bitmap bitmap = slot.bitmap;

                byte[] imageData = new byte[bitmap.width * bitmap.rows];
                Marshal.Copy(bitmap.buffer, imageData, 0, imageData.Length);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, (int)bitmap.width, (int)bitmap.rows, 0, PixelFormat.Red, PixelType.UnsignedByte, imageData);

                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

                GL.BindTexture(TextureTarget.Texture2D, 0);

                TextCharacter character = new()
                {
                    textureId = 0,
                    advance = (uint)slot.advance.x,
                    size = new(slot.bitmap.width, bitmap.rows),
                    bearing = new(slot.bitmap_left, slot.bitmap_top)
                };

                characters.Add(character);
            }
        }

        public static TextCharacter GetCharacter(int slot)
        {
            return instance.characters[slot];
        }
    }

    public struct TextCharacter
    {
        public uint textureId;
        public uint advance;
        public Vector2 size;
        public Vector2 bearing;
    }
}
