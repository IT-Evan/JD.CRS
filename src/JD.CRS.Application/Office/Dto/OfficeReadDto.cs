using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using JD.CRS.Entitys;
using System;
using System.ComponentModel.DataAnnotations;

namespace JD.CRS.Office.Dto
{

    [AutoMapFrom(typeof(Entitys.Office))]
    public class OfficeReadDto : EntityDto<int>
    {
        /// <summary>
        /// 办公室编号
        /// </summary>
        [StringLength(50)]
        public string Code { get; set; }
        /// <summary>
        /// 办公室名称
        /// </summary>
        [StringLength(150)]
        public string Name { get; set; }
        /// <summary>
        /// 办公室位置
        /// </summary>
        [StringLength(150)]
        public string Location { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(200)]
        public string Remarks { get; set; }
        /// <summary>
        /// 状态: 0 有效, 1 无效
        /// </summary>
        public StatusCode Status { get; set; }
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