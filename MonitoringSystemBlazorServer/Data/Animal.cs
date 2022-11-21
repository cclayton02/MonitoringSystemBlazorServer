using System;

namespace MonitoringSystemBlazorServer.Data
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
        public int? Age { get; set; }
		/// <summary>
		/// A note to indicate any health concerns to the zookeper
		/// </summary>
        public string? HealthConcerns { get; set; }
		/// <summary>
		/// A note to outline when the Animal should be fed
		/// </summary>
		public string? FeedingSchedule { get; set; }

        public Animal()
        {
        }

        public Animal(AnimalType type, string name)
		{
			Type = type;
			Name = name;
		}

		public Animal(Animal other)
		{
			Type = other.Type;
			Name = other.Name;
			Age = other.Age;
			HealthConcerns = other.HealthConcerns;
			FeedingSchedule = other.FeedingSchedule;
		}
    }
}

