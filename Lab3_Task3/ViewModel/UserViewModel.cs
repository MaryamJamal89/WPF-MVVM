using System.Collections.ObjectModel;
using System.ComponentModel;
using Lab3_Task3.Models;
using Lab3_Task3.Services;
using Lab3_Task3.Commands;
using System.Windows;
using System.Windows.Forms;

namespace Lab3_Task3.ModelView
{
    internal class UserViewModel : INotifyPropertyChanged
    {
        UserServices userServices;

        public UserViewModel()
        {
            // default constr
            userServices = new UserServices();
            AllUsers = userServices.GetAll();
            CurrentUser = new Employee();

            GetByID = new UserCommands(getByIdUser);
            AddCommand = new UserCommands(addUser);
            DeleteCommand = new UserCommands(deletUser);
            UpdateCommand = new UserCommands(updateUser);
        }

        private string mesage;
        public string Message
        {
            get { return mesage; }
            set
            {
                mesage = value;
                OnPropertyChanged("Message");
            }
        }

        private UserCommands getbyid;
        public UserCommands GetByID
        {
            get { return getbyid; }
            set
            {
                getbyid = value;
                OnPropertyChanged("GetByID");
            }
        }

        private UserCommands addCommand;
        public UserCommands AddCommand
        {
            get { return addCommand; }
            set
            {
                addCommand = value;
                OnPropertyChanged("AddCommand");
            }
        }

        private UserCommands deleteCommand;
        public UserCommands DeleteCommand
        {
            get { return deleteCommand; }
            set
            {
                deleteCommand = value;
                OnPropertyChanged("DeleteCommand");
            }
        }

        private UserCommands updateCommand;
        public UserCommands UpdateCommand
        {
            get { return updateCommand; }
            set
            {
                updateCommand = value;
                OnPropertyChanged("UpdateCommand");
            }
        }

        private ObservableCollection<Employee> allUsers;
        public ObservableCollection<Employee> AllUsers
        {
            get { return allUsers; }
            set
            {
                allUsers = value;
                OnPropertyChanged("AllUsers");
            }
        }

        private Employee currentUser;
        public Employee CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                OnPropertyChanged("CurrentUser");
            }
        }

        void getByIdUser()
        {
            Message = userServices.GetByID(CurrentUser.ID).ToString();
        }

        void addUser()
        {
            if (CurrentUser.Name != null || CurrentUser.Name == "")
            {
                userServices.AddUser(CurrentUser);
                CurrentUser = new Employee();
                Message = "New Employee Inserted";
            }
            else { Message = "Name Musn't Be Empty!"; }
        }

        void updateUser()
        {
            if (CurrentUser.Name != null || CurrentUser.Name == "")
            {
                userServices.UpdateUser(CurrentUser);
                CurrentUser = new Employee();
                Message = "Employee Updated";
            }
            else { Message = "Name Musn't Be Empty!"; }
        }

        void deletUser()
        {
            userServices.ResmoveUser(CurrentUser);
            CurrentUser = new Employee();
            Message = "Employee Removed";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string _prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_prop));
        }
    }
}
