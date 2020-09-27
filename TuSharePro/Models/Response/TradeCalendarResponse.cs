using Security.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace TuSharePro.Models.Response
{
    public class TradeCalendarResponse:_BaseResponse
    {
        private const string exchangeName = "exchange";
        private const string calendarDateName = "cal_date";
        private const string isOpenName = "is_open";

        public ICollection<TradeCalendar> TradeCalendars
        {
            get
            {
                var fields = this.Data.fields;
                var exchangeIndex = fields.IndexOf(exchangeName);
                var calendarIndex = fields.IndexOf(calendarDateName);
                var isOpenIndex = fields.IndexOf(isOpenName);
                if (this.Code == 0)
                {
                    var calendars = new List<TradeCalendar>();
                    foreach (var dataItem in this.Data.items)
                    {
                        var calendar = new TradeCalendar()
                        {
                            CalendarDate = DateTime.ParseExact(dataItem[calendarIndex].ToString(), "yyyyMMdd", null),
                            Deleted = false
                        };
                        switch (dataItem[exchangeIndex].ToString())
                        {
                            case "SSE":
                                calendar.Exchange = Exchange.SSE;
                                break;
                            case "SZSE":
                                calendar.Exchange = Exchange.SZSE;
                                break;
                            case "XHKG":
                                calendar.Exchange = Exchange.HKEX;
                                break;
                            default:
                                break;
                        }
                        switch (dataItem[isOpenIndex].ToString())
                        {
                            case "0":
                                calendar.IsOpen = false;
                                break;
                            default:
                                calendar.IsOpen = true;
                                break;
                        }
                        calendars.Add(calendar);
                    }
                    return calendars;
                }
                else return null;
            }
        }
    }
}
