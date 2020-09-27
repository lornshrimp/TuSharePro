using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Security.DataModels
{
    public abstract class DataBase : Observable
    {
        private Guid id;
        private DateTimeOffset updateTime;
        private bool deleted;
 
        /// <summary>
        /// 已删除
        /// </summary>
        [Required]
        public bool Deleted
        {
            get
            {
                return this.deleted;
            }
            set
            {
                SetProperty<bool>(ref this.deleted, value);
            }
        }
        /// <summary>
        /// 唯一标识符
        /// </summary>
        [Key]
        public virtual Guid Id
        {
            get
            { return id; }
            set
            {
                SetProperty(ref id, value);
            }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTimeOffset UpdateTime
        {
            get
            {
                return this.updateTime;
            }
            set
            {
                if (this.updateTime != value)
                {
                    this.updateTime = value;
                }
            }
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="data"></param>
        public void RefreshData(DataBase data)
        {
            if (data.UpdateTime > this.UpdateTime)
            {
                RefreshDataInternal(data);
            }
        }

        protected virtual void RefreshDataInternal(DataBase data)
        {
            this.Deleted = data.Deleted;
            this.UpdateTime = data.UpdateTime;
        }
        /// <summary>
        /// 验证数据
        /// </summary>
        /// <returns></returns>
        public virtual List<ValidationResult> Validate()
        {
            ValidationContext context = new ValidationContext(this);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(this, context, validationResults, true);
            return validationResults;
        }
    }
}
