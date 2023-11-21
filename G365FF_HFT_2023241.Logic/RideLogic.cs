using G365FF_HFT_2023241.Models;
using G365FF_HFT_2023241.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G365FF_HFT_2023241.Logic
{
    public class RideLogic
    {
        IRepository<Ride> repo;

        public RideLogic(IRepository<Ride> repo)
        {
            this.repo = repo;
        }

        public void Create(Ride item)
        {

            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Ride Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Ride> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Ride item)
        {
            this.repo.Update(item);
        }
    }
}
