using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Localization;
using JD.CRS.Student.Dto;
using JD.CRS.Entitys;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JD.CRS.Web.Models.Student
{

    public class Index
    {
        public IReadOnlyList<StudentReadDto> Students { get; set; }

        public Index(IReadOnlyList<StudentReadDto> students)
        {
            Students = students;
        }

        public StatusCode? Status { get; set; }

        public List<SelectListItem> GetStatusList(ILocalizationManager localizationManager)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = localizationManager.GetString(CRSConsts.LocalizationSourceName, "PleaseSelect"),
                    Value = "",
                    Selected = Status == null
                }
            };

            list.AddRange(Enum.GetValues(typeof(StatusCode))
                .Cast<StatusCode>()
                .Select(status =>
                    new SelectListItem
                    {
                        Text = localizationManager.GetString(CRSConsts.LocalizationSourceName, $"StatusCode_{status}"),
                        Value = status.ToString(),
                        Selected = status == Status
                    })
            );

            return list;
        }
    }
}