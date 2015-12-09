using System.ComponentModel;
using TrackableEntities;
using TrackableEntities.Client;

namespace Demo.ClientChangeTracking
{
    public class ExtendedEntityBase<TEntity> : EntityBase where TEntity : class, ITrackable, INotifyPropertyChanged
    {
        public ChangeTrackingCollection<TEntity> ChangeTracker { get; set; }

        protected void StartTracking(TEntity entity)
        {
            ChangeTracker = new ChangeTrackingCollection<TEntity>(entity);
        }
    }
}
