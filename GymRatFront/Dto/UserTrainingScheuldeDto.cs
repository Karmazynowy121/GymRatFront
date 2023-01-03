namespace GymRatApi.Dto
{
    public class UserTrainingScheuldeDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public int TrainingScheuldeId { get; set; }
        public TrainingScheuldeDto TrainingScheulde { get; set; }
    }
}