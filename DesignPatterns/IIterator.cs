using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    /// <summary>
    /// 迭代器接口
    /// </summary>
    public interface IIterator
    {
        /// <summary>
        /// 判断是否还有值
        /// </summary>
        /// <returns></returns>
        public bool HasNext();

        /// <summary>
        /// 获取下一个值
        /// </summary>
        /// <returns></returns>
        public object Next();
    }
    /// <summary>
    /// 获取迭代器
    /// </summary>
    interface IIterable
    {
        public IIterator GetIterator();
    }
    /// <summary>
    /// List集合
    /// </summary>
    class List : IIterable
    {
        public static string[] names = { "张三", "李四", "王五", "赵六", "钱七" };

        /// <summary>
        /// 获取集合内容
        /// </summary>
        /// <returns></returns>
        public string[] GetNames()
        {
            return names;
        }

        public void Add()
        {

        }

        /// <summary>
        /// 获取迭代器
        /// </summary>
        /// <returns></returns>
        public IIterator GetIterator()
        {
            return new ListIterator();
        }

        /// <summary>
        /// List集合内部迭代器
        /// </summary>
        private class ListIterator : IIterator
        {
            int index; // 每一个next都会加1
            public bool HasNext()
            {
                if (index < names.Length)
                {
                    return true;
                }
                return false;
            }

            public object Next()
            {
                if (this.HasNext())
                {
                    return names[index++];
                }
                return null;
            }
        }
    }
}
