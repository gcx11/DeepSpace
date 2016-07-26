using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX;
using SharpDX.Direct2D1;

namespace DeepSpace
{
    class LevelLoader
    {
        public static List<GameObject> LoadLevel(Game game, int level)
        {
            List<Planet> planets = new List<Planet>();
            List<Route> routes = new List<Route>();
            List<GameObject> objects = new List<GameObject>();
            switch (level)
            {
                case 1:
                    planets = new List<Planet>{new Planet(game, new Vector2(100.0f, 300.0f), 40, 1, 20),
                        new Planet(game, new Vector2(250.0f, 200.0f), 40, 10), new Planet(game, new Vector2(400.0f, 400.0f), 40, 10),
                        new Planet(game, new Vector2(550.0f, 100.0f), 40, 30), new Planet(game, new Vector2(700.0f, 500.0f), 40, 2, 10)};
                    routes = new List<Route> { new Route(game, planets[0], planets[1]), new Route(game, planets[1], planets[2]),
                    new Route(game, planets[2], planets[3]), new Route(game, planets[3], planets[4])};
                    objects = new List<GameObject>{new Text(game, new Vector2(100.0f, 100.0f), "Be quick", 30.0f)};
                    break;
                case 2:
                    planets = new List<Planet> { new Planet(game, new Vector2(400.0f, 120.0f), 40, 1, 10),
                    new Planet(game, new Vector2(200.0f, 400.0f), 40, 2, 10), new Planet(game, new Vector2(600.0f, 400.0f), 40, 3, 10),
                    new Planet(game, new Vector2(400.0f, 300.0f), 70, 5)};
                    routes = new List<Route> { new Route(game, planets[0], planets[3]), new Route(game, planets[1], planets[3]),
                    new Route(game, planets[2], planets[3]), new Route(game, planets[0], planets[1]), 
                    new Route(game, planets[0], planets[2]), new Route(game, planets[1], planets[2])};
                    objects = new List<GameObject> {new Text(game, new Vector2(270.0f, 450.0f), "Bigger grows faster", 30.0f)};
                    break;
                case 3:
                    planets = new List<Planet>{new Planet(game, new Vector2(300.0f, 200.0f), 40, 1, 10),
                        new Planet(game, new Vector2(300.0f, 400.0f), 40, 10), new Planet(game, new Vector2(500.0f, 200.0f), 40, 10),
                        new Planet(game, new Vector2(500.0f, 400.0f), 40, 2, 10)};
                    routes = new List<Route> { new Route(game, planets[0], planets[1]), new Route(game, planets[0], planets[2]),
                    new Route(game, planets[1], planets[3]), new Route(game, planets[2], planets[3])};
                    objects = new List<GameObject> { new Text(game, new Vector2(340.0f, 80.0f), "Be patient", 30.0f) };
                    break;
                case 4:
                    planets = new List<Planet> { new Planet(game, new Vector2(250.0f, 170.0f), 40, 10),
                        new Planet(game, new Vector2(150.0f, 300.0f), 60, 10), new Planet(game, new Vector2(350.0f, 300.0f), 30, 8), 
                        new Planet(game, new Vector2(500.0f, 400.0f), 40, 5, 7), new Planet(game, new Vector2(200.0f, 500.0f), 40, 1, 10),
                        new Planet(game, new Vector2(500.0f, 100.0f), 30, 4, 60), new Planet(game, new Vector2(600.0f, 250.0f), 20, 9)};
                    routes = new List<Route> { new Route(game, planets[0], planets[1]), new Route(game, planets[0], planets[1]),
                    new Route(game, planets[1], planets[2]), new Route(game, planets[2], planets[0]), 
                    new Route(game, planets[1], planets[4]), new Route(game, planets[2], planets[3]),
                    new Route(game, planets[3], planets[6]), new Route(game, planets[6], planets[5])};
                    objects = new List<GameObject> { new Text(game, new Vector2(100.0f, 60.0f), "Right click destination", 30.0f),
                    new Text(game, new Vector2(320.0f, 470.0f), "to enable autotransfer", 30.0f)};
                    break;
                default:
                    break;
            }
            objects.AddRange(planets);
            objects.AddRange(routes);
            return objects;
        }
    }
}
