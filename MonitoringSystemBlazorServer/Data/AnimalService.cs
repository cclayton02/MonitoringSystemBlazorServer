using System;

namespace MonitoringSystemBlazorShared
{
	public class AnimalService
	{
		// TODO: Replace this mock data with a database module
		private List<Animal> animals = new()
		{
			new Animal()
			{
				Id = 0,
				Type = AnimalType.Lion,
				Name = "Leo",
				Age = 5,
				HealthConcerns = "Cut on left front paw",
				FeedingSchedule = "Twice daily"
			},
			new Animal()
			{
				Id = 1,
				Type = AnimalType.Tiger,
				Name = "Maj",
				Age = 15,
				HealthConcerns = "",
				FeedingSchedule = "3x per day"
			},
			new Animal()
			{
				Id = 2,
				Type = AnimalType.Bear,
				Name = "Baloo",
				Age = 1,
				HealthConcerns = "",
				FeedingSchedule = ""
			},
			new Animal()
			{
				Id = 3,
				Type = AnimalType.Giraffe,
				Name = "Spots",
				Age = 12,
				HealthConcerns = "",
				FeedingSchedule = "Grazing"
			}
		};
		// TODO: Update this to reflect the count we get back from the database
		private int currentId = 4;

		/// <summary>
		/// Data service used to show dynamic Animal information
		/// </summary>

		public AnimalService()
		{
		}

		/// <summary>
		/// The process used to retrieve a list of all Animals from the server
		/// </summary>
		public List<Animal> GetAll()
		{
			// TODO: Use a data service for this step
			return animals;
		}

		/// <summary>
		/// Retrieve a specific Animal by Id
		/// </summary>
		public Animal Get(int id)
		{
			Animal item = new();

			for (int i = 0; i < animals.Count; i++)
			{
				if (id == animals[i].Id)
				{
					// We have located the matching id
					item = animals[i];
				}
			}
			return item;
		}

		/// <summary>
		/// Adds a new animal with unique id to the list
		/// </summary>
		public void Create(Animal item)
		{
			// Ensuring that the new item has a unique identifier
			item.Id = currentId++;
			animals.Add(item);
		}

		/// <summary>
		/// Updates the selected animal
		/// </summary>
		public void Update(Animal item)
		{
			var id = item.Id;

			for (int i = 0; i < animals.Count; i++)
			{
				if (id == animals[i].Id)
				{
					// We have located the matching id
					animals[i] = item;
					break;
				}
			}
		}

		/// <summary>
		/// Removes the selected animal by Id
		/// </summary>
		public void Delete(int id)
		{
			for (int i = 0; i < animals.Count; i++)
			{
				if (id == animals[i].Id)
				{
					animals.RemoveAt(i);
				}
			}
		}
	}
}

