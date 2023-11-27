using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using G365FF_HFT_2023241.Logic.Interface;
using G365FF_HFT_2023241.Models;
using G365FF_HFT_2023241.Repository;
using G365FF_HFT_2023241.Repository.Class;
using G365FF_HFT_2023241.Repository.Interface;

namespace G365FF_HFT_2023241.Logic.Class
{
    public class TaxiLogic : ITaxiLogic
    {

        IRepository<Taxi> repo;

        public TaxiLogic(IRepository<Taxi> repo)
        {
            this.repo = repo;
        }

        public void Create(Taxi item)
        {

            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Taxi Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Taxi> ReadAll()
        {
            return repo.ReadAll();
        }

        public int? TaxiCount(Taxi item)
        {
            return this.repo
                .ReadAll()
                .Count();

        }

        public void Update(Taxi item)
        {
            repo.Update(item);
        }




    }
}
