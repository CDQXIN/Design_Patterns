using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    /// <summary>
    /// 抽象请求处理类
    /// </summary>
    abstract class AbstractHttpHandler
    {
        /**直接主管审批处理的请假天数*/
        protected int MIN = 1;
        /**部门经理处理的请假天数*/
        protected int MIDDLE = 3;
        /**总经理处理的请假天数*/
        protected int MAX = 30;

        /**领导名称*/
        protected string HandlerName;

        //责任链中的下一个元素
        public AbstractHttpHandler abstractHttpHandler { set; get; }

        /// <summary>
        /// 处理请假方法
        /// </summary>
        /// <param name="request"></param>
        public abstract void HandlerLeaveRequest(LeaveRequest request);
    }

    /// <summary>
    /// 部门经理处理请假
    /// </summary>
    class DeptManagerLeaveHandler : AbstractHttpHandler
    {
        /*private int MIDDLE = 3; // 允许天数
        protected string HandlerName; // 领导名称
        public GManagerLeaveHandler gManagerLeaveHandler { set; get; } // 总经理*/

        public DeptManagerLeaveHandler(string name)
        {
            this.HandlerName = name;
        }

        public override void HandlerLeaveRequest(LeaveRequest request)
        {
            // 1、自己判断先处理
            if (request.LeaveDays > 1 && request.LeaveDays <= this.MIDDLE)
            {
                Console.WriteLine("部门经理:" + HandlerName + ",已批准请假;流程结束。");
                return;
            }

            // 2、给上级领导处理
            if (null != abstractHttpHandler)
            {
                abstractHttpHandler.HandlerLeaveRequest(request);
            }
            else
            {
                Console.WriteLine("拒绝请假");
            }
        }
    }

    /// <summary>
    /// 直接领导处理请假
    /// </summary>
    class DirectLeaderLeaveHandler : AbstractHttpHandler
    {
        /*private int MIN = 1;// 允许天数
        private string HandlerName;// 领导名称

        public DeptManagerLeaveHandler deptManagerLeaveHandler { set; get; } // 部门经理*/

        public DirectLeaderLeaveHandler(string name)
        {
            this.HandlerName = name;
        }

        public override void HandlerLeaveRequest(LeaveRequest request)
        {
            // 1、自己判断先处理
            if (request.LeaveDays <= this.MIDDLE)
            {
                Console.WriteLine("直接主管:" + HandlerName + ",已批准请假;流程结束。");
                return;
            }

            // 2、给上级领导处理
            if (null != abstractHttpHandler)
            {
                abstractHttpHandler.HandlerLeaveRequest(request);
            }
            else
            {
                Console.WriteLine("拒绝请假");
            }
        }
    }

    /// <summary>
    /// 副总经理处理请假
    /// </summary>
    class FManagerLeaveHandler : AbstractHttpHandler
    {
        public FManagerLeaveHandler(string name)
        {
            this.HandlerName = name;
        }

        public override void HandlerLeaveRequest(LeaveRequest request)
        {
            // 1、自己判断先处理
            if (request.LeaveDays > 3 && request.LeaveDays <= 7)
            {
                Console.WriteLine("总经理:" + HandlerName + ",已经处理;流程结束。");
                return;
            }
            // 2、给上级领导处理
            if (null != abstractHttpHandler)
            {
                abstractHttpHandler.HandlerLeaveRequest(request);
            }
            else
            {
                Console.WriteLine("拒绝请假");
            }
        }
    }

    /// <summary>
    /// 总经理处理请假
    /// </summary>
    class GManagerLeaveHandler : AbstractHttpHandler
    {
        /*private int MAX = 30; // 允许天数
        private string HandlerName; // 领导名称*/

        public GManagerLeaveHandler(string name)
        {
            this.HandlerName = name;
        }

        public override void HandlerLeaveRequest(LeaveRequest request)
        {
            // 1、自己判断先处理
            if (request.LeaveDays > 7 && request.LeaveDays <= this.MAX)
            {
                Console.WriteLine("总经理:" + HandlerName + ",已经处理;流程结束。");
                return;
            }
            // 2、给上级领导处理
            if (null != abstractHttpHandler)
            {
                abstractHttpHandler.HandlerLeaveRequest(request);
            }
            else
            {
                Console.WriteLine("拒绝请假");
            }

        }
    }

    /// <summary>
    /// 请假请求
    /// </summary>
    class LeaveRequest
    {
        /// <summary>
        /// 请假天数
        /// </summary>
        public int LeaveDays { set; get; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { set; get; }
    }
}
