namespace Demo.ClientChangeTracking
{
    public class Person : ExtendedEntityBase<Person>
    {
        public Person()
        {
            StartTracking(this);
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
    }
}
