using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaartEngine.MaartEngine
{
    // ***********************************************************************************************
    //                    DON'T CHANGE THIS HERE IT WILL BREAK EVERYTHING
    // ***********************************************************************************************
    public class Vector3
    {
        // variables
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }


        // all vector2 variables types
        public Vector3()
        {
            X = Zero().X;
            Y = Zero().Y;
            Z = Zero().Z;
        }

        // the vector2 refrence
        public Vector3(float X, float Y, float Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        // sets the vector3 to zero
        public static Vector3 Zero()
        {
            return new Vector3(0, 0, 0);
        }
    }
}
