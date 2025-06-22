using MyGame;
using ShapeDrawer;
using SplashKitSDK;

public class MyRectangle : Shape
{
    // Private fields specific to MyRectangle
    private int _width, _height;

    // Properties for accessing private fields
    public int Width
    {
        get => _width;
        set => _width = value;
    }

    public int Height
    {
        get => _height;
        set => _height = value;
    }

    // Constructors
    public MyRectangle() : this(Color.Green, 0.0f, 0.0f, 100, 100) { }

    public MyRectangle(Color color, float x, float y, int width, int height) : base(color)
    {
        X = x;
        Y = y;
        _width = width;
        _height = height;
    }

    // Overridden methods
    public override void Draw()
    {
        if (Selected)
        {
            DrawOutline();
        }
        SplashKit.FillRectangle(Color, X, Y, Width, Height);
    }

    public override void DrawOutline()
    {
        SplashKit.DrawRectangle(Color.Black, X - 2, Y - 2, Width + 4, Height + 4);
    }

    public override bool IsAt(Point2D pt)
    {
        return (pt.X >= X && pt.X <= X + Width && pt.Y >= Y && pt.Y <= Y + Height);
    }
    public override void SaveTo(StreamWriter writer)
    {
        base.SaveTo(writer);
        writer.WriteLine("Rectangle");
        writer.WriteLine(Width);
        writer.WriteLine(Height);
    }

    public override void LoadFrom(StreamReader reader)
    {
        base.LoadFrom(reader);
        Width = reader.ReadInteger();
        Height = reader.ReadInteger();
    }
}
