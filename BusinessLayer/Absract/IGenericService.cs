﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Absract
{
    public interface IGenericService<T> where T : class, new()
    {
        void Insert(T t);

        void Delete(T t);

        void Update(T t);

        T GetById(int id);

        List<T> GetAll();
    }
}
