using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEngine.src.FireEngine.Vector
{
    public class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2()
        {
            X = zero().X;
            Y = zero().Y;
        }

        public Vector2(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        /// <summary>
        /// Returns an empty Vector2.
        /// </summary>
        /// <returns></returns>
        public static Vector2 zero()
        {
            return new Vector2(0, 0);
        }
    }
}
