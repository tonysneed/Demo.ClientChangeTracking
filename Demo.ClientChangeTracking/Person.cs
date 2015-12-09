using TrackableEntities.Client;

namespace Demo.ClientChangeTracking
{
    public class Person : EntityBase
    {
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
    }
}
