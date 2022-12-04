using System;

namespace MonitoringSystemBlazorShared
{
	public class HabitatService
	{
		// TODO: Replace this mock data with a database module
		private List<Habitat> habitats = new()
		{
			new Habitat()
			{
				Id = 0,
				Name = "Penguin",
				Temp = Temperature.Freezing,
				FoodSource = "Fish in water running low",
				IsClean = true
			},
			new Habitat()
			{
				Id = 1,
				Name = "Bird",
				Temp = Temperature.Moderate,
				FoodSource = "Natural from environment",
				IsClean = true
			},
			new Habitat()
			{
				Id = 2,
				Name = "Aquarium",
				Temp = Temperature.Varied,
				FoodSource = "Added daily",
				IsClean = false
			}
		};
		// TODO: Update this to reflect the count we get back from the database
		private int currentId = 3;

		/// <summary>
		/// Data service used to show dynamic Habitat information
		/// </summary>
		public HabitatService()
		{
		}

		/// <summary>
		/// The process used to retrieve a list of all Habitats from the server
		/// </summary>
		public List<Habitat> GetAll()
		{
			// TODO: Use a data service for this step
			return habitats;
		}

		/// <summary>
		/// Retrieve a specific Habitat by Id
		/// </summary>
		public Habitat Get(int id)
		{
			Habitat item = new();

			for (int i = 0; i < habitats.Count; i++)
			{
				if (id == habitats[i].Id)
				{
					// We have located the matching id
					item = habitats[i];
				}
			}
			return item;
		}

		/// <summary>
		/// Adds a new habitat with unique id to the list
		/// </summary>
		public void Create(Habitat item)
		{
			// Ensuring that the new item has a unique identifier
			item.Id = currentId++;
			habitats.Add(item);
		}

		/// <summary>
		/// Updates the selected habitat
		/// </summary>
		public void Update(Habitat item)
		{
			var id = item.Id;

			for (int i = 0; i < habitats.Count; i++)
			{
				if (id == habitats[i].Id)
				{
					// We have located the matching id
					habitats[i] = item;
					break;
				}
			}
		}

		/// <summary>
		/// Removes the selected habitat by Id
		/// </summary>
		public void Delete(int id)
		{
			for (int i = 0; i < habitats.Count; i++)
			{
				if (id == habitats[i].Id)
				{
					habitats.RemoveAt(i);
				}
			}
		}
	}
}

