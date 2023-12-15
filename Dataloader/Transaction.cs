namespace Dataloader
{
    public class Transaction
    {
        public string ISBN { get; set; }
        public string BorrowerID { get; set; }
        public string Time { get; set; }
        
        public Transaction(string isbn, string borrowerId, string time)
        {
            ISBN = isbn;
            BorrowerID = borrowerId;
            Time = time;
        }
    }
}