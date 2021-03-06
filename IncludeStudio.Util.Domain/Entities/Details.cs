﻿using IncludeStudio.Util.Domain.Enums;
using System;

namespace IncludeStudio.Util.Domain.Entities
{
    public class Details
    {
        public string Description { get; set; }
        public string RadarType { get; set; }
        public string VariableType { get; set; }
        public string Value { get; set; }
        public string Environment { get; set; }
        public string Method { get; set; }
        public string FileName { get; set; }
        public DateTime Date { get; set; }

        public Details()
        {
            Date = DateTime.Now;
        }
    }
}
