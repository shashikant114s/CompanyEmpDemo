﻿namespace Shared.RequestFeatures
{
    public class EmployeeParamerters : RequestParameters
    {
        public uint MinAge {  get; set; }
        public uint MaxAge { get; set; } = int.MaxValue;

        public bool ValidAgeRange => MaxAge > MinAge;
    }
}