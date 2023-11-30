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
    public class PassengerRepo : Repository<Passenger>, IRepository<Passenger>
    {
        public PassengerRepo(TaxiDbContext ctx) : base(ctx)
        {
        }

        public override Passenger Read(int id)
        {
            return ctx.Passengers.FirstOrDefault(x => x.PID == id);
        }

        public override void Update(Passenger item)
        {
            var old= Read(item.PID);
            foreach (var prop in old.GetType().GetProperties())
            {
                //prop.SetValue(old, prop.GetValue(item));
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
