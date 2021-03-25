using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    /// <summary>
    /// 图片服务适配器
    /// 1、两种方式
    ///   1.1 使用继承
    ///   1.2 使用组合
    ///   
    /// 总结：
    /// 1、目标类 ： PictureServer
    /// 2、适配器类 :  PictureServerAdpater 
    /// 3、被适配的类 : VideoUploadServer
    /// 
    /// 外观模式是组合功能，适配是改变原有方法的行为
    /// </summary>
    class PictureServerAdpater : IPictureServer
    {
        /// <summary>
        /// 视频上传服务(被适配类)
        /// </summary>
        private VideoUploadServer videoUploadServer;

        public PictureServerAdpater()
        {
            this.videoUploadServer = new VideoUploadServer();
        }

        /// <summary>
        /// 目标接口(适配视频上传)
        /// </summary>
        /// <param name="pictureType"></param>
        /// <param name="pictureName"></param>
        public void UploadPicture(string pictureType, string pictureName)
        {
            videoUploadServer.UploadVideo(pictureName);
        }
    }

    /// <summary>
    /// 图片上传接口
    /// </summary>
    interface IPictureServer
    {
        public void UploadPicture(string pictureType, string pictureName);
    }

    /// <summary>
    /// 图片服务
    /// </summary>
    class PictureServer : IPictureServer
    {
        private PictureServerAdpater pictureServerAdpater;

        public PictureServer()
        {
            pictureServerAdpater = new PictureServerAdpater();
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="pictureType"></param>
        /// <param name="pictureName"></param>
        public void UploadPicture(string pictureType, string pictureName)
        {
            if (pictureType.Equals("mp4"))
            {
                pictureServerAdpater.UploadPicture(pictureType, pictureName);
            }
            else
            {
                Console.WriteLine($"图片名称:{pictureName},图片类型：{pictureType}，上传成功");
            }
        }
    }

    /// <summary>
    /// 图片服务
    /// </summary>
    class VideoUploadServer
    {
        /// <summary>
        /// 上传视频
        /// </summary>
        /// <param name="videoName"></param>
        public void UploadVideo(string videoName)
        {
            Console.WriteLine($"视频名称:{videoName}，上传成功");
        }
    }


}
