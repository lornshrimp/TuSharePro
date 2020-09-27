using Microsoft.VisualStudio.TestTools.UnitTesting;
using TuSharePro;
using System.Linq;
using Security.DataModels;

namespace TuSahrePro.Tests
{
    [TestClass]
    public class BasicInfoTest:TestBase
    {
        CoreApi client = null;

        [TestMethod]
        public void TestStock_Basic()
        {
            TestStock_Basic(StockStatus.Listing);
            TestStock_Basic(StockStatus.Pause);
            TestStock_Basic(StockStatus.Delisting);
        }
        public void TestStock_Basic(StockStatus stockStatus)
        {
            var data = client.stock_basic(null,stockStatus);
            var stocks = data.ChinaStocks;
            var count = stocks.Where(o => o.Exchange == Security.DataModels.Exchange.SSE).Count();
            Assert.IsTrue(stocks.Count > 0);
            Assert.IsTrue(count > 0);
            Assert.IsTrue(stocks.Where(o => o.Exchange == Security.DataModels.Exchange.SZSE).Count() > 0);
            foreach (var item in stocks)
            {
                Assert.AreEqual(stockStatus, item.ListStatus);
            }
        }
        [TestMethod()]
        public void trade_calTest()
        {
            var data = client.trade_cal();
            var calendars = data.TradeCalendars;
            Assert.IsTrue(calendars.Count > 0);
            data = client.trade_cal(Security.DataModels.Exchange.SZSE, new System.DateTime(2019, 1, 1), new System.DateTime(2020, 11, 20));
            calendars = data.TradeCalendars;
            Assert.IsTrue(calendars.Count > 0);
        }
        [TestInitialize]
        public void InitTest()
        {
            client = new TuSharePro.CoreApi();
            client.Token = token;
        }

    }
}
