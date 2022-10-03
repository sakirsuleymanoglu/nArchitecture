namespace Core.Persistence.Paging;

public class BasePageableModel<T>
{
    public int Index { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }
    public int Pages { get; set; }
    public bool HasPrevious { get; set; }
    public bool HasNext { get; set; }
    public List<T> Items { get; set; }

    public BasePageableModel()
    {
        Items = new();
    }
}