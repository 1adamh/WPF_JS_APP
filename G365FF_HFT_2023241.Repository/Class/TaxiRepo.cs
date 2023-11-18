using G365FF_HFT_2023241.Models;
using G365FF_HFT_2023241.Repository.Data;
using G365FF_HFT_2023241.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G365FF_HFT_2023241.Repository.Class
{
    public class TaxiRepo : Repository<Taxi>, IRepository<Taxi>
    {
        public TaxiRepo(TaxiDbContext ctx) : base(ctx)
        {
        }

        public override Taxi Read(int id)
        {
            return ctx.Taxis.FirstOrDefault(x => x.TID == id);       
        }

        public override void Update(Taxi item)
        {
            var old = Read(item.TID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
