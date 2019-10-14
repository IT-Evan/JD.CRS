using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using JD.CRS.Entitys;
using System;
using System.ComponentModel.DataAnnotations;

namespace JD.CRS.Department.Dto
{

    [AutoMapFrom(typeof(Entitys.Department))]
    public class DepartmentDto : EntityDto<int>
    {
        /// <summary>
        /// 课程编号
        /// </summary>
        [StringLength(50)]
        public string Code { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        [StringLength(150)]
        public string Name { get; set; }
        /// <summary>
        /// 课程积分
        /// </summary>
        [Range(0, 10)]
        public int Credits { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(200)]
        public string Remarks { get; set; }
        /// <summary>
        /// 状态: 0 正常, 1 废弃
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