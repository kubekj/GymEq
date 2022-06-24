using MASProjekt.Models;

namespace MASProjekt.Data
{
    public class ClubMember : Person
    {
        public ClubMember()
        {
            Agreements = new List<Agreement>();
        }

        public DateTime Birthday { get; set; }
        public int UniqueNumber { get; internal set; }
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

        public ICollection<Agreement> Agreements { get; set; }
    }
}