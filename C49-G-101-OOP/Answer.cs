namespace C49_G_101_OOP;


public class Answer : ICloneable, IComparable<Answer>
{
    public int AnswerId { get; set; }

    public string AnswerText { get; set; }

    public Answer(int answerId, string answerText)
    {
        AnswerId = answerId;
        AnswerText = answerText;
    }


    public object Clone() => new Answer(AnswerId, AnswerText);

    public int CompareTo(Answer? other) => other is null ? 1 : AnswerId.CompareTo(other.AnswerId);

    public override string ToString() => $"{AnswerId}- {AnswerText}";
}
