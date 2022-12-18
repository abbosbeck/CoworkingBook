namespace Models;

public class FloorModel
{
    public int Id { get; set; }
    public int NumbersOfChair { get; set; }
    public int BranchId { get; set; }
    public virtual BranchModel Branch { get; set; }
    public ICollection<TableModel> Tables { get; set; }
   
}