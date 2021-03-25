using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMenu();
            Console.Write("请输入选项：");
            string strKey = Console.ReadLine();
            switch (strKey)
            {
                case "1":
                    ShapeFactory shapeFactory = new ShapeFactory();

                    //获取 Circle 的对象，并调用它的 draw 方法
                    //IShape shape1 = shapeFactory.getShape("CIRCLE");

                    //调用 Circle 的 draw 方法
                    //shape1.Draw();

                    //获取 Rectangle 的对象，并调用它的 draw 方法
                    IShape shape2 = shapeFactory.getShape("RECTANGLE");

                    //调用 Rectangle 的 draw 方法
                    shape2.Draw();

                    ////获取 Square 的对象，并调用它的 draw 方法
                    //IShape shape3 = shapeFactory.getShape("SQUARE");
                    break;
                case "2":

                    //获取颜色工厂
                    DesignPatterns.Plus.IAbstractFactory colorFactory = DesignPatterns.Plus.FactoryProducer.getFactory("COLOR");

                    //获取颜色为 Red 的对象
                    DesignPatterns.Plus.IColor color1 = colorFactory.getColor("RED");

                    //调用 Red 的 fill 方法
                    color1.Fill();

                    DesignPatterns.Plus.IAbstractFactory shapeFactory1 = DesignPatterns.Plus.FactoryProducer.getFactory("SHAPE");

                    //获取形状为 Circle 的对象
                    DesignPatterns.Plus.IShape shape1 = shapeFactory1.getShape("CIRCLE");

                    //调用 Circle 的 draw 方法
                    shape1.Draw();
                    break;
                case "3":
                    #region 策略模式
                    Context context = new Context(new OperationAdd());
                    Console.WriteLine("10 + 5 = " + context.executeStrategy(10, 5));

                    context = new Context(new OperationSubtract());
                    Console.WriteLine("10 - 5 = " + context.executeStrategy(10, 5));

                    context = new Context(new OperationMultiply());
                    Console.WriteLine("10 * 5 = " + context.executeStrategy(10, 5));
                    #endregion
                    break;
                case "4":
                    #region 原型模式
                    // 1、从数据库加载视频进行缓存(文件服务器) 缓存速度
                    // 解决性能问题
                    VideoCache.loadCache();

                    // 2、对缓存视频分别做不通下载
                    Video clonedVideo = (Video)VideoCache.getVideo("1");
                    Video clonedVideo2 = (Video)VideoCache.getVideo("1");
                    IDownload download = new GreenWaterDownload();
                    download.DownloadVideo(clonedVideo);
                    IDownload download2 = new RedWaterDownload();
                    download.DownloadVideo(clonedVideo2);
                    #endregion
                    break;
                case "5":
                    #region 组合模式
                    // 1、树形机构的场景，使用组合模式
                    Employee CEO = new Employee("张三", "CEO", 30000);

                    Employee headMarketing = new Employee("李四", "技术经理", 20000);

                    Employee headSales = new Employee("王五", "销售经理", 20000);

                    Employee clerk1 = new Employee("赵六", "销售", 10000);
                    Employee clerk2 = new Employee("钱七", "销售", 10000);

                    Employee salesExecutive1 = new Employee("Tony", "技术", 10000);
                    Employee salesExecutive2 = new Employee("Mark", "技术", 10000);

                    CEO.add(headSales);
                    CEO.add(headMarketing);

                    headSales.add(clerk1);
                    headSales.add(clerk2);

                    headMarketing.add(salesExecutive1);
                    headMarketing.add(salesExecutive2);

                    //打印该组织的所有员工
                    Console.WriteLine(CEO);
                    foreach (Employee headEmployee in CEO.getSubordinates())
                    {
                        Console.WriteLine(headEmployee);
                        foreach (Employee employee in headEmployee.getSubordinates())
                        {
                            Console.WriteLine(employee);
                        }
                    }
                    #endregion
                    break;
                case "6":
                    #region 过滤器模式
                    List<Person> persons = new List<Person>();

                    persons.Add(new Person("张三", "Male", "Single"));
                    persons.Add(new Person("李四", "Male", "Married"));
                    persons.Add(new Person("王五", "Female", "Married"));
                    persons.Add(new Person("赵六", "Female", "Single"));
                    persons.Add(new Person("钱七", "Male", "Single"));
                    persons.Add(new Person("Tony", "Male", "Single"));

                    ICriteria male = new MaleCriteria();
                    ICriteria female = new FemaleCriteria();
                    ICriteria single = new SingleCriteria();
                    ICriteria singleMale = new AndCriteria(single, male);
                    ICriteria singleOrFemale = new OrCriteria(single, female);

                    Console.WriteLine("Males: ");
                    PrintPersons(male.meetCriteria(persons));

                    Console.WriteLine("\nFemales: ");
                    PrintPersons(female.meetCriteria(persons));

                    Console.WriteLine("\nSingle Males: ");
                    PrintPersons(singleMale.meetCriteria(persons));

                    Console.WriteLine("\nSingle Or Females: ");
                    PrintPersons(singleOrFemale.meetCriteria(persons));
                    #endregion
                    break;
                case "7":
                    #region 建造者模式
                    // 1、创建车建造者
                    BikeBuilder bikeBuilder = new BikeBuilder();
                    bikeBuilder.BuildFrame();
                    bikeBuilder.BuildSeat();
                    bikeBuilder.BuildTire();

                    // 2、构建车
                    Bike bike = bikeBuilder.Build();
                    #endregion
                    break;
                case "8":
                    #region 装饰器模式
                    // 1、正常支付回调
                    IPayCallback payCallback = new PayCallback();

                    // 2、短信装饰
                    IPayCallback payCallbackDecoration = new SmsPayCallbackDecorator(payCallback);

                    // 3、发送邮件
                    IPayCallback payCallbackMail = new MailPayCallbackDecorator(payCallbackDecoration);

                    //* Console.WriteLine("正常回调");
                    //payCallback.CallbackHandler();

                    //Console.WriteLine("装饰回调");
                    //payCallbackDecoration.CallbackHandler();

                    payCallbackMail.CallbackHandler();
                    #endregion
                    break;
                case "9":
                    #region 代理模式
                    Image realimage = new RealImage("test_10mb.jpg");


                    Image image = new ProxyImage("test_10mb.jpg");

                    // 图像将从磁盘加载
                    image.Display();
                    Console.WriteLine("------------");
                    // 图像不需要从磁盘加载
                    image.Display();


                    // 1、静态代理和装饰器模式非常像，都是做包装
                    // 2、动态代理 

                    // 优点：1、动态扩展原有对象的功能
                    // 缺点：2、说不到，占内存。
                    #endregion
                    break;
                case "10":
                    #region 责任链模式
                    // 1、创建请假类
                    LeaveRequest request = new LeaveRequest();
                    request.LeaveDays = 4;
                    request.Name = "张三";

                    // 2、链式处理
                    AbstractHttpHandler directLeaderLeaveHandler = new DirectLeaderLeaveHandler("直接领导");
                    AbstractHttpHandler deptManagerLeaveHandler = new DeptManagerLeaveHandler("部门经理");
                    AbstractHttpHandler fManagerLeaveHandler = new FManagerLeaveHandler("副总经理");
                    AbstractHttpHandler gManagerLeaveHandler = new GManagerLeaveHandler("总经理");

                    directLeaderLeaveHandler.abstractHttpHandler = deptManagerLeaveHandler;
                    deptManagerLeaveHandler.abstractHttpHandler = fManagerLeaveHandler;
                    fManagerLeaveHandler.abstractHttpHandler = gManagerLeaveHandler;

                    // 3、处理请假
                    directLeaderLeaveHandler.HandlerLeaveRequest(request);
                    #endregion
                    break;
                case "11":
                    #region 迭代器模式
                    List list = new List();

                // 2、迭代器遍历
                for (IIterator iter = list.GetIterator(); iter.HasNext();)
                {
                    string name = (string)iter.Next();
                    Console.WriteLine("Name : " + name);
                }
                    #endregion
                    break;
                case "12":
                    #region 空对象模式
                    AbstractDatabase customer1 = DatabaseFactory.GetDatabase("mysql");
                    AbstractDatabase customer2 = DatabaseFactory.GetDatabase("sqlserver");
                    AbstractDatabase customer3 = DatabaseFactory.GetDatabase("oarcle");
                    AbstractDatabase customer4 = DatabaseFactory.GetDatabase("db2");

                    Console.WriteLine("数据库切换");
                    Console.WriteLine(customer1.GetURL());
                    Console.WriteLine(customer2.GetURL());
                    Console.WriteLine(customer3.GetURL());
                    Console.WriteLine(customer4.GetURL());
                    #endregion
                    break;
                case "13":
                    #region 外观模式
                    AggregationMicroServiceFacade aggregationMicroServiceFacade = new AggregationMicroServiceFacade();
                    aggregationMicroServiceFacade.BuyProduct();


                    // 总结：
                    // 1、抽象概念：这个对象有哪些角色
                    // 2、总结优点：解决了什么问题
                    // 3、总结缺点：这个对象会导致什么问题(从这个对象本身出发)
                    #endregion
                    break;
                case "14":
                    #region 适配器模式
                    PictureServerAdpater pictureServerAdpater = new PictureServerAdpater();
                    pictureServerAdpater.UploadPicture("mp4", "/123123.mp4");
                    #endregion
                    break;
                case "15":
                    #region 模板方法模式
                    // 1、创建日志文件类
                    LogFile logFile = new LogFile();

                    // 2、保存日志文件到云服务器
                    AzureCloudServer cloudServer = new AzureCloudServer();
                    #endregion
                    break;
                case "16":
                    #region 观察者模式
                    // 1、创建学生客户端
               IObserver lStudentClient = new LStudentClient("李学生");
               IObserver zStudentClient = new ZStudentClient("张学生");
               IObserver JStudentClient = new ZStudentClient("jack学生");

               // 2、创建老师
               Teacher teacher = new Teacher();
               teacher.AddObserver(lStudentClient);
               teacher.AddObserver(zStudentClient);
               teacher.AddObserver(JStudentClient);

               // 3、发送通告
               teacher.SendNotice(new Notice { Message = "考试" });
                    #endregion
                    break;
                case "17":
                    #region 中介者模式
                     // 1、创建中房间类
               RoomMediator roomMediator = new RoomMediator();

               // 2、创建客户端
               ZSClient clientZ = new ZSClient("张三");
               clientZ.roomMediator = roomMediator;
               LSClient clientL = new LSClient("李四");
               clientL.roomMediator = roomMediator;
               ZSClient clientW = new ZSClient("王五");
               clientW.roomMediator = roomMediator;
               HHClient clientH = new HHClient("吼吼");
               clientW.roomMediator = roomMediator;

               roomMediator.RegistryClient(clientZ);
               roomMediator.RegistryClient(clientL);
               roomMediator.RegistryClient(clientW);
               roomMediator.RegistryClient(clientH);

               // 3、客户端发送消息
               clientZ.Send("搞金花");
               clientL.Send("8点不见不散");
                    #endregion
                    break;
                case "18":
                    #region 单例模式
                    // 1、创建Connection
                    for (int i = 0; i < 100; i++)
                    {
                        Connection connection = new Connection();
                        connection.Close();
                    }

                    // 2、创建PoolDataSource
                    /* for (int i = 0; i < 100; i++)
                     {
                         PoolDataSource poolDataSource = new PoolDataSource();
                         Connection connection =  poolDataSource.GetConnection();
                     }*/

                    /*for (int i = 0; i < 100; i++)
                    {
                        PoolDataSource poolDataSource = PoolDataSource.GetInstance();
                        poolDataSource.GetConnection();
                    }*/
                    #endregion
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }
        public static void ShowMenu() 
        {
            Console.WriteLine("1、工厂模式");
            Console.WriteLine("2、抽象工厂模式");
            Console.WriteLine("3、策略模式");
            Console.WriteLine("4、原型模式");
            Console.WriteLine("5、组合模式"); 
            Console.WriteLine("6、过滤器模式");
            Console.WriteLine("7、建造者模式");
            Console.WriteLine("8、装饰器模式");
            Console.WriteLine("9、代理模式");
            Console.WriteLine("10、责任链模式");
            Console.WriteLine("11、迭代器模式");
            Console.WriteLine("12、空对象模式");
            Console.WriteLine("13、外观模式");
            Console.WriteLine("14、适配器模式");
            Console.WriteLine("15、模板方法模式");
            Console.WriteLine("16、观察者模式");
            Console.WriteLine("17、中介者模式");
            Console.WriteLine("18、单例模式");
        }

        public static void PrintPersons(List<Person> persons)
        {
            foreach (Person person in persons)
            {
                Console.WriteLine("Person : [ Name : " + person.getName()
                   + ", Gender : " + person.getGender()
                   + ", Marital Status : " + person.getMaritalStatus()
                   + " ]");
            }
        }
    }
}
