using System.Collections.Generic;

namespace Api.DTOS
{
    public class CurrencyDto
    {
        public int Id { get; set; }

        public string name { get; set; }

        public string icon_image { get; set; }

        public virtual List<PropertyDTo> properties { get; set; }

    }
}
