using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX;
using SharpDX.Direct2D1;

namespace DeepSpace
{
    class Planet : GameObject
    {
        public Vector2 position;
        public uint population, size;
        public int team;
        private float acc;
        private PlanetRenderer planetRenderer;

        public Planet(Game game, Vector2 position, uint size, uint population)
            : base(game)
        {
            this.position = position;
            this.size = size;
            this.population = 0;
            this.acc = 0;
            this.planetRenderer = new PlanetRenderer(this);
        }

        public Planet(Game game, Vector2 position, uint size, int team, uint population)
            : base(game)
        {
            this.position = position;
            this.size = size;
            this.population = population;
            this.team = team;
            this.acc = 0;
            this.planetRenderer = new PlanetRenderer(this);
        }

        public override void Update(float delta)
        {
            acc += delta;
            if (acc > 1)
            {
                population += 1;
                acc = acc - 1;
                //team = 1;
            }
        }

        public override void Draw()
        {
            planetRenderer.Draw();
        }
    }
}

