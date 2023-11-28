using G365FF_HFT_2023241.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G365FF_HFT_2023241.Logic.Interface
{
    public interface IPassengerLogic
    {
        void Create(Passenger item);
        void Delete(int id);
        Passenger Read(int id);
        IQueryable<Passenger> ReadAll();
        void Update(Passenger item);
       
        IEnumerable AvgPassByDriver();


    }
}
