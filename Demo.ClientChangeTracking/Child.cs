using TrackableEntities.Client;

namespace Demo.ClientChangeTracking
{
    public class Child : EntityBase
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                NotifyPropertyChanged();
            }
        }
    }
}
