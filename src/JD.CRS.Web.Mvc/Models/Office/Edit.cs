﻿using Abp.Localization;
using JD.CRS.Office.Dto;
using JD.CRS.Entitys;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JD.CRS.Web.Models.Office
{

    public class Edit
    {
        public OfficeReadDto Office { get; set; }
        public StatusCode? Status { get; set; }
        //public string Keyword { get; set; }

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
    }
}