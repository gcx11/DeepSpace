using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Direct2D1;

namespace DeepSpace
{
    class RouteRenderer: Renderer
    {
        private Route route;
        private Brush brush;
        private int team;
        public RouteRenderer(Route route)
        {
            this.route = route;
            this.team = 0;
            this.brush = route.game.brushes[team];
        }

        public void Draw()
        {
            if (route.source.team == route.destination.team)
            {
                team = route.source.team;
            }
            else
            {
                team = 0;
            }
            brush = route.game.brushes[team];
            StrokeStyleProperties props = new StrokeStyleProperties();
            props.DashOffset = 0.1f;
            props.DashStyle = DashStyle.Dash;
            props.StartCap = CapStyle.Flat;
            props.EndCap = CapStyle.Flat;
            brush.Opacity = 0.7f;
            route.game.target.DrawLine(route.start, route.end, brush, 1.0f, new StrokeStyle(route.game.target.Factory, props));
            brush.Opacity = 1.0f;

        }
    }
}
