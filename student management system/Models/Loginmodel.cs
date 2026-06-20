using System.Linq;
using student_management_system.Data;

namespace student_management_system.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public bool CheckLogin(LoginModel model)
        {
            studentmanagementsystemEntities1 db =
                new studentmanagementsystemEntities1();

            var user = db.Users.FirstOrDefault(x =>
                x.Username == model.Username &&
                x.Password == model.Password);

            return user != null;
        }
    }
}