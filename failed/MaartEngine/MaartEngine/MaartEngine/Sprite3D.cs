using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MaartEngine.MaartEngine
{
    public class Sprite3D
    {
        // variables
        public Vector3 Position = null;
        public Vector3 Scale = null;
        public string Directory = "";
        public string Tag = "";
        public Vector3 Sprite = null;

        // render sprite
        public Sprite3D(Vector3 Position, Vector3 Scale, string Directory, string Tag)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Directory = Directory;
            this.Tag = Tag;

            

            Vector3 sprite = new Vector3(tmp, tmp, tmp);
            Sprite = sprite;



            Log.Info($"[Sprite3D]({Tag}) - Has been registered");
            MaartEngine.Register3DSprite(this);
        }
        // collision 1
       

        // collision 2
        public bool IsColliding(string tag)
        {

            foreach (Sprite3D b in MaartEngine.All3DSprites)
            {
                if (b.Tag == tag)
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
            MaartEngine.UnRegister3DSprite(this);
        }
    }
}
