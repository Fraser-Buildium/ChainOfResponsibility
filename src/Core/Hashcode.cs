namespace Core;

// Generate hashcodes for immutable objects: http://stackoverflow.com/a/18613926/118218
public struct Hashcode
{
    private readonly int m_hashCode;
    private const int SeedHashCode = 17;
    private const int PrimeMultiplier = 31;

    public Hashcode(int hashCode)
    {
        m_hashCode = hashCode;
    }

    public static Hashcode Start => new Hashcode(SeedHashCode);

    public static implicit operator int(Hashcode hashCode) => hashCode.GetHashCode();

    public Hashcode Hash<T>(T obj)
    {
        var c = EqualityComparer<T>.Default;
        var h = c.Equals(obj, default(T)) ? 0 : obj.GetHashCode();
        unchecked
        {
            h += m_hashCode * PrimeMultiplier;
        }
        return new Hashcode(h);
    }

    public Hashcode HashSequence<T>(IEnumerable<T> obj)
    {
        return obj?.Aggregate(this, (current, item) => current.Hash(item)) 
               ?? Hash(obj);
    }

    public override int GetHashCode() => m_hashCode;
}