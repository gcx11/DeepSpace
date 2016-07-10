using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Direct2D1;

namespace DeepSpace
{
    class Route: GameObject
    {
        public Planet source, destination;
        public Vector2 start, end;
        private List<Ship> ships;
        private RouteRenderer routeRenderer;

        public Route(Game game, Planet source, Planet destination): base(game)
        {
            this.source = source;
            this.destination = destination;
            this.ships = new List<Ship>();
            double angle = Math.Atan2(source.position.Y-destination.position.Y, source.position.X-destination.position.X);
            this.start = source.position - source.size * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            this.end = destination.position + destination.size * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            this.routeRenderer = new RouteRenderer(this);
        }

        public override void Update(float delta){
            for (int i = 0; i < ships.Count; i++)
            {
                ships[i].Update(delta);
                if (checkPlanetCollision(ships[i])){
                    ships[i].destination.Invade(ships[i]);
                    /*
                    if (ships[i].team == ships[i].destination.team)
                    {
                        ships[i].destination.population += ships[i].population;
                    }
                    else
                    {
                        ships[i].destination.population -= ships[i].population;
                    }
                     * */
                    game.objects.Remove(ships[i]);
                    ships.Remove(ships[i]);
                    Console.WriteLine("INVASION!!!");
                }
            }
        }

        public void AddShip(Ship ship)
        {
            ships.Add(ship);
        }

        private bool checkPlanetCollision(Ship ship)
        {
            float distanceFromPlanet = (ship.destination.position.X - ship.position.X) * (ship.destination.position.X - ship.position.X) +
                (ship.destination.position.Y - ship.position.Y) * (ship.destination.position.Y - ship.position.Y);
            return (distanceFromPlanet <= ship.destination.size * ship.destination.size);
        }

        public override void Draw()
        {
            routeRenderer.Draw();
            foreach (Ship ship in ships)
            {
                ship.Draw();
            }
        }
    }
}
