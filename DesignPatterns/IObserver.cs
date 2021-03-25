using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    /// <summary>
    /// 观察者
    /// </summary>
    abstract class IObserver
    {
        public abstract void Receive(Notice notice);
    }

    /// <summary>
    /// j学生客户端
    /// </summary>
    class JStudentClient : IObserver
    {
        private string Name;

        public JStudentClient(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 准备考试
        /// </summary>
        public override void Receive(Notice notice)
        {
            Console.WriteLine($"{Name}收到通知：{notice.Message},开始准备考试");
        }
    }

    /// <summary>
    /// 李学生客户端
    /// </summary>
    class LStudentClient : IObserver
    {
        private string Name; // 学生姓名

        public LStudentClient(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 接受公告
        /// </summary>
        public override void Receive(Notice notice)
        {
            Console.WriteLine($"{Name}收到通知：{notice.Message},开始准备考试");
        }
    }

    /// <summary>
    /// 公告
    /// </summary>
    class Notice
    {
        /// <summary>
        /// 公告消息()
        /// </summary>
        public string Message { set; get; }
    }

    /// <summary>
    /// 老师
    /// 学生
    /// 公司
    /// </summary>
    class Teacher
    {
        /*public ZStudentClient zStudentClient { set; get; }
        public LStudentClient lStudentClient { set; get; }*/

        // 依赖抽象
        public IList<IObserver> observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void SendNotice(Notice notice)
        {
            // 2、通知所有学生
            /*zStudentClient.Receive(notice);
            lStudentClient.Receive(notice);*/

            // 创建一个事件
            foreach (IObserver observer in observers)
            {
                observer.Receive(notice);
            }

            // 1、多线程
            // 2、线程池
        }
    }

    /// <summary>
    /// 张学生客户端
    /// </summary>
    class ZStudentClient : IObserver
    {
        private string Name;

        public ZStudentClient(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 准备考试
        /// </summary>
        public override void Receive(Notice notice)
        {
            Console.WriteLine($"{Name}收到通知：{notice.Message},开始准备考试");
        }
    }

}
