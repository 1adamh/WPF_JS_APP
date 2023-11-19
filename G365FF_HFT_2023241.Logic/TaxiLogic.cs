using System;
using System.Linq;
using G365FF_HFT_2023241.Models;
using G365FF_HFT_2023241.Repository;
using G365FF_HFT_2023241.Repository.Interface;

namespace G365FF_HFT_2023241.Logic
{
    public class TaxiLogic 
    {

        IRepository<Ride> repo;

        public TaxiLogic(IRepository<Ride> repo)
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
