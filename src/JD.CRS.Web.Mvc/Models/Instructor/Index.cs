using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Localization;
using JD.CRS.Instructor.Dto;
using JD.CRS.Entitys;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JD.CRS.Web.Models.Instructor
{

    public class Index
    {
        public IReadOnlyList<InstructorReadDto> Instructors { get; set; }

        public Index(IReadOnlyList<InstructorReadDto> instructors)
        {
            Instructors = instructors;
        }

        public StatusCode? Status { get; set; }
        //public string Keyword { get; set; }

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