namespace C49_G_101_OOP;

public class FinalExam : Exam
{
    protected override string ExamName => "Final Exam";

    public FinalExam(int time, int numberOfQuestions, Subject subject)
        : base(time, numberOfQuestions, subject)
    {
    }

    public override void CreateQuestions()
    {
        for (int i = 0; i < NumberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine($"Enter details for question {i + 1}:");
            int type = InputHelper.ReadInt("Choose question type: 1 for MCQ, 2 for True/False:", 1, 2);

            Console.Clear();
            Question q = type == 1 ? new MCQQuestion() : new TrueFalseQuestion();
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
