using System.ComponentModel.DataAnnotations;

namespace Rocket.BL.Common.Models.PersonalArea
{
    public class Email
    {
        /// <summary>
        /// Id e-mail адреса.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя e-mail адреса.
        /// </summary>
       // [EmailAddress] //  TODO: add this
        public string Name { get; set; }  // //  TODO: name?
    }
}