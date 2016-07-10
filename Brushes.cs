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
            brushes.Add("white", new SolidColorBrush(game.target, Color.White));
            brushes.Add("orangered", new SolidColorBrush(game.target, Color.OrangeRed));
            brushes.Add("cyan", new SolidColorBrush(game.target, Color.Cyan));
        }
        public Brush this[string name]
        {
            get
            {
                return brushes[name];
            }
        }
    }
}
