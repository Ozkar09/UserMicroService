using Microsoft.EntityFrameworkCore;

namespace UserMicroService.Repositories.Sql.EF
{
    public interface IEFContextProvider
    {
        DbContext GetContext();
    }
}