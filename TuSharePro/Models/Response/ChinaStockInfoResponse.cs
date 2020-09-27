using Security.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuSharePro.Models.Response
{
    public class ChinaStockInfoResponse : _BaseResponse
    {
        private const string ts_codeName = "ts_code";
        private const string symbolName = "symbol";
        private const string nameName = "name";
        private const string areaName = "area";
        private const string industryName = "industry";
        private const string marketName = "market";
        private const string list_dateName = "list_date";
        public StockStatus CurrentStockStatus { get; set; }

        public ICollection<ChinaStock> ChinaStocks
        {
            get
            {
                var fields = this.Data.fields;
                int tsCodeIndex = fields.IndexOf(ts_codeName);
                int symbolIndox = fields.IndexOf(symbolName);
                int nameIndex = fields.IndexOf(nameName);
                int areaIndex = fields.IndexOf(areaName);
                int industryIndex = fields.IndexOf(industryName);
                int marketIndex = fields.IndexOf(marketName);
                int list_dateIndex = fields.IndexOf(list_dateName);
                if (this.Code == 0)
                {
                    var chinaStocks = new List<ChinaStock>();
                    foreach (var item in this.Data.items)
                    {
                        var chinaStock = new ChinaStock
                        {
                            Area = item[areaIndex] is null ? null: item[areaIndex].ToString(),
                            Code = item[symbolIndox].ToString(),
                            Deleted = false,
                            Id = Guid.Empty,
                            Industry = item[industryIndex] is null ? null : item[industryIndex].ToString(),
                            ListStatus = this.CurrentStockStatus,
                            Listdate = DateTime.ParseExact(item[list_dateIndex].ToString(), "yyyyMMdd", null)
                        };
                        if (item[marketIndex] != null)
                        {
                            switch (item[marketIndex].ToString())
                            {
                                case "主板":
                                    chinaStock.Market = Market.Mainboard;
                                    break;
                                case "中小板":
                                    chinaStock.Market = Market.SMEboard;
                                    break;
                                case "创业板":
                                    chinaStock.Market = Market.GEMboard;
                                    break;
                                case "科创板":
                                    chinaStock.Market = Market.Innovationboard;
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (item[tsCodeIndex].ToString().EndsWith("SZ"))
                        {
                            chinaStock.Exchange = Exchange.SZSE;
                        }
                        else if (item[tsCodeIndex].ToString().EndsWith("SH"))
                        {
                            chinaStock.Exchange = Exchange.SSE;
                        }
                        else
                        {
                            chinaStock.Exchange = Exchange.HKEX;
                        }
                        chinaStock.Name = item[nameIndex].ToString();
                        chinaStock.SecurityType = SecurityType.Stock;
                        chinaStock.TradingMethod = TradingMethod.Onsite;
                        chinaStock.ProviderKey = item[tsCodeIndex].ToString();
                        chinaStocks.Add(chinaStock);
                    }
                    return chinaStocks;
                }
                return null;
            }
        }
    }
}
