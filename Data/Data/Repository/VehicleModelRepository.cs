using Domain.Entity;
using Domain.Repository;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        public VehicleModelRepository(IDistributedCache redis)
        {
            _redis = redis;
        }

        private readonly IDistributedCache _redis;


        private async Task AddToReddis(string key, object value)
        {
            string json = JsonConvert.SerializeObject(value);

            await _redis.SetStringAsync(key
             , json
             );


        }

        public async Task AddVihicle(Vihicle vihicle)
        {
           await AddToReddis(vihicle.Model, vihicle);
        }
    }
}
