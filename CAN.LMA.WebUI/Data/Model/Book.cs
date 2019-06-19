namespace CAN.LMA.WebUI.Data.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public virtual Author Author { get; set; }
        public int AuthorId { get; set; }
        public Customer Borrower { get; set; }
        public int BorrowerId { get; set; }
    }
}