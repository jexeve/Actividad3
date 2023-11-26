using System.ComponentModel.DataAnnotations;

namespace ConsoleApp5.Data
{
    public class Day
    {
        [Key]
        public int Id { get; set; }

        public string Date { get; set; } = "";
        public int TemperatureMax { get; set; }
        public int TemperatureMin { get; set; }
        public string Icon { get; set; } = "";
        public string Text { get; set; } = "";
        public int Humidity { get; set; }
        public int Wind { get; set; }
        public string WindDirection { get; set; } = "";
        public string Sunrise { get; set; } = "";
        public string Sunset { get; set; } = "";
        public string Moonrise { get; set; } = "";
        public string Moonset { get; set; } = "";
        public string MoonPhasesIcon { get; set; } = "";
    }
}
