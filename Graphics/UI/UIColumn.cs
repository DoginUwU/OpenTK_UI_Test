using OpenTK.Mathematics;
using System.Drawing;

namespace Teste1.Graphics.UI
{
    internal class UIColumn : BaseUI
    {
        public List<BaseUI> childrens = new();
        public Mode currentMode = Mode.SameSize;

        private float gap = 0;

        public enum Mode {
            SameSize,
        }

        public override void Start()
        {

        }

        public override void Update()
        {
            base.Update();
        }

        private void FixPositions()
        {
            float width = bounds.Width;
            float height = bounds.Height;

            float currentHeightPerChild = 0;

            switch (currentMode)
            {
                case Mode.SameSize:
                    currentHeightPerChild = height / childrens.Count;
                    break;
            }

            int currentIndex = 0;

            foreach (BaseUI child in childrens)
            {
                float childPosX = bounds.X;
                float childPosY = (currentIndex * currentHeightPerChild) + bounds.Y;
                float childWidth = width;
                float childHeight = currentHeightPerChild;

                childPosY += gap;
                childHeight -= gap;

                child.SetPosition(new(childPosX, childPosY));
                child.SetScale(new(childWidth, childHeight));

                currentIndex++;
            }
        }

        public void AddChildren(BaseUI child)
        {
            childrens.Add(child);
            manager?.Add(child);

            FixPositions();
        }

        public void SetGap(float gap)
        {
            this.gap = gap;
        }

        protected override List<Vector2> CreateVertices()
        {
            return new();
        }

        protected override List<int> CreateIndices()
        {
            return new();
        }

        protected override RectangleF CreatePositionByScreenPixels()
        {
            return new();
        }
    }
}
