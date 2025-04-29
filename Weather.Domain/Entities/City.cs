namespace Weather.Domain.Entities
{
    public class City
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string Elevation { get; set; } = string.Empty;
        public string Feature_code { get; set; } = string.Empty;
        public string Country_code { get; set; } = string.Empty;
        public int Admin1_id { get; set; }
        public int Admin2_id { get; set; }
        public int Admin3_id { get; set; }
        public string Timezone { get; set; } = string.Empty;
        public int Population { get; set; }
        public int[] Postcodes { get; set; } = [];
        public int Country_id { get; set; }
        public string Country { get; set; } = string.Empty;
        public string Admin1 { get; set; } = string.Empty;
        public string Admin2 { get; set; } = string.Empty;
        public string Admin3 { get; set; } = string.Empty;
    }
}
