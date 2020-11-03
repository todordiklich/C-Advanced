using System;
using System.Text;

namespace BoxData
{
    public class Box
    {
        private const string EXC_MSG = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Length 
        {
            get 
            {
                return this.length;
            }

            private set
            {
                this.Validate(value, nameof(Length));

                this.length = value;
            }
        }
        public double Width 
        {
            get 
            {
                return this.width;
            }

            private set
            {
                this.Validate(value, nameof(Width));

                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                this.Validate(value, nameof(Height));

                this.height = value;
            }
        }

        public string Results()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Surface Area - {this.CalculateSurfaceArea():F2}")
                .AppendLine($"Lateral Surface Area - {this.CalculateLateralSurfaceArea():F2}")
                .AppendLine($"Volume - {this.CalculateVolume():F2}");

            return sb.ToString().TrimEnd();
        }

        private double CalculateLateralSurfaceArea()
        {
            return (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }

        private double CalculateSurfaceArea()
        {
            return (2 * this.Length * this.Width) + this.CalculateLateralSurfaceArea();
        }

        private double CalculateVolume()
        {
            return this.Length * this.Width * this.Height;
        }

        private void Validate(double value, string name)
        {
            if (value < 0 || value > 100)
            {
                throw new IndexOutOfRangeException(String.Format(EXC_MSG, name));
            }
        }
    }
}
