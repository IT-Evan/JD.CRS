using System.ComponentModel.DataAnnotations;

namespace JD.CRS.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}