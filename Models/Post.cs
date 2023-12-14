using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Post
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid PostId { get; set; }

    //Todo: research how this exactly works
    DateTime CreatedAt { get; set; } = DateTime.Now;
    public string Text { get; set; }

    // Foreign key to refer to a specific Item in an OrderDetail
    
    //kunne være based at bruge en item, 
    
    public Guid ItemId { get; set; }
    public virtual Item Item { get; set; }

    // Other properties...

    // Foreign key to refer to the Customer who posted it
    public Guid CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
}