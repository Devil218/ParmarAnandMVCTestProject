using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models
{
  public class Customers
  {
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, ErrorMessage = "First name can't be longer than 50 characters.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, ErrorMessage = "Last name can't be longer than 50 characters.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Address is required.")]
    [StringLength(200, ErrorMessage = "Address can't be longer than 200 characters.")]
    public string FullAddress { get; set; }  

  }
}
