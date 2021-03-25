using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    /// <summary>
    /// 房间中介者
    /// 作用：协调客户端
    /// </summary>
    class RoomMediator
    {
        /// <summary>
        /// 聊天客户端
        /// </summary>
        public IList<IClient> clients = new List<IClient>();

        /// <summary>
        /// 注册客户端
        /// </summary>
        public void RegistryClient(IClient client)
        {
            clients.Add(client);
        }

        /// <summary>
        /// 发送消息(群发)
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            foreach (IClient client in clients)
            {
                // 1、所有客户端接收到消息 
                client.Receive(message);
            }
        }


        /// <summary>
        /// 发送消息(群发) == 私聊消息
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message, IClient client1)
        {
            foreach (IClient client in clients)
            {
                // 1、所有客户端接收到消息 
                client.Receive(message);
            }
        }
    }

    /// <summary>
    /// HH客户端
    /// </summary>
    class HHClient : IClient
    {
        private string Name;

        public HHClient(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 依赖中介者
        /// </summary>
        public RoomMediator roomMediator { set; get; }

        public void Receive(string message)
        {
            Console.WriteLine($"{Name}接受到消息：{message}");
        }

        public void Send(string message)
        {
            // 将消息发送到房间
            roomMediator.SendMessage(message);
        }
    }

    /// <summary>
    /// 群聊客户端
    /// </summary>
    interface IClient
    {
        /// <summary>
        /// 接受消息
        /// </summary>
        public void Receive(string message);

        /// <summary>
        /// 发送消息
        /// </summary>
        public void Send(string message);
    }

    /// <summary>
    /// 李四客户端
    /// </summary>
    class LSClient : IClient
    {
        private string Name;

        public LSClient(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 依赖中介者
        /// </summary>
        public RoomMediator roomMediator { set; get; }

        public void Receive(string message)
        {
            Console.WriteLine($"{Name}接受到消息：{message}");
        }

        public void Send(string message)
        {
            // 将消息发送到房间
            roomMediator.SendMessage(message);
        }
    }

    /// <summary>
    /// 王五客户端客户端
    /// </summary>
    class WWClient : IClient
    {
        private string Name;

        public WWClient(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 依赖中介者
        /// </summary>
        public RoomMediator roomMediator { set; get; }

        public void Receive(string message)
        {
            Console.WriteLine($"{Name}接受到消息：{message}");
        }

        public void Send(string message)
        {
            // 将消息发送到房间
            roomMediator.SendMessage(message);
        }
    }

    /// <summary>
    /// 张三客户端
    /// </summary>
    class ZSClient : IClient
    {
        private string Name;

        public ZSClient(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 依赖中介者
        /// </summary>
        public RoomMediator roomMediator { set; get; }

        public void Receive(string message)
        {
            Console.WriteLine($"{Name}接受到消息：{message}");
        }

        public void Send(string message)
        {
            // 将消息发送到房间
            roomMediator.SendMessage(message);
        }
    }

}
