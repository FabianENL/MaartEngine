using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;


namespace MaartEngine.MaartEngine
{
    // the canvas where the game will be drawn
    class Canvas : Form
    {
        public Canvas()
        {
            this.DoubleBuffered = true;
        }
    }

    // variables for the game
    public abstract class MaartEngine
    {
        private Vector2 ScreenSize = new Vector2(512, 512);
        private string Title = "New Project";
        private Canvas Window = null;
        private Thread GameLoopThread = null;


        public static List<Shape2D> All2DShapes = new List<Shape2D>();
        public static List<Sprite2D> All2DSprites = new List<Sprite2D>();

        public static List<Shape3D> All3DShapes = new List<Shape3D>();
        public static List<Sprite3D> All3DSprites = new List<Sprite3D>();

        public Color BackgroundColor = Color.White;

        public Vector3 CameraPosition = Vector3.Zero();
        public float CameraAngle = 0f;


        
        public MaartEngine(Vector2 ScreenSize, string Title)
        {
            Log.Info("Game is starting...");
            this.ScreenSize = ScreenSize;
            this.Title = Title;

            Window = new Canvas();
            Window.Size = new Size((int)this.ScreenSize.X, (int)this.ScreenSize.Y);
            Window.Text = this.Title;
            Window.Paint += Renderer;
            Window.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Window.KeyDown += Window_KeyDown;
            Window.KeyUp += Window_KeyUp;

 
            
            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();

            Application.Run(Window);
        }


        // keyboard inputs
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            GetKeyUp(e);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            GetKeyDown(e);
        }


        // shapes and sprites
        public static void Register2DShape(Shape2D shape)
        {
            All2DShapes.Add(shape);
        }
        public static void Register2DSprite(Sprite2D sprite)
        {
            All2DSprites.Add(sprite);
        }
        public static void UnRegister2DSprite(Sprite2D sprite)
        {
            All2DSprites.Remove(sprite);
        }

        public static void UnRegister2DShape(Shape2D shape)
        {
            All2DShapes.Remove(shape);
        }


        public static void Register3DShape(Shape3D shape)
        {
            All3DShapes.Add(shape);
        }
        public static void Register3DSprite(Sprite3D sprite)
        {
            All3DSprites.Add(sprite);
        }
        public static void UnRegister3DSprite(Sprite3D sprite)
        {
            All3DSprites.Remove(sprite);
        }

        public static void UnRegister3DShape(Shape3D shape)
        {
            All3DShapes.Remove(shape);
        }


        // gameloop
        void GameLoop()
        {
            OnLoad();
            while (GameLoopThread.IsAlive)
            {
                try
                {

                    OnDraw();
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(1);
                }
                catch
                {
                    Log.Error("Game Window has not been found. Waiting...");
                }
            }
        }


        // renderer
        private void Renderer(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            g.Clear(BackgroundColor);

            foreach (Shape3D shape in All3DShapes)
            {
                g.FillRectangle(new SolidBrush(Color.Red),shape.Position.X,shape.Position.Y,shape.Scale.X,shape.Scale.Y);
            }
            foreach(Sprite3D sprite in All3DSprites)
            {
                g.DrawImage(sprite.Sprite, sprite.Position.X, sprite.Position.Y, sprite.Position.Z sprite.Scale.X, sprite.Scale.Y, sprite.Scale.Z);
            }
            
            
        }


        // all the methods for in the DemoGame.cs file
        public abstract void OnLoad();
        public abstract void OnUpdate();
        public abstract void OnDraw();

        public abstract void GetKeyDown(KeyEventArgs e);
        public abstract void GetKeyUp(KeyEventArgs e);

    }
}
