using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Shape myShape = new Shape();
            Window window = new Window("Shape Drawer", 800, 600);

            do
            {
                SplashKit.ProcessEvents();
                window.Clear(Color.White);

                // Get the mouse position as a Point2D from SplashKit
                Point2D mousePosition = SplashKit.MousePosition();

                // Check if the spacebar is pressed and if the mouse is over myShape
                if (SplashKit.KeyTyped(KeyCode.SpaceKey) && myShape.IsAt(mousePosition))
                {
                    myShape.Color = SplashKit.RandomColor();
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                }

                myShape.Draw(); // Draw the shape before refreshing

                window.Refresh(60);
            } while (!window.CloseRequested);
            window.Close();
        }
    }
}
