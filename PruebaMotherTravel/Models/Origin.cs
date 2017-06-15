using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PruebaMotherTravel.Models
{
    public class Origin
    {
        public int Id { get; set; }

        [ForeignKey("Airport")]
        public int AirportId { get; set; }

        public string Description { get; set; }

        public Airport Airport { get; set; }
    }
}