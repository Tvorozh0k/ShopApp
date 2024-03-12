using System.ComponentModel.DataAnnotations;

namespace BlazorApp4.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Пожалуйста, введите фамилию")]
        public string? LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Пожалуйста, введите имя")]
        public string? FirstName { get; set; }

        public string Patronymic { get; set; } = "";

        [Required(AllowEmptyStrings = false, ErrorMessage = "Пожалуйста, введите номер телефона")]
        public string? PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Пожалуйста, введите почту")]
        public string? Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Пожалуйста, введите пароль")]
        public string? Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Пожалуйста, введите пароль ещё раз")]
        public string? ConfirmPassword { get; set; }
    }
}
