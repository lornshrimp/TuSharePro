using System;
using System.Collections.Generic;
using System.Text;

namespace Security.DataModels
{
    /// <summary>
    /// 交易日历
    /// </summary>
    public class TradeCalendar:DataBase
    {
        private Exchange exchange;
        private DateTime calendarDate;
        private bool isOpen;

        /// <summary>
        /// 交易所
        /// </summary>
        public Exchange Exchange { get => exchange; set => SetProperty(ref this.exchange,value); }
        /// <summary>
        /// 日历日期
        /// </summary>
        public DateTime CalendarDate { get => calendarDate; set =>SetProperty(ref this.calendarDate,value); }
        /// <summary>
        /// 是否交易
        /// </summary>
        public bool IsOpen { get => isOpen; set => SetProperty(ref isOpen,value); }
    }
}
