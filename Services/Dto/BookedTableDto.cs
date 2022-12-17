namespace Service.Dto;

class BookedTableDto
{
    public int TableId { get; set; }
    public DateTime FromTime { get; set; }
    public int Period { get; set; }
}