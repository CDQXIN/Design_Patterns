using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    /// <summary>
    /// 支付回调接口
    /// </summary>
    public interface IPayCallback
    {
        /// <summary>
        /// 回调处理方法
        /// </summary>
        void CallbackHandler();
    }
    /// <summary>
    /// 默认支付回调处理
    /// </summary>
    public class PayCallback : IPayCallback
    {
        public void CallbackHandler()
        {
            Console.WriteLine($"数据库写入支付处理信息");

            /* // 1、发送短信
             SendSms();
             // 2、发送邮件
             SendMail();
             // 3、记录支付日志
             SavePayLogs();*/
            ///
        }

    }
    public abstract class AbstactPayCallbackDecorator
    {
        protected IPayCallback payCallback;

        public AbstactPayCallbackDecorator(IPayCallback payCallback)
        {
            this.payCallback = payCallback;
        }
    }

    /// <summary>
    /// 短信支付回调装饰器
    /// </summary>
    public class MailPayCallbackDecorator : AbstactPayCallbackDecorator, IPayCallback
    {

        public MailPayCallbackDecorator(IPayCallback payCallback) : base(payCallback)
        {
        }

        public void CallbackHandler()
        {
            // 1、调用原有方法
            payCallback.CallbackHandler();

            // 2、发送短信
            SendMail();
        }

        private void SendMail()
        {
            Console.WriteLine($"发送邮件成功");
        }
    }

     /// <summary>
    /// 短信支付回调装饰器
    /// </summary>
    public class SmsPayCallbackDecorator : AbstactPayCallbackDecorator,IPayCallback
    {

        public SmsPayCallbackDecorator(IPayCallback payCallback) : base(payCallback)
        {
        }

        public void CallbackHandler()
        {
            // 1、调用原有方法
            payCallback.CallbackHandler();

            // 2、发送短信
            SendSms();
        }

        private void SendSms()
        {
            Console.WriteLine($"支付短信发送成功");
        }
    }

}
