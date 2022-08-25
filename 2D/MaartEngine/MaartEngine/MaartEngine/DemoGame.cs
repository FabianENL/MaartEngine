﻿using System;
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
            {".",".",  ".", ".", ".", ".", ".", ".", ".", "." },
            {".",".",  ".", ".", ".", ".", ".", ".", ".", "." },
            {".",".",  ".", ".", ".", ".", ".", "g", "g", "g" },
            {".",".",  ".", ".", ".", "g", "gs", "gb", "gb", "gb" },
            {".",".",  ".", "g", "gs", "gb", "gb", "gb", "gb", "gb" },
            {"g","g",  "gs", "gb", "gb", "gb", "gb", "gb", "gb", "gb" },
            {".", ".",  ".", ".", ".", ".", ".", ".", ".", "." }
        };

        // window size
        public DemoGame() : base(new Vector2(615,515),"MaartEngine Demo") { }



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
                        new Sprite2D(new Vector2(i * 64, j * 64), new Vector2(64, 64), "Tiles/Blue tiles/tileBlue_05", "Ground");
                    }
                    if (Map[j, i] == "gb")
                    {
                        new Sprite2D(new Vector2(i * 64, j * 64), new Vector2(64, 64), "Tiles/Blue tiles/tileBlue_03", "Ground");
                    }
                    if (Map[j, i] == "s")
                    {
                        new Sprite2D(new Vector2(i * 64, j * 64), new Vector2(64, 64), "Tiles/Blue tiles/tileBlue_09", "Ground");
                    }
                    if (Map[j, i] == "gs")
                    {
                        new Sprite2D(new Vector2(i * 64, j * 64), new Vector2(64, 64), "Tiles/Blue tiles/tileBlue_18", "Ground");
                    }
                }
            }
            player = new Sprite2D(new Vector2(10, 200), new Vector2(46, 56), "Players/Player Grey/playerGrey_walk1", "Player");
            
        }


        // this will break your code if you put it here :)
        public override void OnDraw()
        {
            
        }



        // this will be executed every frame
        public override void OnUpdate()
        {
            float posx = player.Position.X;
            float camposx = -posx + 256;
            CameraPosition = new Vector2(camposx, 0);

            


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
