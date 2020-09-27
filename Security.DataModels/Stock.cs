using System;
using System.Collections.Generic;
using System.Text;

namespace Security.DataModels
{
    /// <summary>
    /// 股票
    /// </summary>
    public class Stock : SecurityInfo
    {
        private DateTime listdate;
        private StockStatus listStatus;
        private Exchange exchange;
        /// <summary>
        /// 上市日期
        /// </summary>
        public DateTime Listdate
        {
            get => listdate; set
            {
                SetProperty<DateTime>(ref this.listdate, value);
            }
        }
        /// <summary>
        /// 上市状态
        /// </summary>
        public StockStatus ListStatus
        {
            get => listStatus; set
            {
                SetProperty<StockStatus>(ref this.listStatus, value);
            }
        }
        /// <summary>
        /// 交易所代码
        /// </summary>
        public Exchange Exchange
        {
            get => exchange; set
            {
                SetProperty<Exchange>(ref this.exchange, value);
            }
        }
        protected override void RefreshDataInternal(DataBase data)
        {
            base.RefreshDataInternal(data);
            var newData = data as Stock;
            this.Listdate = newData.Listdate;
            this.ListStatus = newData.ListStatus;
            this.Exchange = newData.Exchange;
        }
    }
    public enum StockStatus
    {
        /// <summary>
        /// 上市
        /// </summary>
        Listing,//上市
        /// <summary>
        /// 退市
        /// </summary>
        Delisting,//退市
        /// <summary>
        /// 暂停上市
        /// </summary>
        Pause//暂停上市
    }
    public enum Exchange
    {
        /// <summary>
        /// 上交所
        /// </summary>
        SSE,
        /// <summary>
        /// 深交所
        /// </summary>
        SZSE,
        /// <summary>
        /// 港交所
        /// </summary>
        HKEX
    }
}
