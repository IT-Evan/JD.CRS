using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Localization;
using JD.CRS.Course.Dto;
using JD.CRS.Entitys;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JD.CRS.Web.Models.Course
{

    public class CourseListViewModel
    {
        //public CourseDto Course { get; set; }
        public IReadOnlyList<CourseDto> Courses { get; set; }

        public CourseListViewModel(IReadOnlyList<CourseDto> courses)
        {
            Courses = courses;
        }

        public StatusCode? SelectedStatus { get; set; }
        //public string Keyword { get; set; }

        public List<SelectListItem> GetStatusList(ILocalizationManager localizationManager)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = localizationManager.GetString(CRSConsts.LocalizationSourceName, "All"),
                    Value = "",
                    Selected = SelectedStatus == null
                }
            };

            list.AddRange(Enum.GetValues(typeof(StatusCode))
                .Cast<StatusCode>()
                .Select(status =>
                    new SelectListItem
                    {
                        Text = localizationManager.GetString(CRSConsts.LocalizationSourceName, $"StatusCode_{status}"),
                        Value = status.ToString(),
                        Selected = status == SelectedStatus
                    })
            );

            return list;
        }
    }
}