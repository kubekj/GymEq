using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MASProjekt.Models
{
	public class Cleaning
	{
        private Cleaning() { }

        private Cleaning(int id,Maid maid,DateTime doneAt, string[] materialsUsed,DateTime? endedAt = null)
        {
            ID = id;
            Maid = maid;
            DoneAt = doneAt;
            MaterialsUsed = materialsUsed;
            EndedAt = endedAt;
        }

        public static Cleaning Create(int id,Maid maid, DateTime doneAt, string[] materialsUsed, DateTime? endedAt = null)
        {
            if (maid == null)
                throw new Exception("Sprzatnie bez sprzataczki nie moze powstac");

            if (!(maid.Cleanings.Select(x => x.DoneAt.Date == doneAt.Date).ToList().Count < 3))
                throw new Exception("Ten sprzatacz/ka ma juz dzisiaj pelen grafik");

            Cleaning cleaning = new Cleaning(id,maid,doneAt,materialsUsed,endedAt);

            maid.Cleanings.Add(cleaning);

            return cleaning;
        }

        [Key]
		public int ID { get; set; }

        [Required]
		public DateTime DoneAt { get; set; }

		public DateTime? EndedAt { get; set; }

        [Required]
		public string[] MaterialsUsed { get; set; }

        //Kompozycja
        [Required]
        [ForeignKey(nameof(MaidId))]
		public Maid Maid { get; set; }

        [Required]
        public int MaidId { get; set; }

    }
}

