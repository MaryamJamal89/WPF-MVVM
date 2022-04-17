using Lab3_Task3.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace Lab3_Task3.Services
{
    internal class UserServices
    {
        // List Of Employee : Using name Space For Model
        ObservableCollection<Employee> allUsers;
        Model1 model = new Model1();

        public UserServices()
        {
            allUsers = new ObservableCollection<Employee>(model.Employees);
        }

        // Crud Operation smethods 
        public Employee GetByID(int _id)
        {
            return model.Employees.SingleOrDefault(user => user.ID == _id);
        }

        public ObservableCollection<Employee> GetAll()
        {
            return allUsers;
        }

        public void AddUser(Employee _user)
        {
            if (_user.Name != null || _user.Name == "")
            {
                model.Employees.Add(_user);
                model.SaveChanges();

                allUsers.Add(_user);
            }
            else
            {
                string message = $"Name Musn't Be Empty!";
                string title = "Invalid Entary";
                MessageBoxButton buttons = MessageBoxButton.OK;
                DialogResult result = System.Windows.Forms.MessageBox.Show(message, title, (MessageBoxButtons)buttons);
            }
        }

        public void ResmoveUser(Employee _user)
        {
            Employee target = model.Employees.SingleOrDefault(user => user.ID == _user.ID);
            if (target != null)
            {
                model.Employees.Remove(model.Employees.FirstOrDefault(user => user.ID == _user.ID));
                model.SaveChanges();

                allUsers.Remove(allUsers.FirstOrDefault(user => user.ID == _user.ID));
            }
            else
            {
                string message = $"Cant Find ID!";
                string title = "Invalid Entary";
                MessageBoxButton buttons = MessageBoxButton.OK;
                DialogResult result = System.Windows.Forms.MessageBox.Show(message, title, (MessageBoxButtons)buttons);
            }
        }

        public void UpdateUser(Employee _user)
        {
            Employee targetuser = model.Employees.SingleOrDefault(user => user.ID == _user.ID);
            if (targetuser != null)
            {
                targetuser.Name = _user.Name;
                targetuser.Gender = _user.Gender;
                targetuser.Address = _user.Address;
                model.SaveChanges();
            }
            else
            {
                string message = $"Cant Find ID!";
                string title = "Invalid Entary";
                MessageBoxButton buttons = MessageBoxButton.OK;
                DialogResult result = System.Windows.Forms.MessageBox.Show(message, title, (MessageBoxButtons)buttons);
            }
        }
    }
}
