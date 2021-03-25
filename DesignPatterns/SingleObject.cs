using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    /// <summary>
    /// 单例类
    ///核心条件(必要条件)
    /// 1、构造函数私有化
    /// 2、自己创建自己
    ///类型
    ///1、饿汉式:
    ///2、懒汉式:
    ///   2.1 线程安全式
    ///   2.2 线程不安全式
    ///3、双检锁/双重校验锁式
    /// </summary>
    class SingleObject
    {
        //2、创建 SingleObject 的一个对象
        private static SingleObject instance = new SingleObject();

        //1、让构造函数为 private，这样该类就不会被实例化(核心代码)
        private SingleObject() { }

        //3、获取唯一可用的对象
        public static SingleObject GetInstance()
        {
            return instance;
        }

        public void ShowMessage()
        {
            // 1、产生事件
            Console.WriteLine("Hello 单例!");
        }
    }

    /// <summary>
    /// 双检索式单例
    /// </summary>
    class DoubleCheckLockSingleton
    {
        private volatile static DoubleCheckLockSingleton instance = null;
        private static readonly object padlock = new object();

        private DoubleCheckLockSingleton()
        {
        }

        public static DoubleCheckLockSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new DoubleCheckLockSingleton();
                        }
                    }
                }
                return instance;
            }
        }
    }

    /// <summary>
    /// 饿汉式单例
    /// </summary>
    class EagerSingleton
    {
        private static EagerSingleton instance = new EagerSingleton();
        private EagerSingleton() { }
        public static EagerSingleton getInstance()
        {
            return instance;
        }
    }

    /// <summary>
    /// 懒汉式
    /// </summary>
    class LazySingleton
    {
    }
    /// <summary>
    /// 线程不安全懒汉式
    /// </summary>
    class NoSafetyLazySingleton
    {
        private static NoSafetyLazySingleton instance = null;
        private NoSafetyLazySingleton() { }

        public static NoSafetyLazySingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NoSafetyLazySingleton();
                }
                return instance;
            }
        }
    }

    /// <summary>
    /// 线程安全懒汉式
    /// </summary>
    class SafetyLazySingleton
    {
        private static SafetyLazySingleton instance = null;
        private static readonly object padlock = new object();
        private SafetyLazySingleton() { }
        public static SafetyLazySingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SafetyLazySingleton();
                    }
                    return instance;
                }
            }
        }
    }

    /// <summary>
    /// 数据库连接类
    /// </summary>
    class Connection
    {
        private int status = 0;

        public Connection()
        {
            Thread.Sleep(1000);
            Console.WriteLine($"创建Connection耗时1s");
        }


        public void Close()
        {
            Thread.Sleep(1000);
            Console.WriteLine($"关闭Connection耗时1s");
        }
    }

    /// <summary>
    /// 连接池(数据源)
    /// </summary>
    class PoolDataSource
    {
        private static PoolDataSource poolDataSource = new PoolDataSource();

        private PoolDataSource()
        {
            // 初始化连接数量
            connections.Add(new Connection());
            connections.Add(new Connection());
            connections.Add(new Connection());
            connections.Add(new Connection());
            connections.Add(new Connection());
        }

        //获取唯一可用的对象
        public static PoolDataSource GetInstance()
        {
            return poolDataSource;
        }

        /// <summary>
        /// connection集合(10个)
        /// </summary>
        private IList<Connection> connections = new List<Connection>();

        /*public PoolDataSource()
        {
            // 初始化连接数量
            connections.Add(new Connection());
            connections.Add(new Connection());
            connections.Add(new Connection());
            connections.Add(new Connection());
            connections.Add(new Connection());
        }*/

        public Connection GetConnection()
        {
            return connections[0];
        }
    }
}
