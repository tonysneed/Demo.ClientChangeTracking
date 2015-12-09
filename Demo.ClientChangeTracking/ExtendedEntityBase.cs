using System.ComponentModel;
using TrackableEntities;
using TrackableEntities.Client;

namespace Demo.ClientChangeTracking
{
    public class ExtendedEntityBase<TEntity> : EntityBase where TEntity : class, ITrackable, INotifyPropertyChanged
    {
        protected TEntity Entity { get; set; }

        public ChangeTrackingCollection<TEntity> ChangeTracker { get; set; }

        public void StartTracking()
        {
            ChangeTracker = new ChangeTrackingCollection<TEntity>(Entity);
        }
    }
}
