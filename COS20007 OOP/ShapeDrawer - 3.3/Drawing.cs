using System.Collections.Generic;
using SplashKitSDK;
using System.IO;
using MyGame;
namespace ShapeDrawer

{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;
        // Public property to access the background color
        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }
        public Drawing() : this(Color.White) { } // Default constructor
        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }
        public void RemoveShape(Shape shape)
        {
            _shapes.Remove(shape);
        }
        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }
        }
        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(pt))
                {
                    s.Selected = true;
                }
                else
                {
                    s.Selected = false;
                }
            }
        }
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape s in _shapes)
                {
                    if (s.Selected)
                    {
                        result.Add(s);
                    }
                }
                return result;
            }
        }
        public void Save(string filename)
        {

            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteColor(_background);
                writer.WriteLine(_shapes.Count);

                foreach (Shape s in _shapes)
                {
                    s.SaveTo(writer);
                }
            }
        }

        public void Load(string filepath)
        {

            using (StreamReader reader = new StreamReader(filepath))
            {
                Shape s;
                string kind;
                Background = reader.ReadColor();
                int count = reader.ReadInteger();
                _shapes.Clear();
                for (int i = 0; i < count; i++)
                {
                    kind = reader.ReadLine();
                    switch (kind)
                    {
                        case "Rectangle":
                            s = new MyRectangle();
                            break;
                        case "Circle":
                            s = new MyCircle();
                            break;
                        default:
                            throw new InvalidDataException("Unknown shape kind: " + kind);
                    }
                    s.LoadFrom(reader);
                    AddShape(s);
                }
            }
        }
    }
}