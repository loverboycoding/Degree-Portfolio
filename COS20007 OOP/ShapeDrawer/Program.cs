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

            // Set up the file path for saving/loading
            string desktopPath = "C:\\Users\\joshu\\OneDrive\\Desktop\\COS20007 OOP\\ShapeDrawer";
            string filePath = System.IO.Path.Combine(desktopPath, "TestDrawing.txt");

            do
            {
                SplashKit.ProcessEvents();
                window.Clear(Color.White); // Clear with a temporary white color

                myDrawing.Draw(); // Draw all shapes

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    // Create a new shape based on kindToAdd
                    Shape newShape = null;  // Initialize as null to handle lines differently

                    if (kindToAdd == ShapeKind.Rectangle)
                    {
                        // Create a new rectangle
                        newShape = new MyRectangle();
                    }
                    else if (kindToAdd == ShapeKind.Circle)
                    {
                        // Create a new circle
                        newShape = new MyCircle();
                    }
                    else if (kindToAdd == ShapeKind.Line)
                    {
                        // Create a new line
                        float startX = SplashKit.MouseX();
                        float startY = SplashKit.MouseY();
                        // Placeholder end points for the line, can be adjusted based on user input
                        newShape = new MyLine(Color.Red, startX, startY, startX + 100, startY + 50);
                    }

                    if (newShape != null)
                    {
                        // Set the position of the new shape for non-line shapes
                        if (kindToAdd != ShapeKind.Line)
                        {
                            newShape.X = SplashKit.MouseX();
                            newShape.Y = SplashKit.MouseY();
                        }

                        myDrawing.AddShape(newShape); // Add the new shape to the drawing
                    }
                }

                // Change shape to Rectangle if 'R' key is pressed
                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                // Save the drawing if 'S' key is pressed
                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    // Call the Save method of Drawing class
                    myDrawing.Save(filePath);
                }

                // Load the drawing if 'O' key is pressed
                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    myDrawing.Load(filePath);  // Load the drawing from the file
                }

                // Change shape to Circle if 'C' key is pressed
                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                // Change the background color to a random color when the space key is pressed
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomColor();
                }

                // Select shapes at the current mouse pointer position when the right mouse button is clicked
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapesAt(SplashKit.MousePosition());
                }

                // Remove selected shapes if the delete or backspace key is pressed
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
