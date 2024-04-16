using BTLWebNC.Models;
using Microsoft.AspNetCore.Mvc;

public class DisableRepositoryImpl : IDisableRepository
{
    private readonly MyDbContext context;
    public DisableRepositoryImpl(MyDbContext context)
    {
        this.context = context;
    }
    [HttpPost]
    public Disable AddDisable(int id)
    {
        var dis = context.Disables.FirstOrDefault(d => d.id_post == id);
        if (dis == null)
        {
            Disable disable = new Disable
            {
                long_time = DateTime.Now,
                id_post = id,
                disabled = true,

            };
            context.Disables.Add(disable);
            context.SaveChanges();
            return (disable);
        }
        else
        {
            var check = dis.disabled == true ? false : true;
            dis.disabled = check;
            context.Disables.Update(dis);
            context.SaveChanges();
            return dis;
        }



    }




}
