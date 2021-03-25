using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    /// <summary>
    /// 空对象数据库
    /// </summary>
    class NullDatabase : AbstractDatabase
    {
        public NullDatabase(string name)
        {
            this.DatabaseName = name;
        }

        public override string GetURL()
        {
            return "数据库不存在";
        }
    }
    /// <summary>
    /// 抽象数据库类
    /// </summary>
    public abstract class AbstractDatabase
    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        protected string DatabaseName;

        /// <summary>
        /// 数据库url
        /// </summary>
        /// <returns></returns>
        public abstract string GetURL();
    }
    class DatabaseFactory
    {
        public static string[] names = { "mysql", "sqlserver", "oarcle" };

        public static AbstractDatabase GetDatabase(string name)
        {
            if (names[0].Equals(name))
            {
                return new MysqlDatabase(name);
            }
            else if (names[1].Equals(name))
            {
                return new SqlServerDatabase(name);
            }
            else if (names[2].Equals(name))
            {
                return new OarcleDatabase(name);
            }
            else
            {
                return new NullDatabase("Null");
            }
        }
    }
    /// <summary>
    /// mysql数据库
    /// </summary>
    class MysqlDatabase : AbstractDatabase
    {
        public MysqlDatabase(string name)
        {
            this.DatabaseName = name;
        }

        public override string GetURL()
        {
            return "mysql数据库url";
        }
    }
    /// <summary>
    /// SqlServer数据库
    /// </summary>
    class SqlServerDatabase : AbstractDatabase
    {
        public SqlServerDatabase(string name)
        {
            this.DatabaseName = name;
        }

        public override string GetURL()
        {
            return "sqlserver数据库url";
        }
    }

    /// <summary>
    /// Oarcle数据库
    /// </summary>
    class OarcleDatabase : AbstractDatabase
    {
        public OarcleDatabase(string name)
        {
            this.DatabaseName = name;
        }

        public override string GetURL()
        {
            return "Oarcle数据库url";
        }
    }

}
