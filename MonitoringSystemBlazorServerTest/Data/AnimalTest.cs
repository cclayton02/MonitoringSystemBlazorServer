using MonitoringSystemBlazorServer.Data;

namespace MonitoringSystemBlazorServerTest
{
    public class AnimalTest
    {
        [Test]
        public void TestCreateAnimal()
        {
            // Arrange

            // Act
            var animal = new Animal();

            // Assert
            Assert.NotNull(animal);
        }

        [Test]
        public void TestCreateAnimalWithProperties()
        {
            // Arrange
            var id = 0;
            var type = AnimalType.Bear;
            var name = "Test Animal";
            var age = 5;
            var health = "";
            var food = "Twice a day";

            // Act
            var animal = new Animal()
            {
                Id = id,
                Type = type,
                Name = name,
                Age = age,
                HealthConcerns = health,
                FeedingSchedule = food
            };

            // Assert
            Assert.That(animal.Id, Is.EqualTo(id));
            Assert.That(animal.Type, Is.EqualTo(type));
            Assert.That(animal.Name, Is.EqualTo(name));
            Assert.That(animal.Age, Is.EqualTo(age));
            Assert.That(animal.HealthConcerns, Is.EqualTo(health));
            Assert.That(animal.FeedingSchedule, Is.EqualTo(food));
        }

        [Test]
        public void TestAnimalFeedingScheduleChanged()
        {
            // Arrange
            var currentSchedule = "none";
            var updatedSchedule = "3x per day";
            var animal = new Animal()
            {
                FeedingSchedule = currentSchedule
            };

            // Act
            animal.FeedingSchedule = updatedSchedule;

            // Assert
            Assert.That(animal.FeedingSchedule, Is.EqualTo(updatedSchedule));
        }
    }
}