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
    public class PassengerLogic : IPassengerLogic
    {
        IRepository<Passenger> repo;

        public PassengerLogic(IRepository<Passenger> repo)
        {
            this.repo = repo;
        }

        public void Create(Passenger item)
        {

            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Passenger Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Passenger> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Passenger item)
        {
            repo.Update(item);
        }
    }
}
