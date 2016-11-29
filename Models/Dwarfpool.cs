using System;

namespace UIConfiguration.Models
{
    public class DwarfPool
    {
        public Guid ID { get; set; }
        public DwarfType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public enum DwarfType
    {
        SocialMedia,
        Calendar,
        Clock,
        Weather,
        News,
        FuelPrice,
        TrafficToDestination // wtf? xD
    }

    public class DwarfSettingPool
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public virtual DwarfPool DwarfPool { get; set; }
    }
}