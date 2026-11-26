namespace C49_G_101_OOP;

public class TrueFalseQuestion : Question
{
    public TrueFalseQuestion() : this(" ", 0)
    {
    }

    public TrueFalseQuestion(string body, int mark)
        : base("True & false question", body, mark,
               new[] { new Answer(1, "true"), new Answer(2, "false") },
               new Answer(1, "true"))
    {
    }

    public override void ReadDetails()
    {
        Body = InputHelper.ReadString("enter the question :   ");
        Mark = InputHelper.ReadInt("enter the question mark:", 1, int.MaxValue);
        int right = InputHelper.ReadInt("enter the the correct answer \n \t 1 Tru \t 2 false:", 1, 2);
        RightAnswer = AnswerList[right - 1];
    }
}
