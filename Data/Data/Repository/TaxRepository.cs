using Domain.Entity;
using Domain.Repository;
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
    public class TaxRepository(IDistributedCache redis) : BaseRepository(redis) , ITaxRepository 
    {
        private static string _temp = "temp";

    

        private readonly IDistributedCache _redis;

        public async void Add(string model, string tag , int TimeOfDay , int day , int month , int year)
        {
            
            if (!string.IsNullOrEmpty(_redis.GetString(tag + _temp))) return;
            var getTaxtString = _redis.GetString(model) ?? string.Empty;
            var getTaxt = JsonConvert.DeserializeObject<Vihicle>(getTaxtString) ?? new Vihicle();
            if (getTaxt.TaxtFree)
            {
                //here We Add Tax Free Vehicle Like UsusalVehicle For Speeding In Next Time
              await AddToReddis(tag + _temp, new Tax(tag));
              return;
            }
            var time = String.Format("{0}{1}{2}", day, month, year);
            //here We Add To Temp Data For One Hour To Dont Calculate For The Nex Time
            await AddToReddis(tag + _temp, new Tax(tag) , 1);
            //here We Add To  Data For Geting Tax For Every Tag , Its Better That in Real Project We Store it In real Database Not Reddis and Send It With RabitMq For Speeding Data
            var getTotalTaxForTheseCarString = _redis.GetString(tag) ?? string.Empty;
            var getTotalTaxForTheseCar = JsonConvert.DeserializeObject<Tax>(getTotalTaxForTheseCarString) ?? new Tax(tag);
             TimeTable TimeTables = new TimeTable();
             var tax =  (TimeTables.Times.FirstOrDefault(x => x.Start > TimeOfDay) ?? new Time()).Tax;
             getTotalTaxForTheseCar.AddTax(time , tax);
            await AddToReddis(tag, getTotalTaxForTheseCar);



        }

        public async Task<Tax> GetAllTaxt(string tag)
        {
           
           var value = await _redis.GetStringAsync(tag);
            return JsonConvert.DeserializeObject<Tax>(value) ?? new( tag);
        }
    }
}
