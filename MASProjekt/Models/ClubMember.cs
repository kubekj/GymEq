using MASProjekt.Models;

namespace MASProjekt.Data
{
    public class ClubMember : Person
    {
        public ClubMember()
        {
            Activities = new List<Activity>();

            if (_counter == int.MaxValue)
                throw new Exception("System have run out of unique numbers, please contact with support +48 997");

            UniqueNumber = _counter++;
        }

        public DateTime Birthday { get; set; }

        private static int _counter;
        public int UniqueNumber { get; set; }

        public float AmountToPay { get; internal set; }
        public float AmountPayed { get; internal set; }

        private readonly float _maxDiscount = 0.2f;
        private float discount;
        public float Discount
        {
            get { return discount; }
            set
            {
                if (value < _maxDiscount)
                {
                    discount = Agreements.LastOrDefault() != null ? (DateTime.Now.Year - Agreements.Last().SignUpDate.Year) / 100 : 0;
                }
                else
                {
                    discount = _maxDiscount;
                }
            }
        }

        public ICollection<Activity> Activities { get; set; }
    }
}