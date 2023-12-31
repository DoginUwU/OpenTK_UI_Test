﻿using OpenTK.Graphics.OpenGL4;
using StbImageSharp;

namespace Teste1.Graphics
{
    internal class Texture
    {
        public int ID;
        public int Width;
        public int Height;

        public Texture(string file)
        {
            ID = GL.GenTexture();

            GL.ActiveTexture(TextureUnit.Texture0);
            Bind();

            // Texture parameters
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat); // Wrap texture (repeat)
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat); // Wrap texture (repeat)
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest); // If scale image,get nearest pixel, and not get bluring image
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest); // If scale image,get nearest pixel, and not get bluring image

            // StbImage.stbi_set_flip_vertically_on_load(1);

            string texturesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Textures");

            ImageResult texture = ImageResult.FromStream(File.OpenRead(Path.Combine(texturesDirectory, file)), ColorComponents.RedGreenBlueAlpha);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, texture.Width, texture.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, texture.Data);

            Width = texture.Width;
            Height = texture.Height;

            Unbind();
        }

        public void Bind()
        {
            GL.BindTexture(TextureTarget.Texture2D, ID);
        }

        public void Unbind()
        {
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }

        public void Dispose()
        {
            GL.DeleteTexture(ID);
        }
    }
}
