using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Tax
    {
        public string Tag { get; set; }
        public new Dictionary<string, int> DicDayAndAmount { get; set; }
        public Tax(string tag )
        {
            Tag = tag;
            
        }
        public void AddTax(string time , int amount )
        {
           var tax = DicDayAndAmount.GetValueOrDefault(time);
            tax += amount;
            if(tax == amount)
            {
                DicDayAndAmount[time] = amount;
            }
            else
            {
                DicDayAndAmount.Add(time ,amount);
            }
            
        }
    }
}
