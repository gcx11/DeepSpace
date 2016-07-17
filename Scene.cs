using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX;
using SharpDX.Direct2D1;

namespace DeepSpace
{
    class Scene
    {
        public List<GameObject> objects;
        public Game game;

        public Scene(Game game)
        {
            this.game = game;
            this.objects = new List<GameObject>();
        }

        public virtual void OnMouseClick(int x, int y){
        }

        public virtual void OnMouseMove(int x, int y)
        {

        }
    }

}
