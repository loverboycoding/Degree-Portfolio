using SplashKitSDK;
using System;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endX;
        private float _endY;




        // Constructor with parameters for color and coordinates
        public MyLine(Color color, float startX, float startY, float endX, float endY) : base(color)
        {
            X = startX;
            Y = startY;
            _endX = endX;
            _endY = endY;
        }
        // Default constructor initializing color and coordinates
        public MyLine() : this(Color.RandomRGB(255), 0.0f, 0.0f, 100, 100)
        {
        }

        // Property for EndX
        public float EndX
        {
            get { return _endX; }
            set { _endX = value; }
        }

        // Property for EndY
        public float EndY
        {
            get { return _endY; }
            set { _endY = value; }
        }

        // Override Draw to actually draw the line
        public override void Draw()
        {
            SplashKit.DrawLine(Color, X, Y, _endX, _endY);
        }

        // Override DrawOutline for the selection
        public override void DrawOutline()
        {
            if (Selected)
            {
                SplashKit.DrawLine(Color.Black, X - 5, Y - 5, _endX + 5, _endY + 5);
            }
        }

        public override bool IsAt(Point2D pt)
        {
            // Create a Line object from the start and end points
            Line line = SplashKit.LineFrom(X, Y, _endX, _endY);

            // Use the PointOnLine method, which expects a Line object
            return SplashKit.PointOnLine(pt, line);
        }
        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);
            writer.WriteLine("Line");
            writer.WriteLine(EndX);
            writer.WriteLine(EndY);
            writer.WriteLine($"{(int)(Color.R * 255)},{(int)(Color.G * 255)},{(int)(Color.B * 255)}");

        }
        public override void LoadFrom(StreamReader reader)
        {
            Color = reader.ReadColor();
            EndX = reader.ReadInteger();
            EndY = reader.ReadInteger();
        }
    }
}
