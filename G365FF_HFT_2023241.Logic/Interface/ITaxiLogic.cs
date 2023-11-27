using G365FF_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G365FF_HFT_2023241.Logic.Interface
{
    internal interface ITaxiLogic
    {
        void Create(Taxi item);
        void Delete(int id);
        Taxi Read(int id);
        IQueryable<Taxi> ReadAll();
        void Update(Taxi item);
    }
}
