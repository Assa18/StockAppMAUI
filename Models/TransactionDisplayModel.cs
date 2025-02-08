using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAppMAUI.Models;
public class TransactionDisplayModel
{
    public string ProductName { get; set; }
    public float ProductPrice { get; set; }
    public Transaction Transaction { get; set; }

    public Color color { get; set; }
}
