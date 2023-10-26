using Data_Access_Layer.Abstracts;
using Data_Access_Layer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repostories
{
    public class Repository<Parametre> : IRepository<Parametre> where Parametre : class
    {
        private readonly AppDbContext _appDbContext = new AppDbContext();
        public async Task<List<Parametre>> VeriCek()
        {
            return await _appDbContext.Set<Parametre>().ToListAsync();
        }

        public async Task<Parametre> IdCek(int id)
        {
            return await _appDbContext.Set<Parametre>().FindAsync(id);
            
        }

        public async Task Sil(Parametre parametre)
        {
            _appDbContext.Set<Parametre>().Remove(parametre);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task VeriEkle(Parametre parametre)
        {
            await _appDbContext.Set<Parametre>().AddAsync(parametre);
            await _appDbContext.SaveChangesAsync(); 
        }

        public async Task<Parametre> VeriGuncelle(Parametre parametre)
        {
            _appDbContext.Set<Parametre>().Update(parametre);
            await _appDbContext.SaveChangesAsync();
            return parametre;

            
        }
    }
}
