using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ***********************************************************************************************
//                    DON'T CHANGE THIS HERE IT WILL BREAK EVERYTHING
// ***********************************************************************************************



namespace MaartEngine.MaartEngine
{
    public class Vector2
    {
        // variables
        public float X { get; set; }
        public float Y { get; set; }


  // all vector2 variables types
        public Vector2()
        {
            X = Zero().X;
            Y = Zero().Y;
        }

        // the vector2 refrence
        public Vector2(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        // sets the vector2 to zero
        public static Vector2 Zero()
        {
            return new Vector2(0,0);
        }

    }
}
