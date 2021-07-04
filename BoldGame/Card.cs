using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoldGame
{
    public class  Card
    {
        public enum Shape
        {
            Square,
            Circle,
            Hexagon
        }
        public enum Size
        {
            Large,
            Medium,
            Small
        }
        public enum Color
        {
            Blue,
            Pink,
            Yellow
        }
        public enum Pattern
        {
            Zigzag,
            Triangles,
            Stripes
        }


        public Shape MyShape { get; set; }
        public Size MySize { get; set; }
        public Color MyColor { get; set; }
        public Pattern MyPattern { get; set; }
        public string ImagePath { get; set; }

        public Card() { }

        public Card(Shape shape, Size size, Color color, Pattern pattern, string path)
        {
            MyColor = color;
            MyShape = shape;
            MySize = size;
            MyPattern = pattern;
            ImagePath = path;
        }
        public override string ToString()
        {
            return MyShape + " " + MySize + " " + MyColor + " " + MyPattern;
        }

    }
}
