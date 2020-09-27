using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataModels
{
    /// <summary>
    /// 交易方式
    /// </summary>
    public enum TradingMethod
    {
        /// <summary>
        /// 场内
        /// </summary>
        Onsite,
        /// <summary>
        /// 场外
        /// </summary>
        Outsite
    }
    public enum SecurityType
    {
        /// <summary>
        /// 股票
        /// </summary>
        Stock,
        /// <summary>
        /// 基金
        /// </summary>
        Fund,
        /// <summary>
        /// 指数
        /// </summary>
        Index
    }
}
