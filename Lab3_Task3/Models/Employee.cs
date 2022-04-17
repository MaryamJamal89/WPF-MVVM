namespace Lab3_Task3.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Employee : INotifyPropertyChanged
    {
        //public int ID { get; set; }
        private int iD;
        public int ID
        {
            get { return iD; }
            set
            {
                iD = value;
                OnPropertyChanged("ID");
            }
        }

        [Required]
        [StringLength(10)]
        //public string Name { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        [StringLength(10)]
        //public string Gender { get; set; }
        private string gender;
        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        [StringLength(50)]
        //public string Address { get; set; }
        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string _propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_propname));
        }

        public override string ToString()
        {
            return $"ID: { ID }, Name: { Name } lives in { Address }";
        }
    }
}
