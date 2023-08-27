using FireEngine.src.FireEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEngine.src.FireEngine.Render
{
    internal class Renderer
    {
        public static void RegisterObject(Shape shape)
        {
            Engine.allObjects.Add(shape);
        }

        public static void RemoveObject(Shape shape)
        {
            Engine.allObjects.Remove(shape);
        }

        public static void RegisterSprite(Sprite sprite)
        {
            Engine.allSprites.Add(sprite);
        }

        public static void RemoveSprite(Sprite sprite)
        {
            Engine.allSprites.Remove(sprite);
        }
    }
}
