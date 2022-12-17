namespace Models;

public class BranchModel
{
    public int Id { get; set; }
    public string BranchName { get; set; }
    public int NumberOfChairs { get; set; }

    public ICollection<FloorModel> Floors { get; set; }
    public ICollection<TableModel> Tables { get; set; }
    

}