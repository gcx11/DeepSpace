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
        public float size;
        public string text;
        public int team;
        private ButtonRenderer buttonRenderer;
        public Button(Game game, Vector2 position, float size, int team): base(game)
        {
            this.position = position;
            this.size = size;
            this.team = team;
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
