using FireEngine.src.ColorfulConsole;
using FireEngine.src.FireEngine.Vector;

namespace FireEngine.src.FireEngine.Render
{
    public class Shape
    {
        public Vector2 Pos = null;
        public Vector2 Scale = null;
        public string Tag = "";

        public Shape(Vector2 Pos, Vector2 Scale, string Tag)
        {
            this.Pos = Pos;
            this.Scale = Scale;
            this.Tag = Tag;
            // Add main Object.
            Renderer.RegisterObject(this);
            FireConsole.WriteLine(this.Tag + " was registered", "Renderer");
        }

        public void Destroy()
        {
            Renderer.RemoveObject(this);
            FireConsole.WriteLine(this.Tag + " was destroyed in runtime", "Renderer");
        }
    }
}
