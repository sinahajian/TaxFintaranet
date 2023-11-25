using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ITaxRepository
    {
        public void Add(string model, string tag, int TimeOfDay, int day, int month, int year);
        public Task<Tax> GetAllTaxt(string tag);
    }
}
