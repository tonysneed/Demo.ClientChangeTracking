using TrackableEntities.Client;

namespace Demo.ClientChangeTracking
{
    public class Person : ExtendedEntityBase<Person>
    {
        public Person()
        {
            Entity = this;
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyPropertyChanged();
            }
        }

        private Location _location;
        private ChangeTrackingCollection<Location> LocationChangeTracker { get; set; }
        public Location Location
        {
            get { return _location; }
            set
            {
                _location = value;
                LocationChangeTracker = _location == null ? null
                    : new ChangeTrackingCollection<Location>(_location);
                NotifyPropertyChanged();
            }
        }

        public ChangeTrackingCollection<Child> Children { get; set; } = new ChangeTrackingCollection<Child>();
    }
}
