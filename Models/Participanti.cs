using System;
using System.ComponentModel.DataAnnotations;

namespace examen.Models
{
	public class Participanti
    {
        [Key]
		public int idpart { get; set; }
		public string nume { get; set; }
        public virtual ICollection<EvOrg> EvOrgs { get; set; } = new List<EvOrg>();
        public virtual ICollection<Evenimente> Ev { get; set; } = new List<Evenimente>();
        public enum ParticipantType
        {
            Spectator,
            Organizator
        }
    }
}
    


