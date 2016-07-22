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
    class Game
    {
        public WindowRenderTarget target;
        public SharpDX.DirectWrite.Factory factoryWrite;
        public Brushes brushes;
        public Scene scene;
        public Game(WindowRenderTarget target)
        {
            this.target = target;
            this.factoryWrite = new SharpDX.DirectWrite.Factory();
            this.brushes = new Brushes(this);
            this.scene = new MenuScene(this);
        }

        public void Update(float delta) 
        {
            for (int i = 0; i < scene.objects.Count; i++)
            {
                scene.objects[i].Update(delta);
            }
        }

        public void OnMouseClick(int x, int y)
        {
            scene.OnMouseClick(x, y);
        }

        public void OnMouseMove(int x, int y)
        {
            scene.OnMouseMove(x, y);
        }

        public void Draw()
        {
            foreach (GameObject obj in scene.objects)
            {
                obj.Draw();
            }
        }
    }
}
