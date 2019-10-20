using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using JD.CRS.Entitys;
using System;
using System.ComponentModel.DataAnnotations;

namespace JD.CRS.Instructor.Dto
{

    [AutoMapFrom(typeof(Entitys.Instructor))]
    public class InstructorReadDto : EntityDto<int>
    {
        /// <summary>
        /// 教职员编号
        /// </summary>
        [StringLength(50)]
        public string Code { get; set; }
        /// <summary>
        /// 教职员姓名
        /// </summary>
        [StringLength(150)]
        public string Name { get; set; }
        /// <summary>
        /// 入职日期
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? HireDate { get; set; }
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