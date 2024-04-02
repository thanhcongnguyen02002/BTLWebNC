using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTLWebNC.Models;
[Table("tblPost")]
public class Post
{
    [Key]
    public int id { get; set; }
    [ForeignKey("User")]
    public int user_id { get; set; }
    [ForeignKey("Category")]
    public int category_id { get; set; }
    public string? title { get; set; }
    public string? content { get; set; }
    public DateTime createDate { get; set; }
    public string? thumbnail { get; set; }
    public int viewPost { get; set; }
    public bool status { get; set; }
    public DateTime updateDate { get; set; }
    public User? User { get; set; }
    public Category? Category { get; set; }
    public List<Comment>? comments { get; set; }

}
// id int IDENTITY(1,1) Primary key not null,
// 	user_id int,
// 	category_id int,
// 	title nvarchar(150),
// 	content nvarchar(max),
// 	createDate datetime DEFAULT GETDATE(),
// 	thumbnail varchar(250),
// 	viewPost int,
// 	status bit DEFAULT 1,
// 	updateDate datetime DEFAULT GETDATE()