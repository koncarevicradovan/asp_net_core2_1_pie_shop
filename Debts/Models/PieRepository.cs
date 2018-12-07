using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Debts.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _appDbContext;

        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int Delete(Pie pie)
        {
            return _appDbContext.Pies.Remove(pie).Entity.Id;
        }

        public IEnumerable<Pie> GetAllPies()
        {
            return _appDbContext.Pies; 
        }

        public Pie GetPieById(int pieId)
        {
            return _appDbContext.Pies.Find(pieId);
        }

        public int Insert(Pie pie)
        {
            return _appDbContext.Pies.Add(pie).Entity.Id;
        }

        public void Update(Pie pie)
        {
            _appDbContext.Pies.Update(pie);
        }
    }
}
