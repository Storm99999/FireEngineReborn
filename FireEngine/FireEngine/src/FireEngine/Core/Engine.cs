using FireEngine.src.ColorfulConsole;
using FireEngine.src.FireEngine.Environment;
using FireEngine.src.FireEngine.Render;
using FireEngine.src.FireEngine.Vector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireEngine.src.FireEngine.Core
{
    class FireEngineCanvas : Form
    {
        public FireEngineCanvas()
        {
            this.DoubleBuffered = true;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FireEngineCanvas
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FireEngineCanvas";
            this.Load += new System.EventHandler(this.FireEngineCanvas_Load);
            this.ResumeLayout(false);

        }

        private void FireEngineCanvas_Load(object sender, EventArgs e)
        {

        }
    }

    public abstract class Engine
    {
        public static List<Sprite> allSprites = new List<Sprite>();
        public static List<Shape> allObjects = new List<Shape>();
        private Vector2 screenRes = new Vector2(512, 512);
        public static Vector2 CameraPos = Vector2.zero();
        private Thread forceWindowRedraw = null;
        private FireEngineCanvas Window = null;
        private string Title = "FireEngine";
        public float CameraAngle = 0f;


        public Engine(Vector2 screenRes, string Title)
        {
            this.screenRes = screenRes;
            this.Title = Title;

            Window = new FireEngineCanvas();
            Window.StartPosition = FormStartPosition.CenterScreen;
            Window.Size = new Size((int)screenRes.X, (int)screenRes.Y);
            Window.Text = Title;
            Window.KeyDown += Window_KeyDown;
            Window.KeyUp += Window_KeyUp;
            Window.FormClosed += Window_FormClosed;
            // call new Thread invoke
            forceWindowRedraw = new Thread(ForceRedraw);
            forceWindowRedraw.Start();
            Thread.Sleep(30);
            Window.Paint += DrawObjects;
            Application.Run(Window);
        }

        private void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            forceWindowRedraw.Abort();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            GetKeyUp(e);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            GetKeyDown(e);
        }

        void ForceRedraw()
        {
            // call main func
            OnLoad();

            while (forceWindowRedraw.IsAlive)
            {
                try
                {
                    OnDraw();
                    Window.BeginInvoke((MethodInvoker)
                        delegate { Window.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(1);
                }
                catch
                {
                    FireConsole.WriteLine("Window not found", "FireEngine");
                }
            }
        }

        private void DrawObjects(object sender, PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            graph.Clear(Config.backgroundColor);
            graph.TranslateTransform(CameraPos.X, CameraPos.Y);
            graph.RotateTransform(CameraAngle);

            foreach (Shape shape in allObjects)
            {
                graph.FillRectangle(new SolidBrush(Color.Red), shape.Pos.X, shape.Pos.Y, shape.Scale.X, shape.Scale.Y);
            }
            foreach (Sprite sprite in allSprites)
            {
                graph.DrawImage(sprite.Object, sprite.Pos.X, sprite.Pos.Y, sprite.Scale.X, sprite.Scale.Y);
            }
        }

        public abstract void OnLoad();
        public abstract void OnUpdate();
        public abstract void OnDraw();
        public abstract void GetKeyDown(KeyEventArgs e);
        public abstract void GetKeyUp(KeyEventArgs e);
    }


}
