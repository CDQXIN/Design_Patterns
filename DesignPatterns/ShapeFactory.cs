using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    /// <summary>
    /// 形状接口
    /// </summary>
    public interface IShape
    {
        public void Draw();
    }
    /// <summary>
    /// 圆形
    /// </summary>
    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("画出一个圆形");
        }
    }
    /// <summary>
    /// 矩形
    /// </summary>
    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("画出一个矩形区域");
        }
    }
    /// <summary>
    /// 正方形
    /// </summary>
    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("画出一个正方形区域");
        }
    }
    /// <summary>
    /// 核心：接口选择
    /// 核心条件：创建过程在其子类执行
    /// 优点： 1、一个调用者想创建一个对象，只要知道其名称就可以了。 
    ///        2、扩展性高，如果想增加一个产品，只要扩展一个工厂类就可以。 
    ///        3、屏蔽产品的具体实现，调用者只关心产品的接口。
    /// 缺点：每次增加一个产品时，都需要增加一个具体类和对象实现工厂，
    /// 使得系统中类的个数成倍增加，在一定程度上增加了系统的复杂度，
    /// 同时也增加了系统具体类的依赖。
    /// 这并不是什么好事
    /// 1、类成倍增加，增加系统复杂度
    /// 2、增加系统具体类依赖
    /// </summary>
    class ShapeFactory
    {
        //使用 getShape 方法获取形状类型的对象
        public IShape getShape(String shapeType)
        {
            if (shapeType == null)
            {
                return null;
            }
            if (shapeType.Equals("CIRCLE"))
            {
                return new Circle();
            }
            else if (shapeType.Equals("RECTANGLE"))
            {
                return new Rectangle();
            }
            else if (shapeType.Equals("SQUARE"))
            {
                return new Square();
            }
            return null;
        }
    }
}
