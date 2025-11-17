using System.ComponentModel.DataAnnotations;

namespace SuperAppAPI.Models.Domain
{
    public class SubUsers
    {
        [Key]
        public Guid SubUserId { get; set; }
        public Guid UserId { get; set; } //From AuthDB Users Table.

        public  Guid SubscribedPlansId { get; set; } //From SupperappDB subscribedPlans

        public string UserName { get; set; }
    }
}
