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
    public class RideRepo : Repository<Ride>, IRepository<Ride>
    {
        public RideRepo(TaxiDbContext ctx) : base(ctx)
        {
        }

        public override Ride Read(int id)
        {
            return ctx.Rides.FirstOrDefault(x => x.RID == id);
        }

        public override void Update(Ride item)
        {
            var old = Read(item.RID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
