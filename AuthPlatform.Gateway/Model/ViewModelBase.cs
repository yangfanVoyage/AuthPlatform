using SqlSugar;
using System;
using System.Diagnostics.CodeAnalysis;

namespace AuthPlatform.Gateway.Model
{
    public abstract class ViewModelBase : IEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, ColumnDescription = "主键ID")]
        [NotNull]
        public string ID { get; set; }

        /// <summary>
        /// 当前状态
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "当前状态")]
        [NotNull]
        public int CurrentState { get; set; }


        public ViewModelBase()
        {
            ID = new Guid().ToString();
        }
    }
}
