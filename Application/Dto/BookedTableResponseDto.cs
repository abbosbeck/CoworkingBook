namespace Application.Dto;

public class BookedTableResponseDto
{
    public int Id { get; set; }
    public int TableId { get; set; }
    public DateTime FromTime { get; set; }
    public int Period { get; set; }
}