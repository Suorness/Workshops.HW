using System.ComponentModel.DataAnnotations;

namespace Rocket.BL.Common.Models.PersonalArea
{
    // TODO: Использовать валидационную модель
    public class Email
    {
        /// <summary>
        /// Id e-mail адреса.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя e-mail адреса.
        /// </summary>
       // [EmailAddress] 
        public string Name { get; set; }  // //  TODO: name?
    }
}