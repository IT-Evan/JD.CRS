using Abp.Localization;
using JD.CRS.Entitys;
using JD.CRS.Instructor.Dto;
using JD.CRS.Office.Dto;
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
        public IReadOnlyList<OfficeReadDto> Offices { get; set; }
        public IReadOnlyList<InstructorReadDto> Instructors { get; set; }
        public Index(IReadOnlyList<OfficeInstructorReadDto> officeInstructors, IReadOnlyList<OfficeReadDto> offices, IReadOnlyList<InstructorReadDto> instructors)
        {
            OfficeInstructors = officeInstructors;
            Offices = offices;
            Instructors = instructors;
        }

        public StatusCode? Status { get; set; }
        public string OfficeCode { get; set; }
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
        public List<SelectListItem> GetOfficeList(ILocalizationManager localizationManager)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = localizationManager.GetString(CRSConsts.LocalizationSourceName, "PleaseSelect"),
                    Value = "",
                    Selected = OfficeCode == null
                }
            };
            var officeList = Offices.ToList();
            list.AddRange(officeList
                .Select(office =>
                    new SelectListItem
                    {
                        Text = localizationManager.GetString(CRSConsts.LocalizationSourceName, $"{office.Name}"),
                        Value = office.Code.ToString(),
                        Selected = office.Equals(OfficeCode)
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
                        Text = localizationManager.GetString(CRSConsts.LocalizationSourceName, $"{instructor.Name}"),
                        Value = instructor.Code.ToString(),
                        Selected = instructor.Equals(InstructorCode)
                    })
            );

            return list;
        }
    }
}