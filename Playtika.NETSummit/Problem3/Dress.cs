namespace Playtika.NETSummit.Problem3
{
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
    }
}