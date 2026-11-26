namespace C49_G_101_OOP;
#region Exam

#endregion

public class PracticalExam : Exam
{
    protected override string ExamName => "Practical Exam";


    public PracticalExam(int time, int numberOfQuestions, Subject subject)
        : base(time, numberOfQuestions, subject)
    {
    }

    public override void CreateQuestions()
    {
        for (int i = 0; i < NumberOfQuestions; i++)
        {
            Console.Clear();
            Question q = new MCQQuestion();
            q.ReadDetails();
            Questions[i] = q;
        }
    }

    public override void ShowExam()
    {
        TakeExam();
        ShowResults();
    }
}
