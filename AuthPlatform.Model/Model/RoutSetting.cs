using SqlSugar;
using System.ComponentModel.DataAnnotations;

namespace AuthPlatform.Model
{
    /// <summary>
    /// 路由配置表
    /// </summary>
    public class RoutSetting : ViewModelBase
    {
        /// <summary>
        /// 路径模板
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "路径模板")]
        [Display(Name = "路径模板")]
        public string PathTemplate { get; set; }

        /// <summary>
        /// 请求方法
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "请求方法")]
        [Display(Name = "请求方法")]
        public string RequestMethod { get; set; }

        /// <summary>
        /// 域名地址
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "域名地址")]
        [Display(Name = "域名地址")]
        public string DomainHost { get; set; }

        /// <summary>
        /// 授权配置
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "授权配置")]
        [Display(Name = "授权配置")]
        public string PowerSetting { get; set; }

        /// <summary>
        /// 默认请求Key
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "默认请求Key")]
        [Display(Name = "默认请求Key")]
        public string RequestKey { get; set; }
    }
}
