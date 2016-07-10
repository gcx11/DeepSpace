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
        public List<GameObject> objects;
        public SharpDX.DirectWrite.Factory factoryWrite;
        public Brushes brushes;
        private Planet selectedPlanet;
        public Game(WindowRenderTarget target)
        {
            this.target = target;
            this.factoryWrite = new SharpDX.DirectWrite.Factory();
            this.brushes = new Brushes(this);
            this.objects = new List<GameObject> { new Planet(this, new Vector2(50.0f, 300.0f), 20, 0, 5), 
                                                  new Planet(this, new Vector2(200.0f, 40.0f), 15, 0, 42),
                                                  new Planet(this, new Vector2(500.0f, 100.0f), 56, 1, 389),
                                                  new Planet(this, new Vector2(700.0f, 200.0f), 30, 1, 167),
                                                  new Planet(this, new Vector2(300.0f, 400.0f), 30, 1, 215),

            };
            objects.Add(new Route(this, (Planet)objects[0], (Planet)objects[1]));
            objects.Add(new Route(this, (Planet)objects[1], (Planet)objects[2]));
            objects.Add(new Route(this, (Planet)objects[2], (Planet)objects[0]));
            objects.Add(new Route(this, (Planet)objects[2], (Planet)objects[3]));
            objects.Add(new Route(this, (Planet)objects[0], (Planet)objects[4]));
            objects.Add(new Ship(this, (Route)objects[6], (Planet)objects[2], (Planet)objects[1], 10, 0));
            Route temp = (Route)objects[5];
            temp.AddShip((Ship)objects[10]);
            //this.objects = new List<GameObject>();
            this.selectedPlanet = null;
        }

        public void Update(float delta) 
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Update(delta);
            }
        }

        public void onMouseClick(int x, int y)
        {
            foreach (Planet planet in objects.Where(obj => obj is Planet))
            {
                if (planet.isClicked(x, y)){
                    if (selectedPlanet == null)
                    {
                        selectedPlanet = planet;
                    }
                    else
                    {
                        Console.WriteLine("{0} {1}", selectedPlanet.population, planet.population);
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
                if ((route.source == from) && (route.destination == to)){
                    Ship ship = new Ship(this, route, from, to, 10, from.team);
                    objects.Add(ship);
                    route.AddShip(ship);
                    break;
                }
                else if ((route.source == to) && (route.destination == from)){
                    Ship ship = new Ship(this, route, from, to, 10, from.team);
                    objects.Add(ship);
                    route.AddShip(ship);
                    break;
                }
            }
            //objects.Add(new Ship(this, route, from, to, 10, from.team));
        }

        public void Draw()
        {
            foreach (GameObject obj in objects)
            {
                obj.Draw();
            }
        }
    }
}
