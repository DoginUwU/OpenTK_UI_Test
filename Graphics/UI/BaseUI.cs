using OpenTK.Mathematics;
using System.Drawing;

namespace Teste1.Graphics.UI
{
    internal abstract class BaseUI
    {
        public Rectangle bounds;

        public List<Vector2> vertices = new();
        public List<int> indices = new();

        protected UIManager manager = default!;
        protected Vector4 padding = new();

        protected BaseUI() 
        {
            bounds = new(0, 0, 0, 0);
        }

        public void InitUI(UIManager manager)
        {
            this.manager = manager;

            Start();
        }

        public void AddPadding(Vector2 padding)
        {
            this.padding = new(padding.X, padding.Y, padding.X, padding.Y);

            manager.ReloadAll();
        }

        public void AddPadding(Vector4 padding)
        {
            this.padding = padding;

            manager.ReloadAll();
        }

        public void SetPosition(Vector2 position)
        {
            bounds.X = (int)position.X;
            bounds.Y = (int)position.Y;

            manager.ReloadAll();
        }

        public void SetScale(Vector2 scale)
        {
            bounds.Width = (int)scale.X;
            bounds.Height = (int)scale.Y;

            manager.ReloadAll();
        }

        public abstract void Start();

        public abstract void Update();

        public virtual void RenderOnce()
        {
            if (manager == null)
            {
                throw new Exception("Invalid UI Instance, Do you create a UI Componente with UIManager?");
            }
        }

        public virtual void Dispose() { }
    }
}
