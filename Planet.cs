﻿using System;
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
                if (team != 0)
                {
                    population += 1;
                }
                acc = acc - 1;
            }
        }

        public void Invade(Ship invader)
        {
            if (invader.team == team)
            {
                population += invader.population;
            }
            else
            {
                if (population < invader.population)
                {
                    invader.population -= population;
                    population = invader.population;
                    team = invader.team;
                }
                else
                {
                    population -= invader.population;
                }
            }
        }

        public bool isClicked(int x, int y)
        {
            return (position.X - x) * (position.X - x) + (position.Y - y) * (position.Y - y) <= size*size;
        }

        public override void Draw()
        {
            planetRenderer.Draw();
        }
    }
}

