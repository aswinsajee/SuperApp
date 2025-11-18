namespace SuperAppAPI.Models.DTO
{
    public class SubUserRequestDTO
    {
        public Guid UserId { get; set; } //From AuthDB Users Table.

        public Guid SubscribedPlansId { get; set; } //From SupperappDB subscribedPlans

        public string UserName { get; set; }
    }
}
