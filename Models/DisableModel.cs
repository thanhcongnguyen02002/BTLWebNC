using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Table("tblDisable")]
public class Disable
{
    [Key]
    public int id { get; set; }
    public int id_post { set; get; }
    public DateTime long_time { set; get; }
    public bool disabled { get; set; }
}