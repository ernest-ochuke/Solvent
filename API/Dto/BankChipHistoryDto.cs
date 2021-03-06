using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Entities.enums;

namespace API.Dto
{
    public class BankChipHistoryDto
    {
       
        public int Quantity { get; set; }

        public DateTime? DateEntered { get; set; }

        public int CurrentBalance
        {
            get
            {
                if (History.Any())
                    return GetCurrentBalace();
                else
                    return Quantity;
            }
        }
        public string KCV { get; set; }
    
        public ICollection<ChipInventoryHistory> History { get; set; }
        private int GetCurrentBalace()
        {
            int value = 0;
            foreach (var history in History)
            {
                if (history.Approved)
                    switch (history.Action)
                    {
                        case RequestType.Add:
                            value = value + history.Quantity;
                            break;
                        case RequestType.Substract:
                            value = history.Quantity - value;
                            break;
                    }
            }
            return value = Quantity - value;

        }
    }
}