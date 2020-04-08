using SqlSugar;
using System.ComponentModel.DataAnnotations;

namespace AuthPlatform.Gateway.Model
{
    public class GatewaySettings : ViewModelBase
    {
        /// <summary>
        /// 网关名称
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "网关名称")]
        [Display(Name = "网关名称")]
        public string GatewayName { get; set; }

        /// <summary>
        /// 全局请求默认Key
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "全局请求默认Key")]
        [Display(Name = "全局请求默认Key")]
        public string RequestKey { get; set; }

        /// <summary>
        /// 请求路由根地址
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "请求路由根地址")]
        [Display(Name = "请求路由根地址")]
        public string RequestRoutingRootHost { get; set; }

        /// <summary>
        /// 服务发现全局配置
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "服务发现全局配置")]
        [Display(Name = "服务发现全局配置")]
        public string ServiceDiscoverySettings { get; set; }

        /// <summary>
        /// 全局负载均衡配置
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "全局负载均衡配置")]
        [Display(Name = "全局负载均衡配置")]
        public string BalancingSettings { get; set; }

        /// <summary>
        /// Http请求配置
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "Http请求配置")]
        [Display(Name = "Http请求配置")]
        public string HttpRequestSettings { get; set; }

        /// <summary>
        /// 请求安全配置
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "请求安全配置")]
        [Display(Name = "请求安全配置")]
        public string RequestSafeSettings { get; set; }

        /// <summary>
        /// 是否默认配置
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "是否默认配置")]
        [Display(Name = "是否默认配置")]
        public bool IsDefault { get; set; }
    }
}
