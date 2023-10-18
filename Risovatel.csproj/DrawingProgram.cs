using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace RefactorMe
{
    class Drawer
    {
        static float x, y;
        static Graphics canvas;

        public static void Initialize(Graphics newCanvas)
        {
            canvas = newCanvas;
            canvas.SmoothingMode = SmoothingMode.None;
            canvas.Clear(Color.Black);
        }

        public static void SetPosition(float initX, float initY)
        {
            x = initX; 
            y = initY;
        }

        public static void Draw(Pen drawingPen, double len, double angle)
        {
            //Делает шаг длиной len в направлении angle и рисует пройденную траекторию
            var nextX = (float)(x + len * Math.Cos(angle));
            var nexY = (float)(y + len * Math.Sin(angle));
            canvas.DrawLine(drawingPen, x, y, nextX, nexY);
            x = nextX;
            y = nexY;
        }

        public static void Change(double len, double angle)
        {
            x = (float)(x + len * Math.Cos(angle)); 
            y = (float)(y + len * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        public static void Draw(int width, int height, double rotationAngle, Graphics myCanvas)
        {
            // rotationAngle пока не используется, но будет использоваться в будущем
            Drawer.Initialize(myCanvas);
            var minSize = Math.Min(width, height);
            float largeLine = minSize * 0.375f;
            float smallLine = minSize * 0.04f;
            var diagonalLength = Math.Sqrt(2) * (largeLine + smallLine) / 2;
            var initialX = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var initialY = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Drawer.SetPosition(initialX, initialY);

            DrawFirstSide(largeLine, smallLine);

            DrawSecondSide(largeLine, smallLine);

            DrawThirdSide(largeLine, smallLine);

            DrawFourthSide(largeLine, smallLine);
        }

        public static void DrawFirstSide(float largeLine, float smallLine)
        {
            //Рисуем 1-ую сторону
            Drawer.Draw(Pens.Yellow, largeLine, 0);
            Drawer.Draw(Pens.Yellow, smallLine * Math.Sqrt(2), Math.PI / 4);
            Drawer.Draw(Pens.Yellow, largeLine, Math.PI);
            Drawer.Draw(Pens.Yellow, largeLine - smallLine, Math.PI / 2);

            Drawer.Change(smallLine, -Math.PI);
            Drawer.Change(smallLine * Math.Sqrt(2), 3 * Math.PI / 4);
        }

        public static void DrawSecondSide(float largeLine, float smallLine)
        {
            //Рисуем 2-ую сторону
            Drawer.Draw(Pens.Yellow, largeLine, -Math.PI / 2);
            Drawer.Draw(Pens.Yellow, smallLine * Math.Sqrt(2), -Math.PI / 2 + Math.PI / 4);
            Drawer.Draw(Pens.Yellow, largeLine, -Math.PI / 2 + Math.PI);
            Drawer.Draw(Pens.Yellow, largeLine - smallLine, -Math.PI / 2 + Math.PI / 2);

            Drawer.Change(smallLine, -Math.PI / 2 - Math.PI);
            Drawer.Change(smallLine * Math.Sqrt(2), -Math.PI / 2 + 3 * Math.PI / 4);
        }

        public static void DrawThirdSide(float largeLine, float smallLine)
        {
            //Рисуем 3-ю сторону
            Drawer.Draw(Pens.Yellow, largeLine, Math.PI);
            Drawer.Draw(Pens.Yellow, smallLine * Math.Sqrt(2), Math.PI + Math.PI / 4);
            Drawer.Draw(Pens.Yellow, largeLine, Math.PI + Math.PI);
            Drawer.Draw(Pens.Yellow, largeLine - smallLine, Math.PI + Math.PI / 2);

            Drawer.Change(smallLine, Math.PI - Math.PI);
            Drawer.Change(smallLine * Math.Sqrt(2), Math.PI + 3 * Math.PI / 4);
        }

        public static void DrawFourthSide(float largeLine, float smallLine)
        {
            //Рисуем 4-ую сторону
            Drawer.Draw(Pens.Yellow, largeLine, Math.PI / 2);
            Drawer.Draw(Pens.Yellow, smallLine * Math.Sqrt(2), Math.PI / 2 + Math.PI / 4);
            Drawer.Draw(Pens.Yellow, largeLine, Math.PI / 2 + Math.PI);
            Drawer.Draw(Pens.Yellow, largeLine - smallLine, Math.PI / 2 + Math.PI / 2);

            Drawer.Change(smallLine, Math.PI / 2 - Math.PI);
            Drawer.Change(smallLine * Math.Sqrt(2), Math.PI / 2 + 3 * Math.PI / 4);
        }
    }
}