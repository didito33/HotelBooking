﻿using System.ComponentModel.DataAnnotations;
using HotelBooking.ViewModels.RoomCategory;
using static HotelBooking.Common.DataConstants.RoomConstants;

namespace HotelBooking.Models.Room
{
    public class AddRoomViewModel
    {
        //public int Id { get; set; }
        
        public int Capacity { get; set; }

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        public int HotelId { get; set; }

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Display(Name = "Image URL")]
        public string ImageURL { get; set; } = null!;

        [Range(PricePerDayMin,PricePerDayMax ,
            ErrorMessage = "Price must be a positive number and less than {2} BGN.")]
        public decimal PricePerNight { get; set; }

        public int RoomCategoryId { get; set; }

        public string UserId { get; set; }

        public List<RoomCategoryViewModel> RoomCategories { get; set; } = new List<RoomCategoryViewModel>();
    }
}
