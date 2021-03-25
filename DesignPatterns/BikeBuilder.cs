using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    /// <summary>
    /// 建造者
    /// </summary>
    class BikeBuilder
    {
        private Bike mBike = new Bike();

        public BikeBuilder BuildFrame()
        {
            mBike.frame = new AlloyFrame();
            return this;
        }

        public BikeBuilder BuildSeat()
        {
            mBike.seat = new DermisSeat();
            return this;
        }

        public BikeBuilder BuildTire()
        {
            mBike.tire = new SolidTire();
            return this;
        }

        public Bike Build()
        {
            return mBike;
        }
    }

    /// <summary>
    /// 建造者
    /// </summary>
    class OfoBikeBuilder
    {
        private Bike mBike = new Bike();

        public OfoBikeBuilder BuildFrame()
        {
            mBike.frame = new AlloyFrame();
            return this;
        }

        public OfoBikeBuilder BuildSeat()
        {
            mBike.seat = new DermisSeat();

            return this;
        }

        public OfoBikeBuilder BuildTire()
        {
            mBike.tire = new SolidTire();
            return this;
        }

        public Bike Build()
        {
            return mBike;
        }
    }

    class Bike
    {
        /// <summary>
        /// 自行车框架
        /// </summary>
        public IFrame frame { set; get; }
        /// <summary>
        /// 自行车座椅
        /// </summary>
        public ISeat seat { set; get; }
        /// <summary>
        /// 自行车 轮胎
        /// </summary>
        public ITire tire { set; get; }

        public Bike()
        {

        }

        public Bike(IFrame frame, ISeat seat, ITire tire)
        {
            this.frame = frame;
            this.seat = seat;
            this.tire = tire;
        }
    }

    /// <summary>
    /// 自行车轮胎
    /// </summary>
    interface ITire
    {
    }
    /// <summary>
    /// 自行车座椅
    /// </summary>
    interface ISeat
    {
    }
    /// <summary>
    /// 自行车框架
    /// </summary>
    interface IFrame
    {
    }
    /// <summary>
    /// 结实的轮胎
    /// </summary>
    class SolidTire : ITire
    {
    }
    /// <summary>
    /// 真皮座椅
    /// </summary>
    class DermisSeat : ISeat
    {
    }
    /// <summary>
    /// 合金自行车框架
    /// </summary>
    class AlloyFrame : IFrame
    {

    }
}
