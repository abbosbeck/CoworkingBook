namespace Models;

public class Branch
{
    public int Id { get; set; }
    public string BranchName { get; set; }
    public int NumberOfChairs { get; set; }

    public ICollection<Floor> Floors { get; set; }
    public ICollection<Table> Tables { get; set; }
    

}