using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Localization;
using JD.CRS.Office.Dto;
using JD.CRS.Entitys;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JD.CRS.Web.Models.Office
{

    public class Index
    {
        public IReadOnlyList<OfficeReadDto> Offices { get; set; }

        public Index(IReadOnlyList<OfficeReadDto> offices)
        {
            Offices = offices;
        }

        public StatusCode? Status { get; set; }
        public string Office { get; set; }

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
                    Selected = Office == null
                }
            };
            var temp = Offices.ToList();
            list.AddRange(temp
                .Select(office =>
                    new SelectListItem
                    {
                        Text = localizationManager.GetString(CRSConsts.LocalizationSourceName, $"{office.Name}"),
                        Value = office.Code.ToString(),
                        Selected = office.Equals(Office)
                    })
            );

            return list;
        }
    }
}