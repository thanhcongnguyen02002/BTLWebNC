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




}
