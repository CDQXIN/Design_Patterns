using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    /// <summary>
    /// 聚合微服务(外观模式)
    /// </summary>
    class AggregationMicroServiceFacade
    {
        private OrderMicroService orderMicroService;
        private PayMicroService payMicroService;
        private ProductMicroService productMicroService;
        private StockMicroService stockMicroService;

        public AggregationMicroServiceFacade()
        {
            this.orderMicroService = new OrderMicroService();
            this.payMicroService = new PayMicroService();
            this.productMicroService = new ProductMicroService();
            this.stockMicroService = new StockMicroService();
        }

        /// <summary>
        /// 购买商品
        /// </summary>
        public void BuyProduct()
        {
            productMicroService.GetProduct();
            orderMicroService.CreateOrder();
            stockMicroService.ReduceStock();
            payMicroService.Pay();
        }

    }

    /// <summary>
    /// 订单微服务
    /// </summary>
    class OrderMicroService
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        public void CreateOrder()
        {
            Console.WriteLine($"创建订单");
        }
    }

    /// <summary>
    /// 支付微服务
    /// </summary>
    class PayMicroService
    {
        /// <summary>
        /// 支付
        /// </summary>
        public void Pay()
        {
            Console.WriteLine($"支付成功");
        }

    }

    /// <summary>
    /// 商品微服务
    /// </summary>
    class ProductMicroService
    {
        /// <summary>
        /// 获取商品
        /// </summary>
        public void GetProduct()
        {
            Console.WriteLine($"获取商品");
        }

    }

    /// <summary>
    /// 库存微服务
    /// </summary>
    class StockMicroService
    {
        /// <summary>
        /// 扣减库存
        /// </summary>
        public void ReduceStock()
        {
            Console.WriteLine($"扣减商品库存");
        }

    }

}
