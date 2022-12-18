namespace Models
{
    public class Table
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public int FloorId { get; set; }
        public decimal Summasi { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Floor Floor { get; set;}
        public ICollection<BookedTable> BookedTables { get; set; }


    }
}