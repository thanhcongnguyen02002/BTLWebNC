using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

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
    public List<Post> posts { get; set; }
    public List<Comment>? comments { get; set; }
}