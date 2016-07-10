using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Direct2D1;

namespace DeepSpace
{
    class Star: GameObject
    {
        private Vector2 position;
        private float size;
        private Ellipse ellipse;
        public Star(Game game, Vector2 position, float size): base(game)
        {
            this.position = position;
            this.size = size;
            this.ellipse = new Ellipse(position, size, size);
        }

        public override void Update(float delta){
        }

        public override void Draw()
        {
            
            this.game.target.DrawEllipse(ellipse,
                new SharpDX.Direct2D1.SolidColorBrush(this.game.target, SharpDX.Color.White));
            
        }
    }
}
