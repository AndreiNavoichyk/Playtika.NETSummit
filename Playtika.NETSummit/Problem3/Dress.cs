namespace Playtika.NETSummit.Problem3
{
    // Remove override of Equals and GetHashCode
    public class Dress
    {
        public Dress(int size, int growth, int price)
        {
            Size = size;
            Growth = growth;
            Price = price;
        }

        public int Size { get; }
        public int Growth { get; }
        public int Price { get; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Dress) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Size;
                hashCode = (hashCode * 397) ^ Growth;
                hashCode = (hashCode * 397) ^ Price;
                return hashCode;
            }
        }

        private bool Equals(Dress other)
        {
            return Size == other.Size && Growth == other.Growth && Price == other.Price;
        }
    }
}