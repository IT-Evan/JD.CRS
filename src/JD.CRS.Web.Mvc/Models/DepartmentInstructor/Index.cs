﻿using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Localization;
using JD.CRS.Department.Dto;
using JD.CRS.DepartmentInstructor.Dto;
using JD.CRS.Entitys;
using JD.CRS.Instructor.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JD.CRS.Web.Models.DepartmentInstructor
{

    public class Index
    {
        public IReadOnlyList<DepartmentInstructorReadDto> DepartmentInstructors { get; set; }
        public IReadOnlyList<DepartmentReadDto> Departments { get; set; }
        public IReadOnlyList<InstructorReadDto> Instructors { get; set; }

        public Index(IReadOnlyList<DepartmentInstructorReadDto> departmentInstructors, IReadOnlyList<DepartmentReadDto> departments, IReadOnlyList<InstructorReadDto> instructors)
        {
            DepartmentInstructors = departmentInstructors;
            Departments = departments;
            Instructors = instructors;
        }

        public StatusCode? Status { get; set; }
        public string DepartmentCode { get; set; }
        public string InstructorCode { get; set; }

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
        public List<SelectListItem> GetDepartmentList(ILocalizationManager localizationManager)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = localizationManager.GetString(CRSConsts.LocalizationSourceName, "PleaseSelect"),
                    Value = "",
                    Selected = DepartmentCode == null
                }
            };
            var departmentList = Departments.ToList();
            list.AddRange(departmentList
                .Select(department =>
                    new SelectListItem
                    {
                        Text = department.Name.ToString(),
                        Value = department.Code.ToString(),
                        Selected = department.Equals(DepartmentCode)
                    })
            );

            return list;
        }
        public List<SelectListItem> GetInstructorList(ILocalizationManager localizationManager)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = localizationManager.GetString(CRSConsts.LocalizationSourceName, "PleaseSelect"),
                    Value = "",
                    Selected = InstructorCode == null
                }
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