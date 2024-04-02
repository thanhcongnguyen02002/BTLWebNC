using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BTLWebNC.Models;
[Table("tblCategory")]
public class Category
{
    [Key]
    public int id { get; set; }
    public string? name { get; set; }
    public List<Post>? posts { get; set; }
}