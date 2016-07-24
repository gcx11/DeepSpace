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
    class GameScene : Scene
    {
        public Planet selectedPlanet;
        public int playerTeam;

        public GameScene(Game game)
            : base(game)
        {
            this.selectedPlanet = null;
            /*
            this.objects = new List<GameObject> { new Planet(game, new Vector2(50.0f, 300.0f), 20, 0, 5), 
                                                  new Planet(game, new Vector2(200.0f, 40.0f), 15, 5, 42),
                                                  new Planet(game, new Vector2(500.0f, 100.0f), 56, 3, 100),
                                                  new Planet(game, new Vector2(700.0f, 200.0f), 30, 1, 300),
                                                  new Planet(game, new Vector2(300.0f, 400.0f), 30, 4, 215),

            };
            objects.Add(new Route(game, (Planet)objects[0], (Planet)objects[1]));
            objects.Add(new Route(game, (Planet)objects[1], (Planet)objects[2]));
            objects.Add(new Route(game, (Planet)objects[2], (Planet)objects[0]));
            objects.Add(new Route(game, (Planet)objects[2], (Planet)objects[3]));
            objects.Add(new Route(game, (Planet)objects[0], (Planet)objects[4]));
            */
            this.objects = LevelGenerator.GenerateLevel(game, 7);
            this.playerTeam = 1;
            objects.Add(new AI(game));
        }

        public override void OnMouseClick(int x, int y, MouseButtons mouseButtons)
        {
            foreach (Planet planet in objects.Where(obj => obj is Planet))
            {
                if (planet.IsClicked(x, y))
                {
                    if (selectedPlanet == null && (planet.team == playerTeam))
                    {
                        selectedPlanet = planet;
                    }
                    else
                    {
                        if (mouseButtons == MouseButtons.Left)
                        {
                            SendFleet(selectedPlanet, planet);
                        }
                        else if (mouseButtons == MouseButtons.Right)
                        {
                            foreach (Route route in objects.Where(obj => obj is Route))
                            {
                                if (((route.source == selectedPlanet) && (route.destination == planet)) ||
                                    ((route.source == planet) && (route.destination == selectedPlanet)))
                                {
                                    if (route.autoTransfer == false)
                                    {
                                        Console.WriteLine("Change");
                                        if (route.source != selectedPlanet)
                                        {
                                            Vector2 temp = route.start; route.start = route.end; route.end = temp;
                                        }
                                        route.autoTransfer = true;
                                        route.source = selectedPlanet;
                                        route.destination = planet;
                                    }
                                    else
                                    {
                                        route.autoTransfer = false;
                                    }
                                    break;
                                }
                            }
                        }
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