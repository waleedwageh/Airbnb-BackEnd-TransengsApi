using System.Collections.Generic;

namespace Domain.EntitiesSpecification.Propertyspec
{
    public class PropertySpecParams
    {

        public int PageIndex { get; set; }=1;
        public string CityName { get; set; }


        private int _pageSize =6;
        private int _maxPageSize =50;
        
        public int PageSize { get=>_pageSize; set=>_pageSize=(value<_maxPageSize)?value:_pageSize; }

        public bool? InstantHost { get; set; }
        public bool? CancellationFlexibility { get; set; }
        public decimal? Price { get; set; }
        public string sort { get; set; }

        public string search { get; set; }
        public int? NumOfBeds { get; set; }
        public int? NumOfBedrooms { get; set; }
        public int? StateId { get; set; }
        public int? NumofBathrooms { get; set; }

        public List<string> Amenities { get; set; }
        public List<string> Facilites { get; set; }

        public string PropertyType { get; set; }

        public List<string> HouseRules { get; set; }
        public List<string> HostLanguage { get; set; }


    }

    public class HostLanguageFilter
    {
    }

    public class HouseRulesFilter
    {
    }

    public class ProperTypeFilter
    {
    }

    public class FacilitesFilter
    {
    }

    public class AmenityFilter
    {
    }
}