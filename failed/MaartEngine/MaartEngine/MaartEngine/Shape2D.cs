using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaartEngine.MaartEngine
{
    public class Shape2D
    {
        // variables
        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Tag = "";


        // render shape
        public Shape2D(Vector2 Position, Vector2 Scale, string Tag)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Tag = Tag;

            Log.Info($"[Shape2D]({Tag}) - Has been registered");
            MaartEngine.Register2DShape(this);
        }


        // destroy self
        public void DestroySelf()
        {
            Log.Info($"[Shape2D]({Tag}) - Has been destroyed");
            
            MaartEngine.UnRegister2DShape(this);
        }
    }
}
