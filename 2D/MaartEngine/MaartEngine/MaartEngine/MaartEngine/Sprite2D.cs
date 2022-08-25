using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MaartEngine.MaartEngine
{
    public class Sprite2D
    {
        // variables
        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Directory = "";
        public string Tag = "";
        public Bitmap Sprite = null;

        // render sprite
        public Sprite2D(Vector2 Position, Vector2 Scale, string Directory, string Tag)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Directory = Directory;
            this.Tag = Tag;

            Image tmp = Image.FromFile($"assets/sprites/{Directory}.png");

            Bitmap sprite = new Bitmap(tmp);
            Sprite = sprite;
            
            

            Log.Info($"[Shape2D]({Tag}) - Has been registered");
            MaartEngine.RegisterSprite(this);
        }
        // collision 1
        public bool IsColliding(Sprite2D a, Sprite2D b)
        {
            if(a.Position.X < b.Position.X + b.Scale.X&&
                a.Position.X + a.Scale.X > b.Position.X&&
                a.Position.Y < b.Position.Y + b.Scale.Y &&
                a.Position.Y + a.Scale.Y > b.Position.Y)
            {
                return true;
            }


            return false;
        }

        // collision 2
        public bool IsColliding(string tag)
        {
            
            foreach(Sprite2D b in MaartEngine.AllSprites)
            {
                if(b.Tag == tag)
                {
                    if (Position.X < b.Position.X + b.Scale.X &&
                        Position.X + Scale.X > b.Position.X &&
                        Position.Y < b.Position.Y + b.Scale.Y &&
                        Position.Y + Scale.Y > b.Position.Y)
                    {
                        return true;
                    }
                }
            }


            return false;
        }

        // destroy self
        public void DestroySelf()
        {
            MaartEngine.UnRegisterSprite(this);
        }
    }
}
