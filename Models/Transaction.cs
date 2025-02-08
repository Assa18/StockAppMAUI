using SQLite;

namespace StockAppMAUI.Models;

public enum TransactionType
{
    NONE, IN, OUT, ANY
}

[Table("Transactions")]
public class Transaction
{
    [PrimaryKey, AutoIncrement]
    public int TID { get; set; }
    public TransactionType Type { get; set; }
    public int Count { get; set; }
    public string Note { get; set; }
    public float TotalSum { get; set; }
    public DateTime Date { get; set; }
    public int PID { get; set; }

    [Ignore]
    public int AID { get; set; }
}
