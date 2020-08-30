using Microsoft.EntityFrameworkCore;
using UserMicroService.Infraestructure.EntityFramework;

namespace UserMicroService.Repositories.Sql.EF
{
    public class MicroServiceContextProvider: IEFContextProvider
    {
        public string ConnetionString { get; }

        public MicroServiceContextProvider(string connetionString)
        {
            ConnetionString = connetionString;
        }
        public DbContext GetContext()
        {
            return new MicroservicesContext(ConnetionString);
        }
    }
}