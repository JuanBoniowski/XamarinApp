using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApp.Models
{
    [Table("UsersTable")]
    public class UserModel
    {
        [PrimaryKey, Column("ID"), AutoIncrement]
        public int ID { get; set; }

        [Column("UserName")]
        public string UserName { get; set; }

        [Column("Password")]
        public string Pasword { get; set; }
    }
}
