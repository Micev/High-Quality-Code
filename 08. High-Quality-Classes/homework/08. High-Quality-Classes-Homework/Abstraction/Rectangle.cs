using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (Width < 0)
                {
                    throw new ArithmeticException("Width can't be negative");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (height < 0)
                {
                    throw new ArithmeticException("Height can't be negative");
                }
                {

                }
                this.height = value;
            }
        }

        public override double CalcPerimeter()
        {
            return (2 * this.Width) + (2 * this.Height);
        }

        public override double CalcSurface()
        {
            return this.Width * this.Height;
        }


    }
}
