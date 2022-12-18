namespace Models;

public class Floor
{
    public int Id { get; set; }
    public int NumbersOfChair { get; set; }
    public int BranchId { get; set; }
    public virtual Branch Branch { get; set; }
    public ICollection<Table> Tables { get; set; }
   
}