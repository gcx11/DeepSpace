using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Direct2D1;

namespace DeepSpace
{
    class RouteRenderer
    {
        private Route route;
        private Brush brush;
        public RouteRenderer(Route route)
        {
            this.route = route;
            this.brush = route.game.brushes[0];
        }

        public void Draw()
        {
            route.game.target.DrawLine(route.start, route.end, brush);
        }
    }
}
