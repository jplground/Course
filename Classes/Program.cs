namespace jplground.Classes;

class Program
{
    public static void Main(string[] args)
    {
        var key = Guid.NewGuid();

        var d = new Dictionary<EntityId, string>();
        d.Add(new EntityId(key), "My Value");
        System.Console.WriteLine(d.ContainsKey(new EntityId(key)));

        var e = new EntityId2(Guid.NewGuid());
}

public record EntityId2(Guid Id);

public class EntityId : IEquatable<EntityId>
{
    private Guid Id { get; }

    public EntityId(Guid id)
    {
        Id = id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as EntityId);
    }

    public bool Equals(EntityId? other)
    {
        if(other is null)
            return false;
        return Id == other.Id;
    }
}

