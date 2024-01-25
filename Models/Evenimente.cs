using System;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace examen.Models
{
	public class Evenimente
	{
		public int idev { get; set; }
		public int durata { get; set; }
		public int nrparticipanti { get; set; }
		public string nume { get; set; }
        public virtual ICollection<EvOrg> EvOrgs { get; set; } = new List<EvOrg>();
        public List<Participanti> P { get; set; } = new List<Participanti>();
    }

}

