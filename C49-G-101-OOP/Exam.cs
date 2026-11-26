using System.Diagnostics;

namespace C49_G_101_OOP;
#region MCQ Qs
#endregion

public abstract class Exam : ICloneable, IComparable<Exam>
{
    public int Time { get; set; }    
    public int NumberOfQuestions { get; set; }
    public Subject Subject { get; set; }
    public Question[] Questions { get; set; }
    public int[] StudentAnswers { get; set; }
    public TimeSpan Elapsed { get; protected set; }

    protected abstract string ExamName { get; }

    protected Exam(int time, int numberOfQuestions, Subject subject)
    {
        Time = time;
        NumberOfQuestions = numberOfQuestions;
        Subject = subject;
        Questions = new Question[numberOfQuestions];
        StudentAnswers = new int[numberOfQuestions];
    }


    public abstract void CreateQuestions();


    public abstract void ShowExam();

    protected void TakeExam()
    {
        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 0; i < Questions.Length; i++)
        {
            Console.Clear();
            Console.WriteLine(ExamName);
            Questions[i].Display(i + 1);
            StudentAnswers[i] = InputHelper.ReadInt("enterr your answer number:", 1, Questions[i].AnswerList.Length);
        }

        sw.Stop();
        Elapsed = sw.Elapsed;
    }

    protected void ShowResults()
    {
        Console.Clear();
        Console.WriteLine($"{ExamName} Results:");

        int grade = 0, total = 0;
        for (int i = 0; i < Questions.Length; i++)
        {
            Question q = Questions[i];
            Answer studentAnswer = q.AnswerList[StudentAnswers[i] - 1];

            Console.WriteLine($"Question {i + 1}: {q.Body}");
            Console.WriteLine($"Your Answer => {studentAnswer.AnswerText}");
            Console.WriteLine($"Correct Answer => {q.RightAnswer.AnswerText}");

            total += q.Mark;
            if (studentAnswer.AnswerId == q.RightAnswer.AnswerId)
                grade += q.Mark;
        }

        Console.WriteLine($"Your Grade is {grade} from {total}");
        Console.WriteLine($"Time = {Elapsed}");
    }

    public object Clone()
    {
        Exam copy = (Exam)MemberwiseClone();
        copy.Questions = Questions.Select(q => (Question)q.Clone()).ToArray();
        copy.StudentAnswers = (int[])StudentAnswers.Clone();
        return copy; 
    }

    public int CompareTo(Exam? other) =>
        other is null ? 1 : NumberOfQuestions.CompareTo(other.NumberOfQuestions);

    public override string ToString() =>
        $"{ExamName} | Subject: {Subject.SubjectName} | Time: {Time} min | Questions: {NumberOfQuestions}";
}
