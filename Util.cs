using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;

namespace DeepSpace
{
    class Util
    {
        

        public static void DrawFilledCircle(Game game, Vector2 center, float radius, Color color)
        {
            game.target.DrawEllipse(new Ellipse(center, radius, radius),
                new SharpDX.Direct2D1.SolidColorBrush(game.target, color));
            game.target.FillEllipse(new Ellipse(center, radius, radius),
                new SharpDX.Direct2D1.SolidColorBrush(game.target, color));
        }

        public static void DrawText(Game game, RectangleF textRectangle, string text, string fontName, float fontSize, Color color)
        {
            TextFormat textFormat = new TextFormat(game.factoryWrite, fontName, fontSize);
            game.target.DrawText(text, textFormat, textRectangle, new SolidColorBrush(game.target, color));
            textFormat.Dispose();
        }
    }
}
