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
                sendFleets();
                acc -= 5;
            }
        }

        private void sendFleets()
        {
            GameScene gamescene = (GameScene)game.scene;
            foreach (KeyValuePair<Planet, List<Planet>> kvpair in graph.Data)
            {
                if ((kvpair.Key.team != gamescene.playerTeam) && (kvpair.Key.team != 0))
                {

                    var enemyPlanets = kvpair.Value.Where(p => p.team != kvpair.Key.team).OrderByDescending(p => p.population);
                    if (enemyPlanets.Count() > 0)
                    {
                        gamescene.SendFleet(kvpair.Key, enemyPlanets.Last());
                        continue;
                    }
                    var emptyPlanets = kvpair.Value.Where(p => p.team == 0).OrderByDescending(p => p.size);
                    if (emptyPlanets.Count() > 0)
                    {
                        gamescene.SendFleet(kvpair.Key, emptyPlanets.First());
                        continue;
                    }
                    gamescene.SendFleet(kvpair.Key, kvpair.Value.OrderByDescending(p => p.population).Last());
                }
            }
        }
    }
}
