using System;

namespace src.Core.Models
{
	public class TouristPlace
	{
		public int? Id { get; set; }
		public string Name { get; set; }
		public TouristFeature TouristFeature { get; set; }
		public Neighborhood Neighborhood { get; set; }
	}
}