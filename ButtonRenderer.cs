using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX;
using SharpDX.Direct2D1;

namespace DeepSpace
{
    class ButtonRenderer: Renderer
    {
        private Button button;
        private Rectangle rect;
        public ButtonRenderer(Button button)
        {
            this.button = button;
        }

        public void Draw()
        {

        }
    }
}
