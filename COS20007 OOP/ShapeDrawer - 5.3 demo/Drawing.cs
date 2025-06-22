
using System;
using System.Linq;
using System.Collections.Generic;
using SplashKitSDK;
using System.IO;
namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }
        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }
        public Drawing() : this(Color.White) { }
        public int ShapeCount
        {
            get { return _shapes.Count; }
        }
        public List<Shape> SelectedShapes()
        {
            List<Shape> _selectedShapes = new List<Shape>();
            foreach (Shape s in _shapes)
            {
                if (s.Selected)
                {
                    _selectedShapes.Add(s);
                }
            }
            return _selectedShapes;
        }
        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }
        public void RemoveSelectedShapes()
        {
            foreach (Shape s in _shapes.ToList())
            {
                if (s.Selected)
                {
                    _shapes.Remove(s);
                }
            }
        }
        public void Save(string filename)
        {

            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteColor(_background);
                writer.WriteLine(ShapeCount);
                foreach (Shape s in _shapes)
                {
                    s.SaveTo(writer);
                }
            }
        }
        public void Load(string filename)
        {

            using (StreamReader reader = new StreamReader(filename))
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
                        case "Line":
                            s = new MyLine();
                            break;
                        default:
                            throw new InvalidDataException("Unknown shape kind: " + kind);
                    }
                    s.LoadFrom(reader);
                    AddShape(s);
                }
            }
        }
        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape s in _shapes)
            {
                s.Draw();
            }
        }
        public void ChangingShapeColor()
        {
            foreach (Shape s in _shapes)
            {
                if (s.Selected)
                {
                    s.Color = Color.RandomRGB(255);
                }
            }
        }
        public void SelectedShapeAt(Point2D pt)
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
    }
}