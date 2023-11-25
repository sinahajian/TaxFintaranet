using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public abstract class BaseRepository
    {
        public BaseRepository(IDistributedCache redis)
        {
            _redis = redis;
        }

        private readonly IDistributedCache _redis;
        public async Task AddToReddis(string key, object value)
        {
            string json = JsonConvert.SerializeObject(value);

            await _redis.SetStringAsync(key
             , json
             );
        }
        public async Task AddToReddis(string key, object value, int RemainingTimeHour)
        {
            string json = JsonConvert.SerializeObject(value);
           await _redis.SetStringAsync(key
                , json
                , new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = new TimeSpan(RemainingTimeHour, 0, 0)
                });
        }


    }
}
