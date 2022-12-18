namespace Application.Dto;

public class BookedTableRegisterDto
{
    public int TableId { get; set; }
    public DateTime FromTime { get; set; }
    public int Period { get; set; }
}