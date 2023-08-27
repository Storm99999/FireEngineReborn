using FireEngine.src.ColorfulConsole;
using FireEngine.src.FireEngine.Core;
using FireEngine.src.FireEngine.Render;
using FireEngine.src.FireEngine.Vector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireEngine.src.FireEngine.Demo
{
    class Test : Engine
    {
        public static Sprite player;
        public static Vector2 lastPositionBeforeCollide = Vector2.zero();
        public bool jump;
        public bool left;
        public bool right;
        public static string[,] Map = 
        {
            {".",".",".",".","r","r","g"},
            {".",".",".",".","r",".","g"},
            {".",".",".",".",".",".","g"},
            {".",".",".",".",".",".","g"},
            {"g","g","g","g","g","g","g"},
            {".",".",".",".",".",".","."}
        };
        public Test() : base(new Vector2(615, 515),"Fire")
        {

        }

        public override void GetKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                right = true;
            }

            if (e.KeyCode == Keys.A)
            {
                left = true;
            }
        }

        public override void GetKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                right = false;
            }

            if (e.KeyCode == Keys.A)
            {
                left = false;
            }
        }

        public override void OnDraw()
        {
        }

        public override void OnLoad()
        {
            //CameraPos.X = 100;
            
            FireConsole.WriteLine("OnLoad fired", "FireEngine");

            for(int i = 0; i < Map.GetLength(1); i++)
            {
                for (int j = 0; j < Map.GetLength(0); j++)
                {
                    if (Map[j,i] == "g")
                    {
                        new Sprite(new Vector2(i * 50, j * 50), new Vector2(50, 50), "Map/Green Hill Zone/ground.png", "Ground");
                    }

                    if (Map[j, i] == "r")
                    {
                        new Sprite(new Vector2(i * 50, j * 50), new Vector2(50, 50), "Items/R_Ring.Spin2.gif", "Ring");
                    }
                }
            }


            player = new Sprite(new Vector2(10, 10), new Vector2(110, 110), "Characters/Sonic/S_Sonic.Idle.png", "Player");
        }

        public override void OnUpdate()
        {
            Sprite r = Sprite.IsColliding(player, "Ring");
            if (r != null)
            {
                r.Destroy();
            }

            if (left)
            {
                player.Pos.X -= 1f;
            }
            if (right)
            {
                player.Pos.X += 1f;
            }

            if (Sprite.IsColliding(player, "Ground") != null)
            {
                player.Pos.X = lastPositionBeforeCollide.X;
                player.Pos.Y = lastPositionBeforeCollide.Y;
            }
            else
            {
                lastPositionBeforeCollide.X = player.Pos.X;
                lastPositionBeforeCollide.Y = player.Pos.Y;
            }
        }
    }
}
