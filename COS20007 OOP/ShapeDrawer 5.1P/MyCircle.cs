using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;

        // Property for Radius
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Radius = reader.ReadInteger();
        }


        // Default constructor initializes with Color.Blue and Radius 50
        public MyCircle() : base(Color.Blue)
        {
            _radius = 50;  // Default radius
        }


        // Constructor that accepts color and radius
        public MyCircle(SplashKitSDK.Color color, int radius,float x, float y) : base(color)
        {
            _radius = radius;
            X = x;
            Y = y;
        }

        // Override Draw method
        public override void Draw()
        {
            SplashKit.FillCircle(Color, X, Y, _radius);

            if (Selected)
            {
                DrawOutline(); // Draw outline if selected
            }
        }

        // Override DrawOutline method
        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, _radius + 2);
        }

        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);
            writer.WriteLine("Circle");
            writer.WriteLine(Radius);
            writer.WriteLine($"{(int)(Color.R * 255)},{(int)(Color.G * 255)},{(int)(Color.B * 255)}");

        }

        // Override IsAt method to check if a point is within the circle
        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, _radius));
        }
    }
        
}

