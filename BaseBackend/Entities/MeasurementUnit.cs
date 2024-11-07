using BaseBackend.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseBackend.Entities
{
    public class MeasurementUnit:IBaseEntity
    {
        private static int nextId = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public MeasurementUnit(string name)
        {
            Id = nextId++;
            Name = name;
        }
    }
}
