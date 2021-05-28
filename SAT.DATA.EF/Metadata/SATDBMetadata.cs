using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SAT.DATA.EF
{

    #region Scheduled Class


    public class ScheduledClassMetadata
    {
        [Required(ErrorMessage = "*Required")]
        [Display(Name = "Class Schedule ID")]
        public int SchdeuledClassId { get; set; }

        [Required(ErrorMessage = "*Required")]
        [Display(Name = "Course ID")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "*Required")]
        [Display(Name = "Start Date")]
        public System.DateTime StartDate { get; set; }
        [Required(ErrorMessage = "*Required")]
        [Display(Name = "End Date")]
        public System.DateTime EndDate { get; set; }

        [Required(ErrorMessage = "*Required")]
        [Display(Name = "Instructor Name")]
        [StringLength(40, ErrorMessage = "Must be 40 characters or less")]
        public string InstructorName { get; set; }
        [Required(ErrorMessage = "*Required")]
        [StringLength(20, ErrorMessage = "Must be 20 characters or less")]
        public string Location { get; set; }
        [Required(ErrorMessage = "*Required")]
        public int SCID { get; set; }

    }
    [MetadataType(typeof(ScheduledClassMetadata))]
    public partial class ScheduledClass { }


    #endregion

    #region Courses

    public class CoursMetadata
    {

        [Required(ErrorMessage = "*Required")]
        [Display(Name = "Course ID")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "*Required")]
        [Display(Name = "Course Name")]
        [StringLength(50, ErrorMessage = "Must be 50 characters or less")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "*Required")]
        [Display(Name = "Course Description")]
        public string CourseDescription { get; set; }

        [Required(ErrorMessage = "*Required")]
        [Display(Name = "Credit Hours")]
        public byte CreditHours { get; set; }


        [StringLength(250, ErrorMessage = "Must be 250 characters or less")]
        public string Curriculum { get; set; }

        [StringLength(500, ErrorMessage = "Must be 500 characters or less")]
        public string Notes { get; set; }

        [Required(ErrorMessage = "*Required")]
        [Display(Name = "Is this course Active?")]
        public bool IsActive { get; set; }

        [Display(Name = "Course Photo")]
        public string PhotoURL { get; set; }
    }
    [MetadataType(typeof(CoursMetadata))]
    public partial class Cours { }

    #endregion


    #region Enrollment


    public class EnrollmentMetadata
    {
        [Required(ErrorMessage = "*Required")]
        [Display(Name = "Enrollment ID")]
        public int EnrollmentId { get; set; }
        [Required(ErrorMessage = "*Required")]
        [Display(Name = "Student ID")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "*Required")]
        [Display(Name = "Scheduled Class ID")]
        public int ScheduledClassId { get; set; }
        [Required(ErrorMessage = "*Required")]
        [Display(Name = "Date of Enrollment")]
        public System.DateTime EnrollmentDate { get; set; }
    }
    [MetadataType(typeof(EnrollmentMetadata))]
    public partial class Enrollment { }
    #endregion

    #region Student Status

    public class StudentStatusMetaData
    {
        [Display(Name = "Student Status ID")]
        [Required(ErrorMessage = "*Required")]
        public int SSID { get; set; }

        [Display(Name = "Student Status")]
        [Required(ErrorMessage = "*Required")]
        public string SSName { get; set; }

        [Display(Name = "Description")]
        public string SSDescription { get; set; }

    }
    [MetadataType(typeof(StudentStatusMetaData))]
    public partial class StudentStatus { }
    #endregion

    #region Student

    public class StudentMetadata
    {

        [Required(ErrorMessage = "*Required")]
        [Display(Name = "Student ID")]
        public int StudentId { get; set; }

        [StringLength(20, ErrorMessage = "Must be 20 characters or less")]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "*Required")]
        public string FirstName { get; set; }

        [StringLength(20, ErrorMessage = "Must be 20 characters or less")]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "*Required")]
        public string LastName { get; set; }

        [StringLength(15, ErrorMessage = "Must be 15 characters or less")]
        public string Major { get; set; }
        [StringLength(50, ErrorMessage = "Must be 50 characters or less")]
        public string Address { get; set; }
        [StringLength(25, ErrorMessage = "Must be 25 characters or less")]
        public string City { get; set; }
        [StringLength(2, ErrorMessage = "Must be 2 characters or less")]
        public string State { get; set; }

        [Display(Name = "Zip")]
        [StringLength(10, ErrorMessage = "Must be 10 characters or less")]
        public string ZipCode { get; set; }
        [StringLength(13, ErrorMessage = "Must be 13 characters or less")]
        public string Phone { get; set; }

        [StringLength(60, ErrorMessage = "Must be 60 characters or less")]
        [Required(ErrorMessage = "*Required")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "Must be 100 characters or less")]
        [Display(Name = "Description")]
        public string PhotoUrl { get; set; }

        [Display(Name = "Student Status ID")]
        [Required(ErrorMessage = "*Required")]
        public int SSID { get; set; }


        
        
        //public string FullName { get; }
    }
    [MetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
        [Display(Name = "Name")]
        public string Name
        {
            get { return FirstName + " " + LastName; }
        }
    }
    #endregion

    #region Scheduled Class Status

    public class ScheduledClassStatusMetadata
    {
        [Display(Name = "Student Class Status ID")]
        [Required(ErrorMessage = "*Required")]
        public int SCSID { get; set; }

        [Display(Name = "Student Class Status")]
        [Required(ErrorMessage = "*Required")]
        [StringLength(50, ErrorMessage = "Must be 50 characters or less")]
        public string SCSName { get; set; }
    }
    [MetadataType(typeof(ScheduledClassStatusMetadata))]
    public partial class ScheduledClassStatus { }

    #endregion

}
