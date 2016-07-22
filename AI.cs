using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSpace
{
    class AI: GameObject
    {
        private Graph graph;
        private float acc;
        public AI(Game game)
            : base(game)
        {
            this.graph = new Graph(game);
        }

        public override void Update(float delta)
        {
            acc += delta;
            if (acc > 5)
            {
                GameScene gamescene = (GameScene)game.scene;
                foreach (KeyValuePair<Planet, List<Planet>> kvpair in graph.Data)
                {
                    if ((kvpair.Key.team != gamescene.playerTeam) && (kvpair.Key.team != 0))
                    {
                        var planets = kvpair.Value.Where(p => p.team != kvpair.Key.team).OrderByDescending(p => p.population);
                        if (planets.Count() > 0)
                        {
                            gamescene.SendFleet(kvpair.Key, planets.First());
                        }
                        else
                        {
                            gamescene.SendFleet(kvpair.Key, kvpair.Value.OrderByDescending(p => p.population).First());
                        }
                    }
                }
                acc -= 5;
            }
        }
    }
}
