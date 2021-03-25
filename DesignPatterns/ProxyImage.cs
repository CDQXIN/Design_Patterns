using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    /// <summary>
    /// 代理图片
    /// </summary>
    public class ProxyImage : Image
    {
        private RealImage realImage;
        private string fileName;

        public ProxyImage(string fileName)
        {
            this.fileName = fileName;
        }

        public void Display()
        {
            // 1、加载磁盘一次
            if (realImage == null)
            {
                realImage = new RealImage(fileName);
            }

            // 2、直接显示图片
            realImage.Display();
        }
    }
    /// <summary>
    /// 图片类
    /// </summary>
    public interface Image
    {
        /// <summary>
        /// 图片显示方法
        /// </summary>
        public void Display();
    }
    /// <summary>
    /// 图片类磁盘加载 AOP
    /// </summary>
    public class RealImage : Image
    {
        private string fileName; // 文件名
        private string fileContent;// 文件内容

        public RealImage(string fileName)
        {
            this.fileName = fileName;
            loadFromDisk(fileName);
        }

        public void Display()
        {
            Console.WriteLine("显示: " + fileContent);
        }

        /// <summary>
        /// 磁盘加载图片
        /// </summary>
        /// <param name="fileName"></param>
        private void loadFromDisk(string fileName)
        {
            Console.WriteLine("加载: " + fileName);
            fileContent = "图片加载完成";
        }
    }
}
