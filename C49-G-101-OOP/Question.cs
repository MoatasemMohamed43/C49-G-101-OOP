namespace C49_G_101_OOP;
#region Answer
#endregion



public abstract class Question : ICloneable, IComparable<Question>
{
    public string Header { get; set; }
    public string Body { get; set; }
    public int Mark { get; set; }
    public Answer[] AnswerList { get; set; }
    public Answer RightAnswer { get; set; }

    protected Question(string header, string body, int mark) : this(header, body, mark, Array.Empty<Answer>(), new Answer(0, ""))
    {
    }

    protected Question(string header, string body, int mark, Answer[] answerList, Answer rightAnswer)
    {
        Header = header;
        Body = body;
        Mark = mark;
        AnswerList = answerList;
        RightAnswer = rightAnswer;
    }

    // each question type reads its own data
    public abstract void ReadDetails();

    public virtual void Display(int number)
    {
        Console.WriteLine($"Question {number}: {Body}");
        Console.WriteLine($"{Header}:   Mark {Mark}");
        foreach (Answer a in AnswerList)
            Console.WriteLine(a);
    }

    // Deep copy
    public virtual object Clone()
    {
        Question copy = (Question)MemberwiseClone();
        copy.AnswerList = AnswerList.Select(a => (Answer)a.Clone()).ToArray();
        copy.RightAnswer = copy.AnswerList.FirstOrDefault(a => a.AnswerId == RightAnswer.AnswerId) ?? (Answer)RightAnswer.Clone();
       
        return copy;
    }

    public int CompareTo(Question? other) =>
        other is null ? 1 : Mark.CompareTo(other.Mark);

    public override string ToString() => $"{Header} [{Mark} marks]: {Body}";
}
