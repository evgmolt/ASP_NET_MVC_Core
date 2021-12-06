using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
    public class VinylRecord
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Label { get; set; }
        [DataType(DataType.Date)]
        public DateTime RealeaseDate { get; set; }
    }
}
