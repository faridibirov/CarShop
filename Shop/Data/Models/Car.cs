namespace Shop.Data.Models;

public class Car
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string shortDesc { get; set; }
    public string longDesc { get; set; }
    public string Img { get; set; }
    public ushort Price { get; set; }
    public bool isFavorite { get; set; }
    public int Available { get; set; }
    public int categoryId { get; set; } 
    public virtual Category Category { get; set; }
}
