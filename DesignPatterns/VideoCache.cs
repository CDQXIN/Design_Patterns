using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace DesignPatterns
{
    /// <summary>
    /// 视频缓存
    /// </summary>
    class VideoCache
    {
        private static Dictionary<string, Video> videoMap = new Dictionary<string, Video>();

        public static Video getVideo(string videoId)
        {
            Video cachedVideo = videoMap[videoId];
            return (Video)cachedVideo.Clone();
        }

        // 对每种形状都运行数据库查询，并创建该视频对象
        // 例如，我们要添加两种视频
        public static void loadCache()
        {
            Video video = new Video();
            video.Id = "1";
            video.Content = "战狼2";
            videoMap.Add(video.Id, video);

            Video video1 = new Video();
            video.Id = "2";
            video.Content = "英雄本色";
            videoMap.Add(video.Id, video);
        }
    }

    /// <summary>
    /// 视频类
    /// </summary>
    [Serializable]
    public class Video : ICloneable
    {
        public string Id { set; get; } // 视频编号
        public string Content { set; get; } // 视频内容

        /// <summary>
        /// 克隆方法
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            // 1、浅拷贝
            // 1、克隆Video对象
            object clone = this.MemberwiseClone();

            // 2、深拷贝
            // 1、中间流
            MemoryStream memoryStream = new MemoryStream();
            // 2、序列化类
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, this);

            // 3、设置流读取的位置
            memoryStream.Position = 0;

            return binaryFormatter.Deserialize(memoryStream);
            // return clone;
        }

    }
    /// <summary>
    /// 视频下载
    /// </summary>
    public interface IDownload
    {
        /// <summary>
        /// 下载视频方法
        /// </summary>
        public void DownloadVideo(Video video);
    }
    /// <summary>
    /// 绿色水印视频
    /// </summary>
    class GreenWaterDownload : IDownload
    {
        public void DownloadVideo(Video video)
        {
            Console.WriteLine($"{video.Content}");
            Console.WriteLine("视频上添加绿色水印");
        }
    }
    /// <summary>
    /// 视频上添加红色水印
    /// </summary>
    class RedWaterDownload : IDownload
    {
        public void DownloadVideo(Video video)
        {
            Console.WriteLine($"{video.Content}");
            Console.WriteLine("视频上添加红色水印");
        }
    }
}
