using System.Text.Json.Serialization;

namespace Models.DTOs;

public class CustomerDto
{
    public Guid CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    public string Password { get; set; }

    public List<Order> Orders { get; set; }
    public List<Post> Posts { get; set; }
}