using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace examen.Models
{
	public class EvOrg
	{
        public int idevo { get; set; }
        public Evenimente Evenimente{ get; set; } 
        public Participanti Participanti { get; set; } 
    }
}

