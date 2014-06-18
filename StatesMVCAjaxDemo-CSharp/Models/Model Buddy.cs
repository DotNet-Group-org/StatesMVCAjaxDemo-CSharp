using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using StatesMVCAjaxDemo_CSharp.Classes;

namespace StatesMVCAjaxDemo_CSharp.Models
{
    [MetadataType(typeof(State_Validation))]
    partial class State{

    // Partial class compiled with code produced by VS designer
    }

    [Bind()]
    partial class State_Validation {
        public int stateID {get; set;}

        [DisplayName("State Name")]
        [RegularExpression(RegularExpressionPatterns.AlphaRegPattern, ErrorMessage = "Invalid special characters detected.")]
        [Required()]
        [StringLength(50, ErrorMessage="Must be under 50 characters")]
        public string stateName {get; set;}

        [DisplayName("State Abbreviation")]
        [RegularExpression(RegularExpressionPatterns.StateRegPattern, ErrorMessage = "Invalid characters detected.")]
        [Required()]
        [StringLength(2, MinimumLength=2, ErrorMessage="Abbreviation must be 2 characters")]
        public string stateAbbr {get; set;}

        [DisplayName("Capital")]
        [DisplayFormat(ConvertEmptyStringToNull=false)]
        [RegularExpression(RegularExpressionPatterns.ASCIIBasicRegPattern, ErrorMessage = "Invalid special characters detected.")]
        [StringLength(50, ErrorMessage="Must be under 50 characters")]
        public string stateCapital {get; set;}

        [DisplayName("Bird")]
        [DisplayFormat(ConvertEmptyStringToNull=false)]
        [RegularExpression(RegularExpressionPatterns.ASCIIBasicRegPattern, ErrorMessage = "Invalid special characters detected.")]
        [StringLength(50, ErrorMessage="Must be under 50 characters")]
        public string stateBird {get; set;}

        [DisplayName("Flower")]
        [DisplayFormat(ConvertEmptyStringToNull=false)]
        [RegularExpression(RegularExpressionPatterns.ASCIIBasicRegPattern, ErrorMessage = "Invalid special characters detected.")]
        [StringLength(50, ErrorMessage="Must be under 50 characters")]
        public string stateFlower {get; set;}

        [DisplayName("Tree")]
        [DisplayFormat(ConvertEmptyStringToNull=false)]
        [RegularExpression(RegularExpressionPatterns.ASCIIBasicRegPattern, ErrorMessage = "Invalid special characters detected.")]
        [StringLength(50, ErrorMessage="Must be under 50 characters")]
        public string stateTree {get; set;}

        [DisplayName("Region")]
        [DisplayFormat(ConvertEmptyStringToNull=false)]
        [RegularExpression(RegularExpressionPatterns.ASCIIBasicRegPattern, ErrorMessage = "Invalid special characters detected.")]
        [StringLength(50, ErrorMessage="Must be under 50 characters")]
        public string stateRegion {get; set;}

        [DisplayName("State Flag")]
        [DisplayFormat(ConvertEmptyStringToNull=false)]
        [RegularExpression(RegularExpressionPatterns.ASCIIBasicRegPattern, ErrorMessage = "Invalid special characters detected.")]
        [StringLength(50, ErrorMessage="Must be under 50 characters")]
        public string stateImageFlag {get; set;}

        [DisplayName("State Seal")]
        [DisplayFormat(ConvertEmptyStringToNull=false)]
        [RegularExpression(RegularExpressionPatterns.ASCIIBasicRegPattern, ErrorMessage = "Invalid special characters detected.")]
        [StringLength(50, ErrorMessage="Must be under 50 characters")]
        public string stateImageSeal {get; set;}
    }
}
