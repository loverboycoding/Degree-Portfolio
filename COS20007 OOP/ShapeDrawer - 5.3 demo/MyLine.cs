using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endX;
        private float _endY;
        public MyLine(Color color, float startX, float startY, float endX, float endY) : base(color)
        {
            X = startX; // Starting point
            Y = startY;
            _endX = endX; // Ending point
            _endY = endY;
        }

        public MyLine() : this(Color.Red, 0, 0, 100, 100) // Default line start and end coordinates
        {
        }
        public float EndX
        {
            get { return _endX; }
            set { _endX = value; }
        }
        public float EndY
        {
            get { return _endY; }
            set { _endY = value; }
        }
        // Override Draw method
        public override void Draw()
        {
            SplashKit.DrawLine(Color, X, Y, _endX, _endY); // Drawing the shape line
            if (Selected)
            {
                DrawOutline(); // Draw outline if selected
            }
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, 5); // making small circles at the starting point
            SplashKit.DrawCircle(Color.Black, _endX, _endY, 5); //making small circles at the ending point
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, _endX, _endY));
        }
        public override void SaveTo(StreamWriter writer) //save method
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(_endX);
            writer.WriteLine(_endY);
        }
        public override void LoadFrom(StreamReader reader) //load method
        {
            base.LoadFrom(reader);
            _endX = reader.ReadInteger();
            _endY = reader.ReadInteger();
        }
    }
}