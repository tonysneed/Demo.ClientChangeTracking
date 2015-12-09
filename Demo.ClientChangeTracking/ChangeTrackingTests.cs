﻿using TrackableEntities;
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
            var changeTracker = new ChangeTrackingCollection<Person>(model);

            // Act
            model.FirstName = "George";

            // Assert
            Assert.Equal(TrackingState.Modified, model.TrackingState);
        }
    }
}
