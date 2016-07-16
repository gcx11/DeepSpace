using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX;
using SharpDX.Direct2D1;

namespace DeepSpace
{
    class Scene
    {
        public List<GameObject> objects;
        public Game game;

        public Scene(Game game)
        {
            this.game = game;
            this.objects = new List<GameObject>();
        }

        public virtual void OnMouseClick(int x, int y){
        }
    }

    class GameScene : Scene
    {
        public Planet selectedPlanet;

        public GameScene(Game game): base(game)
        {
            this.selectedPlanet = null;
            this.objects = new List<GameObject> { new Planet(game, new Vector2(50.0f, 300.0f), 20, 0, 5), 
                                                  new Planet(game, new Vector2(200.0f, 40.0f), 15, 0, 42),
                                                  new Planet(game, new Vector2(500.0f, 100.0f), 56, 2, 289),
                                                  new Planet(game, new Vector2(700.0f, 200.0f), 30, 1, 167),
                                                  new Planet(game, new Vector2(300.0f, 400.0f), 30, 1, 215),

            };
            objects.Add(new Route(game, (Planet)objects[0], (Planet)objects[1]));
            objects.Add(new Route(game, (Planet)objects[1], (Planet)objects[2]));
            objects.Add(new Route(game, (Planet)objects[2], (Planet)objects[0]));
            objects.Add(new Route(game, (Planet)objects[2], (Planet)objects[3]));
            objects.Add(new Route(game, (Planet)objects[0], (Planet)objects[4]));
            objects.Add(new Ship(game, (Route)objects[6], (Planet)objects[2], (Planet)objects[1], 10, 0));
            Route temp = (Route)objects[5];
            temp.AddShip((Ship)objects[10]);
        }

        public override void OnMouseClick(int x, int y)
        {
            foreach (Planet planet in objects.Where(obj => obj is Planet))
            {
                if (planet.isClicked(x, y))
                {
                    if (selectedPlanet == null)
                    {
                        selectedPlanet = planet;
                    }
                    else
                    {
                        SendFleet(selectedPlanet, planet);
                        selectedPlanet = null;
                    }
                    break;
                }
            }
        }

        public void SendFleet(Planet from, Planet to)
        {
            foreach (Route route in objects.Where(obj => obj is Route))
            {
                if (((route.source == from) && (route.destination == to)) || ((route.source == to) && (route.destination == from)))
                {
                    if (from.population > 1)
                    {
                        Ship ship = new Ship(game, route, from, to, from.population / 2, from.team);
                        objects.Add(ship);
                        route.AddShip(ship);
                        from.population /= 2;
                        break;
                    }
                }
            }
        }
    }
}
