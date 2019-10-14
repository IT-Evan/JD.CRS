using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JD.CRS.Entitys
{
    public class Department : Entity<int>, IHasCreationTime
    {
        public Department()
        {
            this.Code = string.Empty;
            this.Name = string.Empty;
            this.InstructorCode = null;
            this.Budget = 0;
            this.Remarks = string.Empty;
            this.Status = StatusCode.Enabled;
            this.CreateDate = null;
            this.CreateName = string.Empty;
            this.UpdateDate = null;
            this.UpdateName = string.Empty;
            this.CreationTime = Clock.Now;
        }

        /// <summary>
        /// 院系编号
        /// </summary>
        [StringLength(50)]
        public string Code { get; set; }
        /// <summary>
        /// 院系名称
        /// </summary>
        [StringLength(150)]
        public string Name { get; set; }
        /// <summary>
        /// 院系主任
        /// </summary>
        [StringLength(50)]
        public string InstructorCode { get; set; }
        /// <summary>
        /// 开支预算
        /// </summary>
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public int Budget { get; set; }
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