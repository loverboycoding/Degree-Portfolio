using SplashKitSDK;
using System.IO;
namespace ShapeDrawer
{
    public abstract class Shape
    {
        private Color _color;
        private float _x, _y,_width,_height;
        private bool _selected;

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteLine(_color);  
            writer.WriteLine(X);                 
            writer.WriteLine(Y);
        }

        public virtual void LoadFrom(StreamReader reader)
        {
            Color = reader.ReadColor();
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
        }

        // Property for Color
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        // Property for X coordinate
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        // Property for Y coordinate
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public float Width //call and intialize the variable
        {
            get { return _width; } //get and store the width 
            set { _width = value; }
        }
        public float Height //call and intialize the variable
        {
            get { return _height; } //get and store the height 
            set { _height = value; }
        }



        // Property for Selected
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        // Default constructor that initializes with Color.Yellow
        public Shape() : this(Color.Yellow)
        {
        }

        // Constructor that accepts color as a parameter
        public Shape(Color color)
        {
            _color = color;
        }

        // Empty method bodies for Draw and DrawOutline
        public virtual void Draw() { }

        public virtual void DrawOutline() { }

        // Virtual IsAt method returns false
        public virtual bool IsAt(Point2D pt)
        {
            return false;
        }
    }
}
