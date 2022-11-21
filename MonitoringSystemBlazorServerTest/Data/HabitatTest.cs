using MonitoringSystemBlazorServer.Data;

namespace MonitoringSystemBlazorServerTest
{
    public class HabitatTest
    {
        [Test]
        public void TestCreateHabitat()
        {
            // Arrange

            // Act
            var habitat = new Habitat();

            // Assert
            Assert.NotNull(habitat);
        }

        [Test]
        public void TestCreateHabitatWithProperties()
        {
            // Arrange
            var id = 0;
            var name = "Test Habitat";
            var temp = Temperature.Cold;
            var food = "none";
            var clean = false;

            // Act
            var habitat = new Habitat()
            {
                Id = id,
                Name = name,
                Temp = temp,
                FoodSource = food,
                IsClean = clean
            };

            // Assert
            Assert.That(habitat.Id, Is.EqualTo(id));
            Assert.That(habitat.Name, Is.EqualTo(name));
            Assert.That(habitat.Temp, Is.EqualTo(temp));
            Assert.That(habitat.FoodSource, Is.EqualTo(food));
            Assert.That(habitat.IsClean, Is.EqualTo(clean));
        }

        [Test]
        public void TestHabitatFoodSourceChanged()
        {
            // Arrange
            var currentFood = "none";
            var updatedFood = "Plenty of fish available";
            var habitat = new Habitat()
            {
                FoodSource = currentFood
            };

            // Act
            habitat.FoodSource = updatedFood;

            // Assert
            Assert.That(habitat.FoodSource, Is.EqualTo(updatedFood));
        }
    }
}