using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;


namespace JD.CRS.Course.Dto
{

    [AutoMapTo(typeof(Entitys.Course))]
    public class CreateUpdateCourseDto : EntityDto<int>
    {

        /// <summary>
        /// 客商编号
        /// </summary>
        [StringLength(50)]
        public string Code { get; set; }
        /// <summary>
        /// 客商名称
        /// </summary>
        [StringLength(150)]
        public string Name { get; set; }
        /// <summary>
        /// 拼音码
        /// </summary>
        [StringLength(150)]
        public string PinyinCode { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [StringLength(200)]
        public string Address { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [StringLength(50)]
        public string Contact { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [StringLength(50)]
        public string Phone { get; set; }
        /// <summary>
        /// 微信
        /// </summary>
        [StringLength(50)]
        public string Wechat { get; set; }
        /// <summary>
        /// 所属区域
        /// </summary>
        [StringLength(50)]
        public string Area { get; set; }
        /// <summary>
        /// 客商类别
        /// </summary>
        public int? CustomerType { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(200)]
        public string Remarks { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? Status { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [StringLength(50)]
        public string CreateName { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? UpdateDate { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [StringLength(50)]
        public string UpdateName { get; set; }
        public DateTime CreationTime { get; set; }
    }
}