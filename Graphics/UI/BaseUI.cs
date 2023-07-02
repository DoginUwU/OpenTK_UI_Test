﻿using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Drawing;
using Teste1.Graphics.Utils;

namespace Teste1.Graphics.UI
{
    internal abstract class BaseUI
    {
        public RectangleF bounds;

        public List<Vector2> vertices = default!;
        public List<int> indices = default!;

        public event Action? MouseDown;
        public event Action? MouseUp;
        public event Action? MouseEnter;
        public event Action? MouseLeave;
        
        public List<Vector4> BackgroundColors
        {
            get
            {
                return this.CreateColors();
            }
        }

        protected UIManager? manager;
        protected Vector4 padding = default!;
        protected RectangleF boundsByScreen;

        private Color backgroundColor = Color.Black;
        private bool isButtonDown = false;
        private bool isMouseEnter = false;

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

            manager?.ReloadAll();
        }

        public void AddPadding(Vector4 padding)
        {
            this.padding = padding;

            manager?.ReloadAll();
        }

        public void SetPosition(Vector2 position)
        {
            bounds.X = (int)position.X;
            bounds.Y = (int)position.Y;

            manager?.ReloadAll();
        }

        public void SetScale(Vector2 scale)
        {
            bounds.Width = (int)scale.X;
            bounds.Height = (int)scale.Y;

            manager?.ReloadAll();
        }

        public void SetBackgroundColor(Color color)
        {
            backgroundColor = color;

            manager?.ReloadAll();
        }

        public abstract void Start();

        public virtual void Update()
        {
            UpdateEvents();
        }

        private void UpdateEvents()
        {
            if (manager == null) return;

            MouseState mouse = manager.window.OpenGLWindow().MouseState;
            bool isMouseInside = boundsByScreen.Contains((int)mouse.Position.X, (int)mouse.Position.Y);

            if (isMouseInside)
            {
                if (!isMouseEnter)
                {
                    MouseEnter?.Invoke();
                    isMouseEnter = true;
                }

                if (mouse.IsButtonDown(MouseButton.Left) && !isButtonDown)
                {
                    MouseDown?.Invoke();
                    isButtonDown = true;
                }

                if (!mouse.IsButtonDown(MouseButton.Left) && isButtonDown)
                {
                    MouseUp?.Invoke();
                    isButtonDown = false;
                }
            }
            else
            {
                if (isMouseEnter)
                {
                    MouseLeave?.Invoke();
                    isMouseEnter = false;
                }
            }
        }

        public virtual void RenderOnce()
        {
            if (manager == null)
            {
                throw new Exception("Invalid UI Instance, Did you create a UI Componente with UIManager?");
            }

            vertices = CreateVertices();
            indices = CreateIndices();
            boundsByScreen = CreatePositionByScreenPixels();
        }

        public virtual void Dispose() { }

        protected abstract List<Vector2> CreateVertices();
        protected abstract List<int> CreateIndices();
        protected abstract RectangleF CreatePositionByScreenPixels();

        protected List<Vector4> CreateColors()
        {
            List<Vector4> colors = new();

            for (int i = 0; i < vertices.Count; i++)
            {
                colors.Add(Converter.ColorToVec4(this.backgroundColor));
            }

            return colors;
        }

        protected RectangleF GetBoundsSizeByPixel()
        {
            if (manager == null) return new();

            float left = -manager.window.Width / 2f;
            float right = manager.window.Width / 2f;
            float top = manager.window.Height / 2f;
            float bottom = -manager.window.Height / 2f;

            float xPos = left + bounds.X / 100f * (right - left);
            float yPos = top - bounds.Y / 100f * (top - bottom) - bounds.Height / 100f * (top - bottom);
            float width = bounds.Width / 100f * (right - left);
            float height = bounds.Height / 100f * (top - bottom);

            xPos += padding.X;
            yPos += padding.Y;
            width -= padding.X * 2;
            height -= padding.Y * 2;

            return new(xPos, yPos, width, height);
        }
    }
}
