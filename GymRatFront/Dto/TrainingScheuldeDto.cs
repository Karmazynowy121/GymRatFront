namespace GymRatApi.Dto
{
    public class TrainingScheuldeDto 
    {
        public string Name { get; set; }
        public UserTrainingScheuldeDto User { get; set; }
        public List<TrainingDto> Trainings { get; set; }
    }
}
