using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JD.CRS.Paged
{
    /// <summary>
    /// PagedSortedAndFilteredInputDto
    /// </summary>
    public class PagedSortedAndFilteredInputDto : PagedAndSortedInputDto
    {
        public string Filter { get; set; }
        //接收DataTables的参数
        public int Draw { get; set; }
        public int Length
        {
            get
            {
                return this.MaxResultCount;
            }

            set
            {
                this.MaxResultCount = value;
            }
        }
        public int Start
        {
            get
            {
                return this.SkipCount;
            }

            set
            {
                this.SkipCount = value;
            }
        }
    }
}