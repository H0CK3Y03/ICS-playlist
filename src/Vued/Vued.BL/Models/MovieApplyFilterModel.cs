using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vued.DAL.Entities;


namespace Vued.BL.Models
{
    public record MovieApplyFilterModel
    {
        public string? Category { get; set; }
        public string SortOption { get; set; } = "Alphabetical";
        public double MinReleaseYear { get; set; }
        public bool OnlyFavourites { get; set; }
        public bool IsDescending { get; set; } = false;
    }
}
