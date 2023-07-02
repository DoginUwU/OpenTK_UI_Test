

using OpenTK.Mathematics;
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

        protected override RectangleF CreatePositionByScreenPixels()
        {
            if(manager == null) return new();

            RectangleF formatedBounds = GetBoundsSizeByPixel();

            float posX = formatedBounds.X + manager.window.width / 2f;
            float posY = formatedBounds.Y + manager.window.height / 2f;
            float width = (float)formatedBounds.Width - posX;
            float height = (float)formatedBounds.Height - posY;

            return new(posX, posY, width, height);
        }
    }
}
