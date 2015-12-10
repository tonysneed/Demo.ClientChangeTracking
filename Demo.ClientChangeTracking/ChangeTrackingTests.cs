using TrackableEntities;
using TrackableEntities.Client;
using Xunit;

namespace Demo.ClientChangeTracking
{
    public class ChangeTrackingTests
    {
        [Fact]
        public void Setting_Model_Property_Should_Mark_Model_As_Modified()
        {
            // Arrange
            var model = new Person();
            model.StartTracking();

            // Act
            model.FirstName = "George";

            // Assert
            Assert.Equal(TrackingState.Modified, model.TrackingState);
        }

        [Fact]
        public void Setting_Reference_Property_Should_Mark_Reference_As_Modified()
        {
            // Arrange
            var model = new Person();
            model.Location = new Location {City = "London"};
            model.StartTracking();

            // Act
            model.Location.City = "Rome";

            // Assert
            Assert.Equal(TrackingState.Modified, model.Location.TrackingState);
        }

        [Fact]
        public void Setting_Child_Property_Should_Mark_Child_As_Modified()
        {
            // Arrange
            var model = new Person();
            model.Children.Add(new Child { Age = 5 });
            model.StartTracking();

            // Act
            model.Children[0].Age++;

            // Assert
            Assert.Equal(TrackingState.Modified, model.Children[0].TrackingState);
        }

        [Fact]
        public void Setting_Model_Property_Should_Mark_Fire_EntityChanged_Event()
        {
            // Arrange
            var model = new Person();
            model.StartTracking();

            bool entityChanged = false;
            model.ChangeTracker.EntityChanged += (sender, args) => entityChanged = true;

            // Act
            model.FirstName = "George";

            // Assert
            Assert.True(entityChanged);
        }

        [Fact]
        public void Setting_Reference_Property_Should_Mark_Parent_As_Modified()
        {
            // Arrange
            var model = new Person();
            model.Location = new Location { City = "London" };
            model.StartTracking();

            // Act
            model.Location.City = "Rome";

            // Assert
            Assert.Equal(TrackingState.Modified, model.TrackingState);
        }

        [Fact]
        public void Setting_Child_Property_Should_Mark_Parent_As_Modified()
        {
            // Arrange
            var model = new Person();
            model.Children.Add(new Child { Age = 5 });
            model.StartTracking();

            // Act
            model.Children[0].Age++;

            // Assert
            Assert.Equal(TrackingState.Modified, model.TrackingState);
        }
    }
}
