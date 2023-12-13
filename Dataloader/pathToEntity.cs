namespace Dataloader
{
    public class pathToEntity
    {
        public string PathBook { get; } = @"..\..\..\DATABASE\Book.csv";

        public string PathBorrower { get; } = @"..\..\..\DATABASE\Borrower.csv";

        public string PathBorrowerKey { get; } = @"..\..\..\DATABASE\BorrowerKey.csv";

        public string PathLibrarian { get; } = @"..\..\..\DATABASE\Librarian.csv";

        public string PathLibrarianKey { get; } = @"..\..\..\DATABASE\LibrarianKey.csv";

        public string PathTransactionsBorrow { get; } = @"..\..\..\DATABASE\transactionsBorrow.csv";

        public string PathTransactionsReturn { get; } = @"..\..\..\DATABASE\transactionsReturn.csv";

        public string PathSummary { get; } = @"..\..\..\DATABASE\Summary";
    }
}