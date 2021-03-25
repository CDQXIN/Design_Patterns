using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    /// <summary>
    /// 过滤器（标准器）
    /// </summary>
    public interface ICriteria
    {
        /// <summary>
        /// 人进行过滤
        /// </summary>
        /// <param name="persons"></param>
        /// <returns></returns>
        public List<Person> meetCriteria(List<Person> persons);
    }
    /// <summary>
    /// 人类
    /// </summary>
    public class Person
    {
        private string name; // 姓名
        private string gender;// 性别
        private string maritalStatus;// 婚姻状态

        public Person(string name, string gender, string maritalStatus)
        {
            this.name = name;
            this.gender = gender;
            this.maritalStatus = maritalStatus;
        }

        public string getName()
        {
            return name;
        }
        public string getGender()
        {
            return gender;
        }
        public string getMaritalStatus()
        {
            return maritalStatus;
        }
    }

    /// <summary>
    /// 多条件标准
    /// 1、重用代码
    /// 2、提高扩展
    /// </summary>
    public class AndCriteria : ICriteria
    {
        private ICriteria criteria;
        private ICriteria otherCriteria;

        public AndCriteria(ICriteria criteria, ICriteria otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }

        public List<Person> meetCriteria(List<Person> persons)
        {
            List<Person> firstCriteriaPersons = criteria.meetCriteria(persons);
            return otherCriteria.meetCriteria(firstCriteriaPersons);
        }
    }

    /// <summary>
    /// 女性标准
    /// </summary>
    public class FemaleCriteria : ICriteria
    {
        public List<Person> meetCriteria(List<Person> persons)
        {
            List<Person> malePersons = new List<Person>();
            foreach (Person person in persons)
            {
                if (person.getGender().Equals("Female"))
                {
                    malePersons.Add(person);
                }
            }
            return malePersons;
        }
    }

    /// <summary>
    /// 男性标准
    /// </summary>
    public class MaleCriteria : ICriteria
    {
        public List<Person> meetCriteria(List<Person> persons)
        {
            List<Person> malePersons = new List<Person>();
            foreach (Person person in persons)
            {
                if (person.getGender().Equals("Male"))
                {
                    malePersons.Add(person);
                }
            }
            return malePersons;
        }
    }

    /// <summary>
    /// 符合某一个条件标准
    /// </summary>
    public class OrCriteria : ICriteria
    {
        private ICriteria criteria;
        private ICriteria otherCriteria;

        public OrCriteria(ICriteria criteria, ICriteria otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }

        public List<Person> meetCriteria(List<Person> persons)
        {
            List<Person> firstCriteriaItems = criteria.meetCriteria(persons);
            List<Person> otherCriteriaItems = otherCriteria.meetCriteria(persons);

            foreach (Person person in otherCriteriaItems)
            {
                if (!firstCriteriaItems.Contains(person))
                {
                    firstCriteriaItems.Add(person);
                }
            }
            return firstCriteriaItems;
        }
    }

    /// <summary>
    /// 单身标准
    /// </summary>
    public class SingleCriteria : ICriteria
    {
        public List<Person> meetCriteria(List<Person> persons)
        {
            List<Person> malePersons = new List<Person>();
            foreach (Person person in persons)
            {
                if (person.getMaritalStatus().Equals("Single"))
                {
                    malePersons.Add(person);
                }
            }
            return malePersons;
        }
    }
}
