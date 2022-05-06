using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoExchange.Net.Interfaces;

namespace Valr.Net.OrderBooks
{
    public class BookEntry : ISymbolOrderBookEntry
    {
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
