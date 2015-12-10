using System;
using System.Collections.Generic;
using System.ComponentModel;
using TrackableEntities;
using TrackableEntities.Client;

namespace Demo.ClientChangeTracking
{
    public class ExtendedEntityBase<TEntity> : EntityBase where TEntity : class, ITrackable, INotifyPropertyChanged
    {
        public ChangeTrackingCollection<TEntity> ChangeTracker { get; set; } =
            new ChangeTrackingCollection<TEntity>();

        protected TEntity Entity { get; set; }
        protected List<ITrackingCollection> RelatedChangeTrackers { get; set; } 
            = new List<ITrackingCollection>();

        public void StartTracking()
        {
            // Pass the entity to a change tracker and start tracking changes
            ChangeTracker.Tracking = false;
            ChangeTracker.Add(Entity);
            ChangeTracker.Tracking = true;

            // Start monitoring graph changes
            ChangeTracker.EntityChanged += ChangeTracker_EntityChanged;
            foreach (ITrackingCollection changeTracker in RelatedChangeTrackers)
            {
                changeTracker.EntityChanged += ChangeTracker_EntityChanged;
            }
        }

        public void StopTracking()
        {
            // Stop monitoring graph changes
            ChangeTracker.EntityChanged -= ChangeTracker_EntityChanged;
            foreach (var changeTracker in RelatedChangeTrackers)
            {
                changeTracker.EntityChanged -= ChangeTracker_EntityChanged;
            }

            // Stop tracking changes
            ChangeTracker.Tracking = false;
        }

        protected virtual void OnEntityChanged()
        {
            // Set entity state to modified if there are changes, otherwise set to unchanged
            Entity.TrackingState = Entity.HasChanges() ? TrackingState.Modified : TrackingState.Unchanged;
        }

        protected void ChangeTracker_EntityChanged(object sender, EventArgs e)
        {
            OnEntityChanged();
        }
    }
}
