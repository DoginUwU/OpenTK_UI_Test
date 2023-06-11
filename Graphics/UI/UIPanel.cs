

using OpenTK.Mathematics;

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

            indices = new()
            {
                0, 1, 2,
                2, 3, 0,
            };

            float left = -manager.window.width / 2f;
            float right = manager.window.width / 2f;
            float top = manager.window.height / 2f;
            float bottom = -manager.window.height / 2f;

            float xPos = left + bounds.X / 100f * (right - left);
            float yPos = top - bounds.Y / 100f * (top - bottom) - bounds.Height / 100f * (top - bottom);
            float width = bounds.Width / 100f * (right - left);
            float height = bounds.Height / 100f * (top - bottom);

            xPos += padding.X;
            yPos += padding.Y;
            width -= padding.X * 2;
            height -= padding.Y * 2;

            vertices = new()
            {
                new Vector2(xPos, yPos),
                new Vector2(xPos, yPos + height),
                new Vector2(xPos + width, yPos + height),
                new Vector2(xPos + width, yPos)
            };
        }

        public override void Update()
        {
            
        }
    }
}
