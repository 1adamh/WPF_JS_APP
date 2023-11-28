using G365FF_HFT_2023241.Logic.Interface;
using G365FF_HFT_2023241.Models;
using G365FF_HFT_2023241.Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G365FF_HFT_2023241.Logic.Class
{
    public class PassengerLogic : IPassengerLogic
    {
        IRepository<Passenger> prepo;
        IRepository<Taxi> trepo;
        

        public PassengerLogic(IRepository<Passenger> repo, IRepository<Taxi> trepo)
        {
            this.prepo = repo;
            this.trepo = trepo;
        }

        public void Create(Passenger item)
        {

            prepo.Create(item);
        }

        public void Delete(int id)
        {
            prepo.Delete(id);
        }

        public Passenger Read(int id)
        {
            return prepo.Read(id);
        }

        public IQueryable<Passenger> ReadAll()
        {
            return prepo.ReadAll();
        }

        public void Update(Passenger item)
        {
            prepo.Update(item);
        }
        public int? PassCount(Passenger item)
        {
            return this.prepo
                .ReadAll()
                .Count();
                
        }
        //non-crud 6
        public IEnumerable AvgPassByDriver()
        {
            var a = prepo.ReadAll().Count() / trepo.ReadAll().Count();
            var list = new List<double>();
            list.Add(a);

            return list;
        }
    }
}
