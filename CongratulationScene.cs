using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SharpDX;
using SharpDX.Direct2D1;

namespace DeepSpace
{
    class CongratulationScene: Scene
    {
        public CongratulationScene(Game game): base(game)
        {
            Button menuButton = new Button(game, new Vector2(400.0f, 300.0f), 100.0f, 2);
            menuButton.buttonClickedEvent += delegate{
                game.scene = new MenuScene(game);
            };
            this.objects = new List<GameObject>() {menuButton, 
                new Text(game, new Vector2(300.0f, 100.0f), "Congratulation!", 30.0f), new Text(game, new Vector2(340.0f, 290.0f), "Back to menu")};
        }

        public override void OnMouseClick(int x, int y, MouseButtons mouseButtons)
        {
            foreach (Button button in objects.Where(obj => obj is Button))
            {
                if (button.IsClicked(x, y))
                {
                    button.OnClicked();
                }
            }
        }
    }
}
