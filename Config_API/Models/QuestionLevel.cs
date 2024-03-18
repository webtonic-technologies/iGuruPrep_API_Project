namespace Config_API.Models
{
    public class QuestionLevel
    {
        public int QuestionLevelId { get; set; }
        public string QuestionLevelName { get; set;} = string.Empty;
        public string QuestionLevelCode { get; set; } = string.Empty;
        public int? NoOfQuestions { get; set;}
        public int? SuccessRate { get;set; }
        public bool? Status { get; set; }
    }
}
