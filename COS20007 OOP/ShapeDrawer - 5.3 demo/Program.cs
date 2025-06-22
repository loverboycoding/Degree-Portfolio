using SplashKitSDK;
namespace ShapeDrawer
{
    public class Program
    {
        private enum Shapekind
        {
            Rectangle,
            Circle,
            Line
        }
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing();
            Shapekind KindToAdd = Shapekind.Circle;
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    KindToAdd = Shapekind.Rectangle;
                }
                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    KindToAdd = Shapekind.Line;
                }
                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    KindToAdd = Shapekind.Circle;
                }
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;
                    switch (KindToAdd)
                    {
                        case Shapekind.Circle:
                            newShape = new MyCircle();
                            newShape.X = SplashKit.MouseX();
                            newShape.Y = SplashKit.MouseY();
                            break;
                        case Shapekind.Line:
                            newShape = new MyLine();
                            newShape.X = SplashKit.MouseX();
                            newShape.Y = SplashKit.MouseY();
                            break;
                        default:
                            newShape = new MyRectangle();
                            newShape.X = SplashKit.MouseX();
                            newShape.Y = SplashKit.MouseY();
                            break;
                    }
                    myDrawing.AddShape(newShape);
                }
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = Color.RandomRGB(255);
                }
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectedShapeAt(SplashKit.MousePosition());
                }
                myDrawing.Draw();
                if (SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    myDrawing.RemoveSelectedShapes();
                }
                SplashKit.RefreshScreen();
                //press S to save 
                if (SplashKit.KeyDown(KeyCode.SKey))
                {
                    myDrawing.Save("C:\\Users\\joshu\\OneDrive\\Desktop\\COS20007 OOP\\ShapeDrawer - 5.3 demo\\TestDrawing.txt");
                }
                //press O to Load
                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        myDrawing.Load("C:\\Users\\joshu\\OneDrive\\Desktop\\COS20007 OOP\\ShapeDrawer - 5.3 demo\\TestDrawing.txt");
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }
                }
            }
            while (!window.CloseRequested);
            window.Close();

        }
    }
}