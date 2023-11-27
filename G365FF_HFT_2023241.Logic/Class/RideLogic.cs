using G365FF_HFT_2023241.Logic.Interface;
using G365FF_HFT_2023241.Models;
using G365FF_HFT_2023241.Repository.Class;
using G365FF_HFT_2023241.Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G365FF_HFT_2023241.Logic.Class
{
    public class RideLogic : IRideLogic
    {
        IRepository<Ride> repo;
        IRepository<Taxi> trepo;
        IRepository<Passenger> prepo;

        

        public RideLogic(IRepository<Ride> repo, IRepository<Taxi> trepo, IRepository<Passenger> prepo )
        {
            this.repo = repo;
            this.trepo= trepo;
            this.prepo = prepo;
        }

        public double CostCount(Ride item)
        {
            return this.repo
                .ReadAll()
                .Select(x => x.Cost)
                .Count();
        }

        public void Create(Ride item)
        {

            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public double DistanceCount(Ride item)
        {
            return this.repo
                .ReadAll()
                .Select(x => x.Distance)
                .Count();
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

        // non-crud 1
        public IEnumerable AvgDistanceByDriver()
        {
             

            var a = (double)repo.ReadAll().Sum(t => t.Distance) / trepo.ReadAll().Count();
            var list = new List<double>();
            list.Add(a);

            return list;
        }


        // non-crud 2
        public IEnumerable AvgDistanceByPassenger()
        {
            var a= (double)repo.ReadAll().Sum(t => t.Distance)/ prepo.ReadAll().Count();
            var list = new List<double>();
            list.Add(a);
          
            return list;


        }

        // non-crud 3
        public IEnumerable AvgCostByPassenger()
        {
            
            var a = (double)repo.ReadAll().Sum(t => t.Cost) / prepo.ReadAll().Count();
            var list = new List<double>();
            list.Add(a);

            return list;


        }

        //non-curd 4 
        //public IEnumerable<Ride> AvgCostByPassenger()
        //{
        //    return repo.ReadAll()
        //        .Select(t=> t.RID)
        //        .Where

        //}

    }
}
