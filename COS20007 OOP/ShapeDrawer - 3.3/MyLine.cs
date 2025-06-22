using MyGame;
using SplashKitSDK;

public class MyLine : Shape
{
    // Private fields specific to MyLine
    private float _endX, _endY;

    // Properties for accessing private fields
    public float EndX
    {
        get => _endX;
        set => _endX = value;
    }

    public float EndY
    {
        get => _endY;
        set => _endY = value;
    }

    // Constructor
    public MyLine() : this(Color.Red, 0.0f, 0.0f, 100.0f, 100.0f) { }

    public MyLine(Color color, float startX, float startY, float endX, float endY) : base(color)
    {
        X = startX;
        Y = startY;
        _endX = endX;
        _endY = endY;
    }

    // Overridden methods
    public override void Draw()
    {
        if (Selected)
        {
            DrawOutline();
        }
        SplashKit.DrawLine(Color, X, Y, EndX, EndY);
    }

    public override void DrawOutline()
    {
        SplashKit.DrawLine(Color.Black, X, Y, EndX, EndY);
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
        writer.WriteLine("Line");
        base.SaveTo(writer);
        writer.WriteLine(EndX);
        writer.WriteLine(EndY);
    }

    public override void LoadFrom(StreamReader reader)
    {
        base.LoadFrom(reader);
        EndX = reader.ReadInteger();
        EndY = reader.ReadInteger();
    }
}
