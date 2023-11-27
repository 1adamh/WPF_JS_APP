using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using G365FF_HFT_2023241.Models;
using G365FF_HFT_2023241.Repository;
using G365FF_HFT_2023241.Repository.Class;
using G365FF_HFT_2023241.Repository.Interface;

namespace G365FF_HFT_2023241.Logic
{
    public class TaxiLogic :ITaxiLogic
    {

        IRepository<Taxi> repo;

        public TaxiLogic(IRepository<Taxi> repo)
        {
            this.repo = repo;
        }

        public void Create(Taxi item)
        {
           
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Taxi Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Taxi> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Taxi item)
        {
            this.repo.Update(item);
        }

        
       

    }
}
