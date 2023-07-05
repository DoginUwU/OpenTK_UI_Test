

using OpenTK.Mathematics;
using System.ComponentModel;
using System.Drawing;

namespace Teste1.Graphics.UI
{
    internal class UIPanel : BaseUI
    {
        public UIPanel()
        {
        }

        public override void Start()
        {
            
        }

        public override void RenderOnce()
        {
            base.RenderOnce();
        }

        public override void Update()
        {
            base.Update();
        }

        protected override List<Vector2> CreateVertices()
        {
            RectangleF formatedBounds = GetBoundsSizeByPixel();

            return new()
            {
                new Vector2(formatedBounds.X, formatedBounds.Y),
                new Vector2(formatedBounds.X, formatedBounds.Y + formatedBounds.Height),
                new Vector2(formatedBounds.X + formatedBounds.Width, formatedBounds.Y + formatedBounds.Height),
                new Vector2(formatedBounds.X + formatedBounds.Width, formatedBounds.Y)
            };
        }

        protected override List<int> CreateIndices()
        {
            return new()
            {
                0, 1, 2,
                2, 3, 0,
            };
        }

        protected override List<Vector2> CreateTextureCoordinates()
        {
            if (backgroundImage == null) return new();

            switch (texturePositionMode)
            {
                case TexturePositionMode.SCALE_BY_RATIO:
                    float panelWidth = bounds.Width;
                    float panelHeight = bounds.Height;

                    float imageWidth = backgroundImage.Width;
                    float imageHeight = backgroundImage.Height;

                    float ratioX = panelWidth / imageWidth;
                    float ratioY = panelHeight / imageHeight;

                    float scale = Math.Min(ratioX, ratioY);
                    float scaledWidth = imageWidth * scale;
                    float scaledHeight = imageHeight * scale;

                    float offsetX = (panelWidth - scaledWidth) / 2f;
                    float offsetY = (panelHeight - scaledHeight) / 2f;

                    return new List<Vector2>
                    {
                        new Vector2(offsetX / panelWidth, 1 - offsetY / panelHeight),
                        new Vector2(offsetX / panelWidth, 1 - (offsetY + scaledHeight) / panelHeight),
                        new Vector2((offsetX + scaledWidth) / panelWidth, 1 - (offsetY + scaledHeight) / panelHeight),
                        new Vector2((offsetX + scaledWidth) / panelWidth, 1 - offsetY / panelHeight)
                    };

                default:
                    return new()
                    {
                        new Vector2(0, 1), // canto superior esquerdo
                        new Vector2(0, 0), // canto inferior esquerdo
                        new Vector2(1, 0), // canto inferior direito
                        new Vector2(1, 1)  // canto superior direito
                    };
            }
        }

        protected override RectangleF CreatePositionByScreenPixels()
        {
            if(manager == null) return new();

            RectangleF formatedBounds = GetBoundsSizeByPixel();

            float posX = formatedBounds.X + manager!.window.Width / 2f;
            float posY = manager!.window.Height / 2f - formatedBounds.Y - formatedBounds.Height;

            return new(posX, posY, formatedBounds.Width, formatedBounds.Height);
        }
    }
}
