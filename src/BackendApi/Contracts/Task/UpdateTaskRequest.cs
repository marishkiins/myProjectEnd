using Microsoft.VisualBasic;

namespace BackendApi.Contracts.User
{
    public class UpdateTaskRequest
    {
        public int userId { get; set; }
        public int typeId { get; set; }
        public int priorityId { get; set; }
        public int statusId { get; set; }
        public int? subjectId { get; set; }
        public int categoryId { get; set; }

        public string description { get; set; }

        public DateTime deadline { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }

    }
}
