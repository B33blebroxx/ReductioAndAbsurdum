using System.Text;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }

    public decimal Price { get; set; }
    public bool InStock { get; set; }

    public int PublicTypeId { get; set; }

    DateTime DateStocked { get; set; }


}