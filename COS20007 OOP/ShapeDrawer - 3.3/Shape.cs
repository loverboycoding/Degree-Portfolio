using System;
using MyGame;
using SplashKitSDK;

public abstract class Shape
{
    // Private fields
    private Color _color;
    private float _x, _y;
    private bool _selected;

    // Properties for accessing private fields
    public float X
    {
        get => _x;
        set => _x = value;
    }

    public float Y
    {
        get => _y;
        set => _y = value;
    }

    public Color Color
    {
        get => _color;
        set => _color = value;
    }

    public bool Selected
    {
        get => _selected;
        set => _selected = value;
    }

    // Constructors
    public Shape()
    {
        _color = Color.Yellow;
        _x = 0.0f;
        _y = 0.0f;
        _selected = false;
    }

    public Shape(Color clr)
    {
        _color = clr;
        _x = 0.0f;
        _y = 0.0f;
        _selected = false;
    }

    // Abstract methods to be overridden in derived classes
    public abstract void Draw();
    public abstract void DrawOutline();
    public abstract bool IsAt(Point2D pt);

    public virtual void SaveTo(StreamWriter writer)
    {
        writer.WriteColor(_color);
        writer.WriteLine(X);
        writer.WriteLine(Y);
    }


    public virtual void LoadFrom(StreamReader reader)
    {
        Color = reader.ReadColor();
        X = reader.ReadInteger();
        Y = reader.ReadInteger();
    }
}
