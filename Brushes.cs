using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Direct2D1;

namespace DeepSpace
{
    class Brushes
    {
        Dictionary<string, Brush> brushes;
        public Brushes(Game game)
        {
            this.brushes = new Dictionary<string, Brush>();
            this.brushes.Add("white", new SolidColorBrush(game.target, Color.White));
            this.brushes.Add("orangered", new SolidColorBrush(game.target, Color.OrangeRed));
        }
        public Brush this[string name]
        {
            get
            {
                // This indexer is very simple, and just returns or sets
                // the corresponding element from the internal array.
                return brushes[name];
            }
        }
    }
}
