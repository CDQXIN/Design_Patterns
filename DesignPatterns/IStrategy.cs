using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    /// <summary>
    /// 策略模式
    /// 数字计算策略
    /// </summary>
    public interface IStrategy
    {
        /// <summary>
        /// 策略计算方法
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public int DoOperation(int num1, int num2);
    }
    /// <summary>
    /// 策略选择类
    /// </summary>
    public class Context
    {
        private IStrategy strategy;

        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public int executeStrategy(int num1, int num2)
        {
            return strategy.DoOperation(num1, num2);
        }
    }
    /// <summary>
    /// 1、加法策略
    /// </summary>
    public class OperationAdd : IStrategy
    {
        public int DoOperation(int num1, int num2)
        {
            return num1 + num2;
        }
    }

    /// <summary>
    /// 4、除法策略
    /// </summary>
    public class OperationDivision : IStrategy
    {
        public int DoOperation(int num1, int num2)
        {
            return num1 / num2;
        }
    }

    /// <summary>
    /// 3、乘法策略
    /// </summary>
    public class OperationMultiply : IStrategy
    {
        public int DoOperation(int num1, int num2)
        {
            return num1 * num2;
        }
    }

    /// <summary>
    /// 2、减法策略
    /// </summary>
    public class OperationSubtract : IStrategy
    {
        public int DoOperation(int num1, int num2)
        {
            return num1 - num2;
        }
    }
}
