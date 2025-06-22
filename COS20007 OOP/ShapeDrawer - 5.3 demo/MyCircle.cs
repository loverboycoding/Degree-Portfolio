using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;
        public MyCircle(Color clr, int radius) : base(clr) //default constructor for circles
        {
            _radius = radius;
        }
        public MyCircle() : this(Color.RandomRGB(255), 80) { } //default constructor for creating circles
        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }
        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillCircle(Color, X, Y, _radius);
        }
        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, _radius + 1);
        }
        public override bool IsAt(Point2D pt) //ensure shape is selected
        {
            return SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, _radius));
        }
        public override void SaveTo(StreamWriter writer) //save method
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(Radius);
        }
        public override void LoadFrom(StreamReader reader) //load method
        {
            base.LoadFrom(reader);
            Radius = reader.ReadInteger();
        }
    }
}