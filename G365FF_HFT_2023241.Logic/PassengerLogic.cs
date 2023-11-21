using G365FF_HFT_2023241.Models;
using G365FF_HFT_2023241.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G365FF_HFT_2023241.Logic
{
    public class PassengerLogic
    {
        IRepository<Passenger> repo;

        public PassengerLogic(IRepository<Passenger> repo)
        {
            this.repo = repo;
        }

        public void Create(Passenger item)
        {

            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Passenger Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Passenger> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Passenger item)
        {
            this.repo.Update(item);
        }
    }
}
