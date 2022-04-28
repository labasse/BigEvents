using System;
using System.Collections.Generic;
using System.Text;

namespace EventMobileBasic
{
    public class EventEntry
    {
        public EventEntry(EventDto dto)
        {
            Event = dto;
            IsStandard = true;
        }
        public EventEntry(string specialName)
        {
            Event = new EventDto() { Title = specialName, Start = DateTime.Now };
            IsStandard = false;
        }
        public EventDto Event { get; private set; }
        public bool IsStandard { get; private set; }
        public bool IsSpecial => !IsStandard;
    }
}
