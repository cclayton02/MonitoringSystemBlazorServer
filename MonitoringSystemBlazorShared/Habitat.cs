// Name: Habitat.cs
// Author: Charles Clayton
// Description: Shared model for a Habitat ojbect

using System;

namespace MonitoringSystemBlazorShared
{
	/// <summary>
	/// A naturalistic environment used to house a grouping of Animals
	/// </summary>
	public class Habitat
	{
		/// <summary>
		/// Unique identifier for the Habitat
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// The name of the Habitat
		/// </summary>
		public string? Name { get; set; }
		/// <summary>
		/// The Habitat's overall climate setting
		/// </summary>
		public Temperature? Temp { get; set; }
		/// <summary>
		/// A note pertaining to the Habitat's local food supply
		/// </summary>
		public string? FoodSource { get; set; }
		/// <summary>
		/// A flag to note if the Habitat needs cleaning
		/// </summary>
		public bool IsClean { get; set; }
    }
}

