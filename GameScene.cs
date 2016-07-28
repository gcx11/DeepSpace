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
    enum GameMode
    {
        LEVELS,
        SURVIVAL
    }
    class GameScene : Scene
    {
        public Planet selectedPlanet;
        public int playerTeam;
        private static Random rnd = new Random();

        public GameScene(Game game)
            : base(game)
        {
            this.selectedPlanet = null;
            if (game.level == 0)
            {
                //survival
                this.objects = LevelGenerator.GenerateLevel(game, (uint)rnd.Next(5, 8));
                this.playerTeam = 1;
                objects.Add(new AI(game));
                objects.Add(new WinLooseChecker(game));
            }
            else if (game.level < 5)
            {
                //tutorial
                this.objects = LevelLoader.LoadLevel(game, game.level);
                this.playerTeam = 1;
                objects.Add(new AI(game));
                objects.Add(new WinLooseChecker(game));
            }
        }

        public override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                game.scene = new MenuScene(game);
            }
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