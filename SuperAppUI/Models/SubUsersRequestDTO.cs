namespace SuperAppUI.Models
{
    public class SubUsersRequestDTO
    {
        public Guid UserId { get; set; } //From AuthDB Users Table.

        public Guid SubscribedPlansId { get; set; } //From SupperappDB subscribedPlans

        public string UserName { get; set; }
    }
}
