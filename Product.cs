using System.Text;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }

    public decimal Price { get; set; }
    public bool InStock { get; set; }

    public int PublicTypeId { get; set; }

   public DateTime DateStocked { get; set; }

    public int DaysOnShelf
    {
        get
        {
            TimeSpan timeOnShelf = DateTime.Now - DateStocked;
            return timeOnShelf.Days;
        }
    }


}