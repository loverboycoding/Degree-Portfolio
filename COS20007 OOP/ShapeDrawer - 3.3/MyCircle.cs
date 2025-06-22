using MyGame;
using SplashKitSDK;

public class MyCircle : Shape
{
    // Private field specific to MyCircle
    private int _radius;

    // Property for accessing the private field
    public int Radius
    {
        get => _radius;
        set => _radius = value;
    }

    // Constructors
    public MyCircle() : this(Color.Blue, 50) { }

    public MyCircle(Color color, int radius) : base(color)
    {
        X = 0.0f;
        Y = 0.0f;
        _radius = radius;
    }

    // Overridden methods
    public override void Draw()
    {
        if (Selected)
        {
            DrawOutline();
        }
        SplashKit.FillCircle(Color, X, Y, Radius);
    }

    public override void DrawOutline()
    {
        SplashKit.DrawCircle(Color.Black, X, Y, Radius + 2);
    }

    public override bool IsAt(Point2D pt)
    {
        return SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, _radius));
    }


    public override void SaveTo(StreamWriter writer)
    {
        base.SaveTo(writer);
        writer.WriteLine("Circle");
        writer.WriteLine(Radius);
    }

    public override void LoadFrom(StreamReader reader)
    {
        base.LoadFrom(reader);
        Radius = reader.ReadInteger();
    }
}
