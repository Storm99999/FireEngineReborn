using FireEngine.src.ColorfulConsole;
using FireEngine.src.FireEngine.Core;
using FireEngine.src.FireEngine.Vector;
using System.Drawing;

namespace FireEngine.src.FireEngine.Render
{
    public class Sprite
    {
        public Vector2 Pos = null;
        public Vector2 Scale = null;
        public string Directory = "";
        public string Tag = "";
        private string assetsDir = "Content/";
        public Bitmap Object;
        // Character Image
        public Sprite(Vector2 pos, Vector2 scale, string dir, string tag)
        {
            this.Pos = pos;
            this.Scale = scale;
            this.Directory = dir;
            this.Tag = tag;
            Image tmp = Image.FromFile($"{assetsDir}Sprites/{Directory}");
            Bitmap spriteT = new Bitmap(tmp);
            Object = spriteT;
            FireConsole.WriteLine(this.Tag + " was registered", "Renderer");
            Renderer.RegisterSprite(this);
        }

        /// <summary>
        /// Simple Collision Check.
        /// </summary>
        public static Sprite IsColliding(Sprite a, string tag)
        {
            foreach (Sprite b in Engine.allSprites)
            {
                if (b.Tag == tag)
                {
                    if (a.Pos.X < b.Pos.X + b.Scale.X && a.Pos.X + a.Scale.X > b.Pos.X && a.Pos.Y < b.Pos.Y + b.Scale.Y && a.Pos.Y + a.Scale.Y > b.Pos.Y)
                    {
                        return b;
                    }
                }
            }
            return null;
        }

        public void Destroy()
        {
            Renderer.RemoveSprite(this);
        }
    }
}
