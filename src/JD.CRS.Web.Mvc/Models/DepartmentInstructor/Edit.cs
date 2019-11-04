using Abp.Localization;
using JD.CRS.DepartmentInstructor.Dto;
using JD.CRS.Entitys;
using JD.CRS.Instructor.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JD.CRS.Web.Models.DepartmentInstructor
{

    public class Edit
    {
        public DepartmentInstructorReadDto DepartmentInstructor { get; set; }
        public IReadOnlyList<InstructorReadDto> Instructors { get; set; }
        public Edit(DepartmentInstructorReadDto departmentInstructor, IReadOnlyList<InstructorReadDto> instructors)
        {
            DepartmentInstructor = departmentInstructor;
            Instructors = instructors;
        }

        public StatusCode? Status { get; set; }
        public string InstructorCode { get; set; }

        public List<SelectListItem> GetStatusList(ILocalizationManager localizationManager)
        {
            var list = new List<SelectListItem>
            {

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
        public List<SelectListItem> GetInstructorList(ILocalizationManager localizationManager)
        {
            var list = new List<SelectListItem>
            {

            };
            var instructorList = Instructors.ToList();
            list.AddRange(instructorList
                .Select(instructor =>
                    new SelectListItem
                    {
                        Text = instructor.Name.ToString(),
                        Value = instructor.Code.ToString(),
                        Selected = instructor.Equals(InstructorCode)
                    })
            );

            return list;
        }
    }
}