using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaartEngine.MaartEngine;
using System.Drawing;
using System.Windows.Forms;

// ***********************************************************************************************
//                          Demo Game put your own game code here
// ***********************************************************************************************




namespace MaartEngine
{
    class DemoGame : MaartEngine.MaartEngine
    {
        // variables
        Sprite2D player;


        bool left;
        bool right;
        bool up;
        bool down;
        


        Vector2 lastPos = Vector2.Zero();


        // map
        string[,] Map =
        {
            {"g",".",  ".", ".", ".", ".", ".", ".", ".", ".",".","g" },
            {"g",".",  ".", ".", ".", ".", ".", ".", ".", ".",".","g" },
            {"g",".",  ".", ".", ".", ".", ".", ".", ".", ".",".","g"  },
            {"g",".",  ".", ".", ".", ".", ".", ".", ".", ".",".","g" },
            {"g",".",  ".", ".", ".", ".", ".", ".", ".", ".",".","g" },
            {"g",".",  ".", ".", ".", ".", ".", ".", ".", ".",".","g" },
            {"g",".",  ".", ".", ".", ".", ".", ".", ".", ".",".","g" },
            {"g",".",  ".", ".", ".", ".", ".", ".", ".", ".",".","g" },
            {"g",".",  ".", ".", ".", ".", ".", ".", ".", ".",".","g" },
            {"g",".",  ".", ".", ".", ".", ".", ".", ".", ".",".","g" },
            {"g",".",  ".", ".", ".", ".", ".", ".", ".", ".",".","g" },
            {"g",".",  ".", ".", ".", ".", ".", ".", ".", ".",".","g" },
            {"g",".",  ".", ".", ".", ".", ".", ".", ".", ".",".","g" },
            {"g",".",  ".", ".", ".", ".", ".", ".", ".", ".",".","g" },
            {"g",".",  ".", ".", ".", ".", ".", ".", ".", ".",".","g" },
            {"g",".",  ".", ".", ".", ".", ".", ".", ".", ".",".","g" },
            {"g",".",  ".", ".", ".", ".", ".", ".", ".", ".",".","g" },
            {"g",".",  ".", ".", ".", ".", ".", ".", ".", ".",".","g" },
            {"g",".",  ".", ".", ".", ".", ".", ".", ".", ".",".","g" },
            {"g", "g", "g", "g", "g", "g", "g", "g", "g", "g","g","g" }
        };


        // shapes
        string[,] Long =
        {
            {".",".",".","." },
            {"b","b","b","b" },
        };

        string[,] L1 =
        {
            {"b",".",".","." },
            {"b","b","b","b" },
        };

        string[,] L2 =
        {
            {".",".",".","b" },
            {"b","b","b","b" },
        };

        string[,] block =
        {
            {"b","b",},
            {"b","b" },
        };

        string[,] Z1 =
        {
            {".","b","b"},
            {"b","b","."},
        };

        string[,] Z2 =
        {
            {"b","b","."},
            {".","b","b"},
        };

        string[,] T =
        {
            {".","b","."},
            {"b","b","b"},
        };

        string[,] blocks ={
            {"Long", "L1", "L2", "block", "Z1", "Z2", "T"}
        };

        // window size
        public DemoGame() : base(new Vector2(400,740),"MaartEngine Demo") { }



        // this will be only executed when the game loads
        public override void OnLoad()
        {
            BackgroundColor = Color.Black;

            

            // map loading
            for(int i = 0; i < Map.GetLength(1); i++)
            {
                for (int j = 0; j < Map.GetLength(0); j++)
                {
                    // map blocks
                    if (Map[j, i] == "g")
                    {
                        new Sprite2D(new Vector2(i * 32, j * 32), new Vector2(32, 32), "tetris sprites/grey_tile", "Ground");
                    }
                }
            }


            player = new Sprite2D(new Vector2(32, 32), new Vector2(32, 32), "tetris sprites/purple_tile", "Player");
            
        }


        // this will break your code if you put it here :)
        public override void OnDraw()
        {
            
        }



        // this will be executed every frame
        public override void OnUpdate()
        {
            float posx = player.Position.X;

            


            if (left)
            {
                player.Position.X -= 2;
            }

            if (right)
            {
                player.Position.X += 2;
            }

            if(player.IsColliding("Ground")){
                float x = lastPos.X;
                float y = lastPos.Y - 2;
                player.Position = new Vector2(x, y);
                if (up)
                {
                    jump();
                }
            }
            else
            {
                lastPos = player.Position;
                //Log.Info(lastPos.X + " : " + lastPos.Y);
                player.Position.Y += 2;
                
            }
        }

        // jump method
        private void jump()
        {
            int g = 0;
            while (g < 101)
            {
                player.Position.Y--;
                g++;
            }


        }


        // get player input when you press a button
        public override void GetKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) { up = true; }
            if (e.KeyCode == Keys.Shift) { down = true; }
            if (e.KeyCode == Keys.A) { left = true; }
            if (e.KeyCode == Keys.D) { right = true; }
        }


        // get player input when you let a button go
        public override void GetKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) { up = false; }
            if (e.KeyCode == Keys.Shift) { down = false; }
            if (e.KeyCode == Keys.A) { left = false; }
            if (e.KeyCode == Keys.D) { right = false; }
        }
    }
}
