using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Collections.ObjectModel;

namespace Security.DataModels
{
    /// <summary>
    /// 证券信息
    /// </summary>
    public class SecurityInfo:DataBase
    {
        private string symbol;
        private string name;
        private TradingMethod tradingMethod;
        private SecurityType securityType;
        private string providerKey;

        /// <summary>
        /// 证券代码
        /// </summary>
        [Required]
        public string Code { get => symbol; set => SetProperty(ref symbol, value); }
        /// <summary>
        /// 证券名称
        /// </summary>
        public string Name { get => name; set => SetProperty(ref name, value); }
        /// <summary>
        /// 交易方式
        /// </summary>
        public TradingMethod TradingMethod { get => tradingMethod; set => SetProperty(ref tradingMethod,value); }
        /// <summary>
        /// 证券类型
        /// </summary>
        public SecurityType SecurityType { get => securityType; set => SetProperty(ref securityType,value); }
        /// <summary>
        /// 数据供应商的数据代码
        /// </summary>
        [NotMapped]
        public string ProviderKey { get => providerKey; set => SetProperty(ref providerKey, value); }

        protected override void RefreshDataInternal(DataBase data)
        {
            base.RefreshDataInternal(data);
            var newData = data as SecurityInfo;
            this.Code = newData.Code;
            this.Name = newData.Name;
            this.TradingMethod = newData.TradingMethod;
            this.SecurityType = newData.SecurityType;
        }
    }
}
