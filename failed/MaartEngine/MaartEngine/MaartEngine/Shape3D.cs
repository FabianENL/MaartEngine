using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaartEngine.MaartEngine
{
    public class Shape3D
    {
        // variables
        public Vector3 Position = null;
        public Vector3 Scale = null;
        public string Tag = "";


        // render shape
        public Shape3D(Vector3 Position, Vector3 Scale, string Tag)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Tag = Tag;

            Log.Info($"[Shape3D]({Tag}) - Has been registered");
            MaartEngine.Register3DShape(this);
        }


        // destroy self
        public void DestroySelf()
        {
            Log.Info($"[Shape3D]({Tag}) - Has been destroyed");

            MaartEngine.UnRegister3DShape(this);
        }
    }
}
