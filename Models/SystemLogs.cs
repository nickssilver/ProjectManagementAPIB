using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPIB.Models
{
    public class SystemLogs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Username { get; set; }
        public string ActionType { get; set; }
        public string EntityName { get; set; }
        public string IPAddress { get; set; }
        public string Browser { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Description { get; set; }


    }
}
