using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Model
{
    public class User
    {
        public int Userid { get; set; }

        public string UserFullName { get; set; }
  
        public string UserPreferName { get; set; }

        public string UserEmail { get; set; }

        public string UserPhone { get; set; }
    }
}
