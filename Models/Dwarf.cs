using System;


namespace UIConfiguration.Models
{
    public class Dwarf
    {
        public Guid ID { get; set; }
        public string Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public bool IsActive { get; set; }

        //public virtual User User { get; set; }
    }

    public class DwarfSetting
    {
        public string Tag { get; set; }
        public string Value { get; set; }
        //public virtual Dwarf Dwraf { get; set; }
    }
}