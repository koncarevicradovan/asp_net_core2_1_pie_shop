using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debts.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> GetAllPies();
        Pie GetPieById(int pieId);
        void Update(Pie pie);
        int Delete(Pie pie);
        int Insert(Pie pie);
    }
}
