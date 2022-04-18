using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
	public class MovieCrew
	{
		public int MovieId { get; set; }
		public int CrewId { get; set; }
		public Movie Movie { get; set; }
		public Crew Crew { get; set; }

	    [MaxLength(128)]
		public string Department { get; set; }
		[MaxLength(128)]
		public string Job { get; set; }
	}
}

