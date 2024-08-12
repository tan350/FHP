using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace FHP.RES
{
    public class AcademicLevelAttribute : Attribute
    {
        public int LevelofAcademic { get; }

        public AcademicLevelAttribute(int level)
        {
            LevelofAcademic = level;
        }
    }

    public class Education_Level
    {

        public enum EducationLevel
        {
            [AcademicLevel(0)]
            Select = 0,

            [AcademicLevel(1)]
            [Description("10th Grade")]
            Tenth,

            [AcademicLevel(2)]
            [Description("12th Grade")]
            Twelveth,

            [AcademicLevel(3)]
            [Description("Bachelor of Technology")]
            Btech,

            [AcademicLevel(4)]
            [Description("Master of Technology")]
            Mtech,

            [AcademicLevel(3)]
            [Description("Bachelor of Computer Applications")]
            BCA,

            [AcademicLevel(4)]
            [Description("Master of Computer Applications")]
            MCA,

            [AcademicLevel(3)]
            [Description("Bachelor of Science")]
            BSc,

            [AcademicLevel(4)]
            [Description("Master of Science")]
            MSc,

            [AcademicLevel(3)]
            [Description("Bachelor of Arts")]
            BA,

            [AcademicLevel(4)]
            [Description("Master of Arts")]
            MA,

            [AcademicLevel(5)]
            [Description("Doctor of Philosophy")]
            PhD,

            [AcademicLevel(3)]
            [Description("Bachelor of Commerce")]
            BCom,

            [AcademicLevel(4)]
            [Description("Master of Commerce")]
            MCom,

            [AcademicLevel(3)]
            [Description("Bachelor of Business Administration")]
            BBA,

            [AcademicLevel(4)]
            [Description("Master of Business Administration")]
            MBA,

            [AcademicLevel(3)]
            [Description("Bachelor of Engineering")]
            BE,

            [AcademicLevel(4)]
            [Description("Master of Engineering")]
            ME,

            [AcademicLevel(3)]
            [Description("Bachelor of Medicine, Bachelor of Surgery")]
            MBBS,

            [AcademicLevel(3)]
            [Description("Bachelor of Dental Surgery")]
            BDS,

            [AcademicLevel(4)]
            [Description("Doctor of Medicine")]
            MD,

            [AcademicLevel(4)]
            [Description("Doctor of Dental Medicine")]
            DDM,

            [AcademicLevel(3)]
            [Description("Bachelor of Pharmacy")]
            BPharm,

            [AcademicLevel(4)]
            [Description("Master of Pharmacy")]
            MPharm,

            [AcademicLevel(3)]
            [Description("Bachelor of Arts in Education")]
            BAEd,

            [AcademicLevel(4)]
            [Description("Master of Arts in Education")]
            MAEd,

            [AcademicLevel(3)]
            [Description("Bachelor of Laws")]
            LLB,

            [AcademicLevel(4)]
            [Description("Master of Laws")]
            LLM,

            [AcademicLevel(3)]
            [Description("Bachelor of Fine Arts")]
            BFA,

            [AcademicLevel(4)]
            [Description("Master of Fine Arts")]
            MFA,

            [AcademicLevel(3)]
            [Description("Bachelor of Architecture")]
            BArch,

            [AcademicLevel(4)]
            [Description("Master of Architecture")]
            MArch,

            [AcademicLevel(3)]
            [Description("Bachelor of Design")]
            BDes,

            [AcademicLevel(4)]
            [Description("Master of Design")]
            MDes,

            [AcademicLevel(4)]
            [Description("Bachelor of Journalism")]
            BJ,

            [AcademicLevel(4)]
            [Description("Master of Journalism")]
            MJ,

            [AcademicLevel(3)]
            [Description("Bachelor of Social Work")]
            BSW,

            [AcademicLevel(4)]
            [Description("Master of Social Work")]
            MSW,

            [AcademicLevel(3)]
            [Description("Bachelor of Physiotherapy")]
            BPT,

            [AcademicLevel(4)]
            [Description("Master of Physiotherapy")]
            MPT,

            [AcademicLevel(3)]
            [Description("Bachelor of Occupational Therapy")]
            BOT,

            [AcademicLevel(4)]
            [Description("Master of Occupational Therapy")]
            MOT,

            [AcademicLevel(3)]
            [Description("Bachelor of Science in Nursing")]
            BSN,

            [AcademicLevel(4)]
            [Description("Master of Science in Nursing")]
            MSN,

            [AcademicLevel(3)]
            [Description("Bachelor of Hotel Management")]
            BHM,

            [AcademicLevel(4)]
            [Description("Master of Hotel Management")]
            MHM,

            [AcademicLevel(3)]
            [Description("Bachelor of Ayurvedic Medicine and Surgery")]
            BAMS,

            [AcademicLevel(4)]
            [Description("Master of Ayurvedic Medicine and Surgery")]
            MAMS
        }


        public static int GetAcademicLevel(EducationLevel qualification)
        {
            var attribute = (AcademicLevelAttribute)Attribute.GetCustomAttribute(
                qualification.GetType().GetField(qualification.ToString()),
                typeof(AcademicLevelAttribute)
            );

            return attribute?.LevelofAcademic ?? 0;
        }

        public bool isDowngrading(EducationLevel currentQualification, EducationLevel newQualification)
        {
            int currentLevel = GetAcademicLevel(currentQualification);
            int newLevel = GetAcademicLevel(newQualification);
            if (currentLevel > newLevel)
            {
                return true;
            }
            return false;
        }

        public enum EditMode 
        {
            New,
            Edit,
            Delete,
            ReadOnly
        }

        public enum UserRole
        {
            SuperAdmin,
            Admin,
            Guest,
            Self
        }

        public enum Message
        {
            [Description("First Name is required.")]
            FirstNameRequired,

            [Description("First Name contains invalid characters.")]
            FirstNameInvalidCharacters,

            [Description("Last Name contains invalid characters.")]
            LastNameInvalidCharacters,

            [Description("Middle Name contains invalid characters.")]
            MiddleNameInvalidCharacters,

            [Description("Qualification is required.")]
            QualificationRequired,

            [Description("Qualification Can't be Downgraded")]
            QualificationDowngraded,

            [Description("Invalid Date of Birth. Date Of Birth should be Less than Today's Date")]
            DateOfBirthInvalid,

            [Description("Invalid Date of Birth. Date Of Birth should be Less than Joininng Date")]
            DateOfBirthIsMore,

            [Description("Invalid Joininng Date. Joininng Date show not be more than Today's Date")]
            JoiningDateInvalid,

            [Description("Current Company is required.")]
            CurrentCompanyRequired,

            [Description("First Name Field cannot be Empty ")]
            FirstNameEmpty,

            [Description("Current Company Field cannot be Empty")]
            CurrentCompanyEmpty,

            [Description("DOJ Field cannot be Empty")]
            DOJEmpty,

            [Description("Qualification Field cannot be Empty")]
            QualificationEmpty,

            [Description("First Name cannot be more than 50 characters")]
            FirstNameTooLong,

            [Description("Last Name cannot be more than 50 characters")]
            LastNameTooLong,

            [Description("Middle Name cannot be more than 25 characters")]
            MiddleNameTooLong,

            [Description("Current Address cannot be more than 500 characters")]
            CurrentAddressTooLong,

            [Description("Current Company cannot be more than 255 characters")]
            CurrentCompanyTooLong,

            [Description("Cannot Delete as the User don't have permissions other than read only")]
            ReadOnlyUserCannotDelete,

            [Description("Record not found in the list.")]
            RecordMissing,

            [Description("Please select a row to delete.")]
            SelectRowToDelete,

            [Description("Record Deleted successfully.")]
            RecordDeleted,

            [Description("Do you want to Delete Row Data?")]
            WantToDeleteRow,

            [Description("Invalid line format.")]
            RecordInvalidFormat,

            [Description("Record Edited Successfully.")]
            RecordEdited,

            [Description("Do you want to clear the data?")]
            WantToClearData,

            [Description("Information Required")]
            InvalidFormData

        }

        public static string GetEnumValueAtIndex<TEnum>(byte index) where TEnum : Enum
        {
            TEnum[] enumValues = (TEnum[])Enum.GetValues(typeof(TEnum));

            if (index < 0 || index >= enumValues.Length)
            {
                return "";
            }
            return enumValues[index].ToString();
        }

        public static string GetEducationDescriptionAtIndex(byte index)
        {
            EducationLevel[] enumValues = (EducationLevel[])Enum.GetValues(typeof(EducationLevel));

            if (index < 0 || index >= enumValues.Length)
            {
                return "";
            }

            EducationLevel enumValue = enumValues[index];
            var descriptionAttribute = (DescriptionAttribute[])enumValue.GetType().GetField(enumValue.ToString())
                                        .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptionAttribute.Length > 0 ? descriptionAttribute[0].Description : enumValue.ToString();
        }

        public static string GetUserDescriptionAtIndex(byte index)
        {
            UserRole[] enumValues = (UserRole[])Enum.GetValues(typeof(UserRole));

            if (index < 0 || index >= enumValues.Length)
            {
                return "";
            }

            UserRole enumValue = enumValues[index];
            var descriptionAttribute = (DescriptionAttribute[])enumValue.GetType().GetField(enumValue.ToString())
                                        .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptionAttribute.Length > 0 ? descriptionAttribute[0].Description : enumValue.ToString();
        }

        public enum ExceptionMessage
        {
            FileNotFound,
            WritingError,
            ReadingError,
            UpdatingError,
            InvalidInput,
            DatabaseError
        }

        public static string GetErrorMessage(ExceptionMessage errorCode)
        {
            switch (errorCode)
            {
                case ExceptionMessage.FileNotFound:
                    return "File not found.";
                case ExceptionMessage.WritingError:
                    return "Error writing to file.";
                case ExceptionMessage.ReadingError:
                    return "Error reading from file.";
                case ExceptionMessage.UpdatingError:
                    return "Error in updating record in file.";
                case ExceptionMessage.InvalidInput:
                    return "Invalid input provided.";
                case ExceptionMessage.DatabaseError:
                    return "Database error occurred.";
                default:
                    return "An unexpected error occurred.";
            }
        }

        


    }

}
