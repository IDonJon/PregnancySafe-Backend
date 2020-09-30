using PregnancySafe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PregnancySafe.Domain.Repositories
{
    public interface IMotherRepository
    {
        Task<IEnumerable<Mother>> ListAsync();
        Task<Mother> FindByIdAsync(int id);
        Task AddASync(Mother mother);
        void Update(Mother mother);
        void Remove(Mother mother);
    }
}
