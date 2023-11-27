using G365FF_HFT_2023241.Logic.Interface;
using G365FF_HFT_2023241.Models;
using G365FF_HFT_2023241.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G365FF_HFT_2023241.Logic.Class
{
    public class RideLogic : IRideLogic
    {
        IRepository<Ride> repo;

        public RideLogic(IRepository<Ride> repo)
        {
            this.repo = repo;
        }

        public void Create(Ride item)
        {

            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Ride Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Ride> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Ride item)
        {
            repo.Update(item);
        }
    }
}
