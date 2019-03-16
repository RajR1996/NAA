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

    public partial class Application
    {
        public int ApplicationId { get; set; }
        public int ApplicantId { get; set; }
        public string CourseName { get; set; }
        public int UniversityId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Personal Statement is required")]
        [MinLength(100, ErrorMessage = "Personal Statement is too short!")]
        [MaxLength(4000, ErrorMessage = "Personal Statement is too long!")]
        public string PersonalStatement { get; set; }
        public string TeachReference { get; set; }
        public string TeacherContactDetails { get; set; }
        public string UniversityOffer { get; set; }
        public Nullable<bool> Firm { get; set; }
    }
}
