//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NAA.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Profile
    {
        public int ApplicantId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Applicant Name is required!")]
        [MinLength(3, ErrorMessage = "Applicant Name is too short!")]
        [MaxLength(100, ErrorMessage = "Applicant Name is too long!")]
        public string ApplicantName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Applicant Address is required")]
        public string ApplicantAddress { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number is required")]
        [RegularExpression("([0-9])+", ErrorMessage = "Phone must only include numbers!")]
        [MinLength(11, ErrorMessage = "Phone number is too short!")]
        [MaxLength(11, ErrorMessage = "Phone number is too long!")]
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
    }
}
