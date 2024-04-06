using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTLWebNC.Models;
[Table("tblUser")]
public class User
{
    [Key]
    public int id { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public DateTime createDate { get; set; }
    public string? avatar { get; set; }
    public string? role { get; set; }
    public bool status { get; set; }
    public List<Post>? posts { get; set; }
    public List<Comment>? comments { get; set; }
}
// id int IDENTITY(1,1) Primary key not null,
// 	username varchar(50),
// 	email varchar(150),
// 	password varchar(200),
// 	createDate datetime  DEFAULT GETDATE(),
// 	avatar varchar(250),
// 	role varchar(20),
// 	status bit DEFAULT 1