using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        private int _width, _height;

        // Property for Width
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        // Property for Height
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        // Default constructor initializes with Color.Green, 0.0f for x and y, and 100 for width and height
        public MyRectangle() : this(Color.Red, 0.0f, 0.0f, 300, 100)
        {
        }

        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);
            writer.WriteLine("Rectangle");
            writer.WriteLine(Width);
            writer.WriteLine(Height);
            writer.WriteLine($"{(int)(Color.R * 255)},{(int)(Color.G * 255)},{(int)(Color.B * 255)}");

        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Width = reader.ReadInteger();
            Height = reader.ReadInteger();

        }
        // Constructor that accepts color, x, y, width, and height
        public MyRectangle(Color color, float x, float y, int width, int height) : base(color)
        {
            X = x;
            Y = y;
            _width = width;
            _height = height;
        }

        // Override Draw method
        public override void Draw()
        {
            SplashKit.FillRectangle(Color, X, Y, _width, _height);

            if (Selected)
            {
                DrawOutline(); // Draw outline if selected
            }
        }

        // Override DrawOutline method
        public override void DrawOutline()
        {
            SplashKit.DrawRectangle(Color.Black, X - 2, Y - 2, _width + 4, _height + 4);
        }

        // Override IsAt method to check if a point is within the rectangle
        public override bool IsAt(Point2D pt)
        {
            return (pt.X >= X && pt.X <= X + _width && pt.Y >= Y && pt.Y <= Y + _height);
        }
    }
}
