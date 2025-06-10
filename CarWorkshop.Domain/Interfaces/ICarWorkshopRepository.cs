using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarWorkshopRepository
    {
        Task Create(Domain.Entities.CarWorkshop carWorkshop);
        Task<List<Domain.Entities.CarWorkshop>> GetAll();

        Task<Domain.Entities.CarWorkshop?> GetByEncodedName(string encodedName);
        Task<Domain.Entities.CarWorkshop?> GetByName(string value);
        Task Commit();
    }
}
