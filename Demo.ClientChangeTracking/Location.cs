using TrackableEntities.Client;

namespace Demo.ClientChangeTracking
{
    public class Location : EntityBase
    {
        private string _city;

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                NotifyPropertyChanged();
            }
        }
    }
}
