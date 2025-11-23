namespace SuperApp_UI.Models
{
    public class SubUsersResponseDTO
    {
        public Guid SubUserId { get; set; }
        public Guid UserId { get; set; } //From AuthDB Users Table.

        public Guid SubscribedPlansId { get; set; } //From SupperappDB subscribedPlans

        public string UserName { get; set; }
    }
}
