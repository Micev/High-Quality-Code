using System;

namespace Abstraction
{
    abstract class Figure : IFigure
    {
        public abstract double CalcSurface();

        public abstract double CalcPerimeter();
    }
}
