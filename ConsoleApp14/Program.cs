using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphicsWindow.Title = "Turtle game";
            GraphicsWindow.BackgroundColor = "CornflowerBlue";
            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;

            GraphicsWindow.BackgroundColor = "White";
            GraphicsWindow.FillRectangle(0, 0, GraphicsWindow.Width, 30);

            int satiety = 0;
            int max_satiety = 100;
            int energy_step = 10;

            GraphicsWindow.FontSize = 100;
            GraphicsWindow.BrushColor = "Black";
            GraphicsWindow.DrawText(10, 10, "");

            Turtle.PenUp();

            GraphicsWindow.BrushColor = "Green";
            var eat = Shapes.AddRectangle(10, 10);
            int x = 200, y = 200;
            Shapes.Move(eat, x, y);

            Random rand = new Random();

            while (true)
            {
                Turtle.Move(10);
                if (Turtle.X >= x && Turtle.X <= x + 10 && Turtle.Y >= y && Turtle.Y <= y + 10)
                {
                    x = rand.Next(0, GraphicsWindow.Width - 10);
                    y = rand.Next(0, GraphicsWindow.Height - 10);
                    Shapes.Move(eat, x, y);

                    Turtle.Speed += 1;
                    satiety += energy_step;

                    GraphicsWindow.BrushColor = "Red";
                    GraphicsWindow.FillRectangle(0, 0, GraphicsWindow.Width, 30);
                    GraphicsWindow.BrushColor = "Black";
                    GraphicsWindow.FontSize = 10;
                    GraphicsWindow.DrawText(10, 10, $"{satiety}/{max_satiety} \t\t speed: {Turtle.Speed}");
                }
                if (Turtle.X <= 0 || Turtle.X >= GraphicsWindow.Width || Turtle.Y <= 30 || Turtle.Y >= GraphicsWindow.Height)
                {
                    GraphicsWindow.Clear();
                    GraphicsWindow.BrushColor = "Red";
                    GraphicsWindow.FontSize = 100;
                    GraphicsWindow.DrawText(40, 40, "Game over");
                    break;
                }
                if (satiety == max_satiety)
                {
                    GraphicsWindow.Clear();
                    GraphicsWindow.BrushColor = "Red";
                    GraphicsWindow.FontSize = 100;
                    GraphicsWindow.DrawText(40, 40, "Win");
                    break;
                }
            }
        }
        private static void GraphicsWindow_KeyDown()
        {
            if (GraphicsWindow.LastKey == "Up")
                Turtle.Angle = 0;
            else if (GraphicsWindow.LastKey == "Right")
                Turtle.Angle = 90;
            else if (GraphicsWindow.LastKey == "Down")
                Turtle.Angle = 180;
            else if (GraphicsWindow.LastKey == "Left")
                Turtle.Angle = 270;
        }
    }
}