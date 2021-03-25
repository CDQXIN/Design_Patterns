using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Plus
{
    /// <summary>
    /// 抽象工厂
    /// 核心：在一个工厂里聚合多个同类产品。
    /// </summary>
    public abstract class IAbstractFactory
    {
        public abstract IColor getColor(String color);
        public abstract IShape getShape(String shape);
    }
    /// <summary>
    ///  颜色接口
    /// </summary>
    public interface IColor
    {
        /// <summary>
        /// 填充颜色方法
        /// </summary>
        public void Fill();
    }
    class Blue : IColor
    {
        public void Fill()
        {
            Console.WriteLine("Inside Blue::fill() method.");
        }
    }
    class Green : IColor
    {
        public void Fill()
        {
            Console.WriteLine("Inside Green::fill() method.");
        }
    }
    class Red : IColor
    {
        public void Fill()
        {
            Console.WriteLine("Inside Red::fill() method.");
        }
    }
    public interface IShape
    {
        public void Draw();
    }
    class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Inside Circle::draw() method.");
        }
    }
    class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Inside Rectangle::draw() method.");
        }
    }
    class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Inside Square::draw() method.");
        }
    }

    class ColorFactory : IAbstractFactory
    {
        public override IColor getColor(string color)
        {
            if (color == null)
            {
                return null;
            }
            if (color.Equals("RED"))
            {
                return new Red();
            }
            else if (color.Equals("GREEN"))
            {
                return new Green();
            }
            else if (color.Equals("BLUE"))
            {
                return new Blue();
            }
            return null;
        }

        public override IShape getShape(string shape)
        {
            return null;
        }
    }

    /// <summary>
    /// 形状工厂
    /// </summary>
    class ShapeFactory : IAbstractFactory
    {
        public override IColor getColor(string color)
        {
            return null;
        }

        public override IShape getShape(string shape)
        {
            if (shape == null)
            {
                return null;
            }
            if (shape.Equals("CIRCLE"))
            {
                return new Circle();
            }
            else if (shape.Equals("RECTANGLE"))
            {
                return new Rectangle();
            }
            else if (shape.Equals("SQUARE"))
            {
                return new Square();
            }
            return null;
        }
    }

    /// <summary>
    /// 具体工厂选择器
    /// </summary>
    class FactoryProducer
    {
        public static IAbstractFactory getFactory(String choice)
        {
            if (choice.Equals("SHAPE"))
            {
                return new ShapeFactory();
            }
            else if (choice.Equals("COLOR"))
            {
                return new ColorFactory();
            }
            return null;
        }
    }

}
