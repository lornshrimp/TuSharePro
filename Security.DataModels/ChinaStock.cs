using System;
using System.Collections.Generic;
using System.Text;

namespace Security.DataModels
{
    /// <summary>
    /// 中国股票
    /// </summary>
    public class ChinaStock : Stock
    {
        private string area;
        private string industry;
        private Market market;
        private IsHS is_hs;
        /// <summary>
        /// 所在地域
        /// </summary>
        public string Area
        {
            get => area; set
            {
                SetProperty<string>(ref this.area, value);
            }
        }
        /// <summary>
        /// 所属行业
        /// </summary>
        public string Industry
        {
            get => industry; set
            {
                SetProperty<string>(ref this.industry, value);
            }
        }
        /// <summary>
        /// 市场类型
        /// </summary>
        public Market Market { get => market; set
            {
                SetProperty<Market>(ref this.market, value);
            }
        }
        /// <summary>
        /// 沪深港通
        /// </summary>
        public IsHS Is_hs { get => is_hs; set
            {
                SetProperty<IsHS>(ref this.is_hs, value);
            }
        }
        protected override void RefreshDataInternal(DataBase data)
        {
            base.RefreshDataInternal(data);
            var newData = data as ChinaStock;
            this.Area = newData.Area;
            this.Industry = newData.Industry;
            this.Market = newData.Market;
            this.Is_hs = newData.Is_hs;
        }
    }
    public enum Market
    {
        /// <summary>
        /// 主板
        /// </summary>
        Mainboard,
        /// <summary>
        /// 中小板
        /// </summary>
        SMEboard,
        /// <summary>
        /// 创业板
        /// </summary>
        GEMboard,
        /// <summary>
        /// 科创板
        /// </summary>
        Innovationboard
    }
    public enum IsHS
    {
        /// <summary>
        /// 否
        /// </summary>
        N,
        /// <summary>
        /// 沪股通
        /// </summary>
        H,
        /// <summary>
        /// 深股通
        /// </summary>
        S
    }
}
