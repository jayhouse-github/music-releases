using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Music_Releases_Website.Models
{
    public class SearchBandsViewModel
    {
        [Required(ErrorMessage = "List of bands cannot be empty")]
        [Display(Name ="List of bands separated by commas")]
        public string ListOfBands { get; set; }
    }
}