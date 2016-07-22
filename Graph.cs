using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepSpace
{
    class Graph
    {
        private Game game;
        private Dictionary<Planet, List<Planet>> graph;
        public Graph(Game game)
        {
            this.game = game;
            this.graph = null;
            
        }
        public Dictionary<Planet, List<Planet>> Data
        {
            get
            {
                if (graph == null)
                {
                    graph = new Dictionary<Planet, List<Planet>>();
                    foreach (Route route in game.scene.objects.Where(obj => obj is Route))
                    {
                        if (graph.ContainsKey(route.source))
                        {
                            graph[route.source].Add(route.destination);
                        }
                        else
                        {
                            graph.Add(route.source, new List<Planet>() { route.destination });
                        }
                        if (graph.ContainsKey(route.destination))
                        {
                            graph[route.destination].Add(route.source);
                        }
                        else
                        {
                            graph.Add(route.destination, new List<Planet>() { route.source });
                        }
                    }
                }
                return graph;
            }
        }
    }
}
