using System.ComponentModel.DataAnnotations;

namespace BTSolution.DAL.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
