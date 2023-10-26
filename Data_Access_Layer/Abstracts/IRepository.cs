using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Abstracts
{
    internal interface IRepository<Parametre>where Parametre : class
    {
        Task VeriEkle(Parametre parametre);
        Task<List<Parametre>> VeriCek();
        Task<Parametre> IdCek(int id);
        Task<Parametre> VeriGuncelle(Parametre parametre);
        Task Sil (Parametre parametre);
    }
}
