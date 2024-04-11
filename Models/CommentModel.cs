using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTLWebNC.Models;
[Table("tblComment")]
public class Comment
{
    [Key]
    public int id { get; set; }
    [ForeignKey("Post")]
    public int post_id { get; set; }
    [ForeignKey("User")]
    public int user_id { get; set; }
    public DateTime creatDate { get; set; }
    public string? content { get; set; }
    public Post? Post { get; set; }
    public User? User { get; set; }
}
