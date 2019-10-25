using Abp.Localization;
using JD.CRS.Entitys;
using JD.CRS.OfficeInstructor.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JD.CRS.Web.Models.OfficeInstructor
{

    public class Index
    {
        public IReadOnlyList<OfficeInstructorReadDto> OfficeInstructors { get; set; }
        public Index(IReadOnlyList<OfficeInstructorReadDto> officeInstructors)
        {
            OfficeInstructors = officeInstructors;
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