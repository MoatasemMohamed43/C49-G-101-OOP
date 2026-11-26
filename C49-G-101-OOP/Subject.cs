namespace C49_G_101_OOP;

public class Subject
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public Exam? Exam { get; set; }

    public Subject(int subjectId, string subjectName)
    {
        SubjectId = subjectId;
        SubjectName = subjectName;
    }

    public void CreateExam()
    {
        int type = InputHelper.ReadInt("enter the type of exam \n1 Practical, 2 Final:", 1, 2);
        int time = InputHelper.ReadInt("enter time of the exam 30 \n to 180 min:", 30, 180);
        int count = InputHelper.ReadInt("enter the number of questions:", 1, int.MaxValue);

        Exam = type == 1
            ? new PracticalExam(time, count, this)
            : new FinalExam(time, count, this);

        Exam.CreateQuestions();
    }

    public override string ToString() => $"Subject {SubjectId}: {SubjectName}";
}
