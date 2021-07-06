using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class WhatTrainerLovesViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Main Title")]
        public string MainTitle { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Icon url")]
        [DataType(DataType.Url)]
        public string IconUrl { get; set; }
    }
}
