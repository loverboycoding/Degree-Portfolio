using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            // Default shape to add is Circle
            ShapeKind kindToAdd = ShapeKind.Circle;

            Drawing myDrawing = new Drawing(); // Create a Drawing object using the default constructor
            Window window = new Window("Shape Drawer", 800, 600);

            string desktopPath = "C:\\Users\\joshu\\OneDrive\\Desktop\\COS20007 OOP\\ShapeDrawer - 3.3";
            string filePath = System.IO.Path.Combine(desktopPath, "TestDrawing3.txt");

            do
            {
                SplashKit.ProcessEvents();
                window.Clear(myDrawing.Background); // Clear with the current background color

                myDrawing.Draw(); // Draw all shapes

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    // Create a new shape based on kindToAdd
                    Shape newShape = null;

                    if (kindToAdd == ShapeKind.Rectangle)
                    {
                        newShape = new MyRectangle();
                    }
                    else if (kindToAdd == ShapeKind.Circle)
                    {
                        newShape = new MyCircle();
                    }
                    else if (kindToAdd == ShapeKind.Line)
                    {
                        float startX = SplashKit.MouseX();
                        float startY = SplashKit.MouseY();
                        newShape = new MyLine(Color.Red, startX, startY, startX + 100, startY + 50);
                    }

                    if (newShape != null)
                    {
                        if (kindToAdd != ShapeKind.Line)
                        {
                            newShape.X = SplashKit.MouseX();
                            newShape.Y = SplashKit.MouseY();
                        }

                        myDrawing.AddShape(newShape);
                    }
                }

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    myDrawing.Save(filePath);
                }

                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    myDrawing.Load(filePath); // Load the drawing from the file
                    window.Clear(myDrawing.Background); // Clear with the loaded background color
                    myDrawing.Draw(); // Redraw the shapes after loading
                    window.Refresh(60); // Refresh the window to display loaded content
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomColor();
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapesAt(SplashKit.MousePosition());
                }

                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (var shape in myDrawing.SelectedShapes)
                    {
                        myDrawing.RemoveShape(shape);
                    }
                }

                window.Refresh(60);
            } while (!window.CloseRequested);

            window.Close();
        }
    }
}
