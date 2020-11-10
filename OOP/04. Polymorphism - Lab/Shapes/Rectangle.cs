namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double lenght, double width)
        {
            this.Lenght = lenght;
            this.Width = width;
        }

        public double Lenght { get; private set; }
        public double Width { get; private set; }

        public override double CalculateArea()
        {
            return this.Lenght * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * this.Lenght + 2 * this.Width;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
