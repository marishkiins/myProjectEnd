namespace BackendApi.Contracts.User
{
    public class GetTaskResponse
    {
        public int Id { get; set; }

        public string description { get; set; }

        public DateTime? deadline { get; set; }
    }
}
