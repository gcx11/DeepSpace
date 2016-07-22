using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX;
using SharpDX.Direct2D1;

namespace DeepSpace
{
    class LevelGenerator
    {
        private static Random rnd = new Random();
        public static List<GameObject> GenerateLevel(Game game, uint planetCount)
        {
            List<GameObject> objects = new List<GameObject>();
            List<Planet> planets = new List<Planet>();
            List<Route> routes = new List<Route>(); 
            for (int i = 0; i < planetCount; i++)
            {
                float x = 400.0f + 300.0f * (float)Math.Cos(2 * i * Math.PI / planetCount) + rnd.NextFloat(-20, 20);
                float y = 300.0f + 150.0f * (float)Math.Sin(2 * i * Math.PI / planetCount) + rnd.NextFloat(-20, 20);
                planets.Add(new Planet(game, new Vector2(x, y), (uint)(20+rnd.Next(40)), (uint)rnd.Next(10)));
            }
            for (int i = 0; i < planets.Count; i++)
            {
                routes.Add(new Route(game, planets[i], planets[(i + 1) % planets.Count]));
            }
            routes.RemoveAt(rnd.Next(routes.Count));
            int choosen = rnd.Next(routes.Count);
            routes.Add(new Route(game, planets[choosen], planets[(choosen + 3) % planets.Count]));
            objects.AddRange(planets);
            objects.AddRange(routes);
            Console.WriteLine(objects.Count);
            return objects;
        }
    }
}
