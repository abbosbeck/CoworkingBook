namespace Models
{
    public class TableModel
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public int FloorId { get; set; }
        public decimal Summasi { get; set; }

        public virtual BranchModel Branch { get; set; }
        public virtual FloorModel Floor { get; set;}
        public ICollection<BookedTableModel> BookedTables { get; set; }


    }
}