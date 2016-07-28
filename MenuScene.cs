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
    class MenuScene: Scene
    {
        public MenuScene(Game game): base(game)
        {
            Button levelMode = new Button(game, new Vector2(200.0f, 150.0f), 70.0f, 1);
            levelMode.buttonClickedEvent += delegate{
                game.level = 1;
                game.scene.Dispose();
                game.scene = new GameScene(game);
            };
            Button survivalMode = new Button(game, new Vector2(510.0f, 250.0f), 80.0f, 3);
            survivalMode.buttonClickedEvent += delegate{
                game.level = 0;
                game.scene.Dispose();
                game.scene = new GameScene(game);
            };
            Button exitButton = new Button(game, new Vector2(270.0f, 350.0f), 40.0f, 2);
            exitButton.buttonClickedEvent += delegate{
                game.scene.Dispose();
                game.brushes.Dispose();
                Application.Exit();
            };
            this.objects = new List<GameObject>() {levelMode, survivalMode, exitButton,
                new Text(game, new Vector2(150.0f, 140.0f), "Level mode"),
                new Text(game, new Vector2(450.0f, 240.0f), "Survival mode"),
                new Text(game, new Vector2(250.0f, 340.0f), "Exit")};
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
