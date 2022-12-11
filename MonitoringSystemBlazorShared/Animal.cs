// Name: Animal.cs
// Author: Charles Clayton
// Description: Shared model for an Animal ojbect

using System;

namespace MonitoringSystemBlazorShared
{
	/// <summary>
	/// An object representing a specific animal in the zoo
	// </summary>
	public class Animal
	{
		/// <summary>
		/// Unique identifier for the Animal
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// The specific breed/genus of the Animal
		/// </summary>
		public AnimalType Type { get; set; }
		/// <summary>
		/// The name of the Animal
		/// </summary>
		public string? Name { get; set; }
		/// <summary>
		/// The approximate age of the animal, in years
		/// </summary>
        public int Age { get; set; }
		/// <summary>
		/// A note to indicate any health concerns to the zookeper
		/// </summary>
        public string? HealthConcerns { get; set; }
		/// <summary>
		/// A note to outline when the Animal should be fed
		/// </summary>
		public string? FeedingSchedule { get; set; }
    }
}

