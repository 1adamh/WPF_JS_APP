﻿using G365FF_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G365FF_HFT_2023241.Logic
{
    internal interface IRideLogic
    {
        void Create(Ride item);
        void Delete(int id);
        Ride Read(int id);
        IQueryable<Ride> ReadAll();
        void Update(Ride item);
    }
}
