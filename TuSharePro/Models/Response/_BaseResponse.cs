using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TuSharePro.Models.Response
{
    public class _BaseResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        [JsonProperty("msg")]
        public object Message { get; set; }
        [JsonProperty("data")]
        public Data Data { get; set; }

        
        public DataTable ToDataTable()
        {
            DataTable dt = new DataTable();
            if (this.Code == 0) { 
                foreach (string field in this.Data.fields)
                {
                    dt.Columns.Add(field);
                }
                foreach (List<object> obj in this.Data.items)
                {
                    dt.Rows.Add(obj.ToArray());
                }
            }
            else
            {
                dt.Columns.Add("Code");
                dt.Columns.Add("Error");
                dt.Rows.Add(this.Code,this.Message);
                
            }
            return dt;
        }
    }
    public class Data
    {
        public List<string> fields { get; set; }
        public List<List<object>> items { get; set; }
    }
}
