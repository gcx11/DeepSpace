using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX;
using SharpDX.Direct2D1;

namespace DeepSpace
{
    class Button: GameObject
    {
        public Vector2 position;
        public float width, height;
        private ButtonRenderer buttonRenderer;
        public Button(Game game, Vector2 position, float width, float height): base(game)
        {
            this.position = position;
            this.width = width;
            this.height = height;
            this.buttonRenderer = new ButtonRenderer(this);
        }

        public override void Update(float delta)
        {
            
        }

        public override void Draw()
        {
            buttonRenderer.Draw();
        }
    }
}
