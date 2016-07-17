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
        Brush[] brushes;
        public Brushes(Game game)
        {
            this.brushes = new Brush[]{new SolidColorBrush(game.target, Color.White), new SolidColorBrush(game.target, Color.OrangeRed), 
                                       new SolidColorBrush(game.target, Color.Cyan), new SolidColorBrush(game.target, Color.LimeGreen),
                                       new SolidColorBrush(game.target, Color.Yellow), new SolidColorBrush(game.target, Color.Magenta)};
        }
        public Brush this[int id]
        {
            get
            {
                return brushes[id];
            }
        }
        
    }
}
