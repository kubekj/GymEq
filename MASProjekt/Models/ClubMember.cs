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

        public ICollection<Agreement> Agreements { get; set; }
    }
}