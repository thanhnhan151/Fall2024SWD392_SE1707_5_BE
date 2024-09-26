﻿namespace WWMS.BAL.Models.Wines
{
    public class CreateUpdateWineRequest
    {
        public long Id { get; set; }

        public string WineName { get; set; } = null!;

        public int Vintage { get; set; }

        public decimal? AlcoholContent { get; set; }

        public string? BottleSize { get; set; }

        public decimal? Price { get; set; }

        public int? AvailableStock { get; set; }

        public string? Description { get; set; }

        public string? LabelImageUrl { get; set; }

        public string? WineStatus { get; set; }

        public decimal? BottleWeight { get; set; }

        public decimal? AcidityLevel { get; set; }

        public string? TanninContent { get; set; }

        public string? SweetnessLevel { get; set; }

        public string? WineAgeingTime { get; set; }

        public DateTime? HarvestDate { get; set; }

        public string? FermentationProcess { get; set; }

        public long WineCategoryId { get; set; }
    }
}
