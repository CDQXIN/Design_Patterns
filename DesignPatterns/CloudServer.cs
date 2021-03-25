using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    /// <summary>
    /// 云服务器模板
    /// </summary>
    abstract class CloudServer
    {
        /// <summary>
        /// 保存方法(通用方案)
        /// </summary>
        public void SaveCloudServer(LogFile logFile)
        {
            //1、打开文件
            OpenFile();

            //2、建立远程连接
            Connection();

            //3、序列化
            Serialize();

            //4、传输
            Transport();
        }

        protected abstract void OpenFile();
        protected abstract void Connection();
        protected abstract void Serialize();
        protected abstract void Transport();
    }

    /// <summary>
    /// 阿里云服务
    /// </summary>
    class AliCloudServer : CloudServer
    {
        protected override void Connection()
        {
            Console.WriteLine("建立socket连接");
        }

        protected override void OpenFile()
        {
            Console.WriteLine("打开日志文件");
        }

        protected override void Serialize()
        {
            Console.WriteLine("json序列化日志文件");
        }

        protected override void Transport()
        {
            Console.WriteLine("socket传输日志文件");
        }
    }

    /// <summary>
    /// 微软云服务
    /// </summary>
    class AzureCloudServer : CloudServer
    {
        protected override void Connection()
        {
            Console.WriteLine("建立grpc连接");
        }

        protected override void OpenFile()
        {
            Console.WriteLine("打开日志文件");
        }

        protected override void Serialize()
        {
            Console.WriteLine("xml序列化日志文件");
        }

        protected override void Transport()
        {
            Console.WriteLine("grpc传输日志文件");
        }
    }

    /// <summary>
    /// 日志文件信息
    /// </summary>
    class LogFile
    {
    }

}
