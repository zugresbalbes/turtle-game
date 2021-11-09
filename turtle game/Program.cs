using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;

namespace Turtle_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;
            GraphicsWindow.Height = 500;
            GraphicsWindow.Width = 600;
            GraphicsWindow.Top = 300;
            GraphicsWindow.Left = 600;
            Turtle.PenUp();

            GraphicsWindow.BrushColor = "Red";
            var eat = Shapes.AddRectangle(10, 10);
            GraphicsWindow.PenColor = "Green";
            int scale0X = 10;
            int scale0Y = 30;
            int scaleX = GraphicsWindow.Width - 10;
            int scaleY = GraphicsWindow.Height - 10;

            Shapes.AddLine(scale0X, scale0Y, scale0X, scaleY);
            Shapes.AddLine(scale0X, scale0Y, scaleX, scale0Y);
            Shapes.AddLine(scale0X, scaleY, scaleX, scaleY);
            Shapes.AddLine(scaleX, scale0Y, scaleX, scaleY);
            Random rnd = new Random();
            int moveX = rnd.Next(scale0X + 10, scaleX - 10);
            int moveY = rnd.Next(scale0Y + 10, scaleY - 10);
            Shapes.Move(eat, moveX, moveY);
            int scoreN = 0;
            GraphicsWindow.BrushColor = "Blue";
            var score = Shapes.AddText("Счет: " + scoreN.ToString());
            Shapes.Move(score, (GraphicsWindow.Width / 2) - 20, (scale0Y / 2) - 5);
            while (scoreN < 10)
            {

                Turtle.Move(5);
                if ((Turtle.X - moveX) < 20 && (Turtle.Y - moveY) < 20 && (moveX - Turtle.X) < 10 && (moveY - Turtle.Y) < 10)
                {
                    scoreN++;
                    moveX = rnd.Next(scale0X + 10, scaleX - 10);
                    moveY = rnd.Next(scale0Y + 10, scaleY - 10);
                    Shapes.Move(eat, moveX, moveY);
                    if (Turtle.Speed < 10)
                    {
                        Turtle.Speed++;
                    }

                    if (scoreN >= 10)
                    {
                        Shapes.Move(score, 1000, 1000);
                        score = Shapes.AddText("ПОБЕДА!!!");
                        Shapes.Move(score, (GraphicsWindow.Width / 2) - 20, (scale0Y / 2) - 5);
                        scoreN++;
                    }
                    else
                    {
                        Shapes.Move(score, 1000, 1000);
                        score = Shapes.AddText("Счет: " + scoreN.ToString());
                        Shapes.Move(score, (GraphicsWindow.Width / 2) - 20, (scale0Y / 2) - 5);
                    }
                }
                if (Turtle.X >= scaleX)
                {
                    Turtle.X = scale0X;
                }
                else if (Turtle.X <= scale0X)
                {
                    Turtle.X = scaleX;
                }
                else if (Turtle.Y <= scale0Y)
                {
                    Turtle.Y = scaleY;
                }
                else if (Turtle.Y >= scaleY)
                {
                    Turtle.Y = scale0Y;
                }
            }

        }

        private static void GraphicsWindow_KeyDown()
        {
            if (GraphicsWindow.LastKey == "Up")
            {
                Turtle.Angle = 0;
            }
            else if (GraphicsWindow.LastKey == "Right")
            {
                Turtle.Angle = 90;
            }
            else if (GraphicsWindow.LastKey == "Down")
            {
                Turtle.Angle = 180;
            }
            else if (GraphicsWindow.LastKey == "Left")
            {
                Turtle.Angle = 270;
            }
        }
    }
}