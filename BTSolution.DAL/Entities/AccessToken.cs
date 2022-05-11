using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BTSolution.DAL.Entities;

public class AccessToken
{
    #region Properties

    [Required]
    public DateTime CreationDate { get; set; }

    [Required]
    public string Token { get; set; }

    [Key]
    public int TokenId { get; set; }

    [Required] [ForeignKey("User")]
    public int UserId { get; set; }

    #endregion
}