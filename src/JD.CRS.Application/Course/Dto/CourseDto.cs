using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using JD.CRS.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace JD.CRS.Course.Dto
{

    [AutoMapFrom(typeof(Entitys.Course))]
    public class CourseDto : EntityDto<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string PinyinCode { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Wechat { get; set; }
        public string Area { get; set; }
        public int? CustomerType { get; set; }
        public string Remarks { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateName { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateName { get; set; }
        public DateTime CreationTime { get; set; }
    }
}