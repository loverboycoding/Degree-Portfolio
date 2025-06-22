using System.Collections.Generic;
using SplashKitSDK;
using System.IO;
using System.IO.Enumeration;

namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;
        private StreamWriter writer;
        private Shape s;

        private StreamReader reader;
        private int count;
        private string kind;



        // Public property to access the background color
        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        public void Save(string filename)
        {
            // Step 1: Assign writer, a new StreamWriter passing in filename
            using (StreamWriter writer = new StreamWriter(filename))
            {
                // Step 2: Tell writer to WriteColor, passing in Background
                writer.WriteLine(Background.ToString());

                // Step 3: Tell writer to WriteLine, passing in ShapeCount
                writer.WriteLine(_shapes.Count);

                // Step 4: For each Shape s in _shapes
                foreach (Shape s in _shapes)
                {
                    // Step 5: Tell s to SaveTo writer
                    s.SaveTo(writer);
                }

                // Step 6: Tell writer to Close
                // This is automatically handled by the 'using' statement which disposes of the StreamWriter
            }
        }

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        public void Load(string filePath)
        {
            reader = new StreamReader(filePath);
            Background =  reader.ReadColor();
            count = reader.ReadInteger();
            _shapes.Clear();

            for (int i = 0;  i < count; i++)
            {
                reader.ReadLine();
                if (kind == "Rectangle")
                {
                    s = new MyRectangle();
                }
                if (kind == "Circle")
                {
                    s = new MyCircle();
                }
                else
                {
                    continue;
                }

                s.LoadFrom(reader);
                _shapes.Add(s);

                reader.Close();
            }
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
    }
}
