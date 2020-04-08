using SqlSugar;
using System.ComponentModel.DataAnnotations;

namespace AuthPlatform.Model
{
    /// <summary>
    /// 路由分类表
    /// </summary>
    public class RouttingClassify : ViewModelBase
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "分类名称")]
        [Display(Name = "分类名称")]
        public string ClassifyName { get; set; }

        /// <summary>
        /// 分类描述
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "分类描述")]
        [Display(Name = "分类描述")]
        public string ClassifyDescriber { get; set; }

        /// <summary>
        /// 上级分类
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "上级分类")]
        [Display(Name = "上级分类")]
        public string UpleverClassify { get; set; }
    }
}
