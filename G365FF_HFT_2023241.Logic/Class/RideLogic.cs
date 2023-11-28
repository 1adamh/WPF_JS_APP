using G365FF_HFT_2023241.Logic.Interface;
using G365FF_HFT_2023241.Models;
using G365FF_HFT_2023241.Repository.Class;
using G365FF_HFT_2023241.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

        public IRepository<Ride> Object { get; }

        public RideLogic(IRepository<Ride> repo, IRepository<Taxi> trepo, IRepository<Passenger> prepo)
        {
            this.repo = repo;
            
        }
        public RideLogic(Repository<Taxi> trepo, IRepository<Passenger> prepo)
        {
            this.trepo = trepo;
            this.prepo = prepo;
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
            var a = (double)repo.ReadAll().Sum(t => t.Distance) / prepo.ReadAll().Count();
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
        public IEnumerable AvgDriverRide()
        {
            var a = repo.ReadAll().Count() / trepo.ReadAll().Count();
            var list = new List<double>();
            list.Add(a);

            return list;

        }

        //non-crud 5 
        public IEnumerable<int> LongestDistanceDriver()
        {
            var maxkm = repo.ReadAll().Select(t => t.Distance).Max();
            var maxid = repo.ReadAll().Where(t => t.Distance == maxkm).Select(t => t.TaxiId);
            var driver= trepo.ReadAll().Where(t=>t.TID.Equals(maxid)).Select(t=>t.TID);
            
            return driver ;
        }

        




    }
}
