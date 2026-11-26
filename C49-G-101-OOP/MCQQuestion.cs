namespace C49_G_101_OOP;
#region T & F Question
#endregion



public class MCQQuestion : Question
{
    private const int ChoicesCount = 4;

    public MCQQuestion() : this("", 0)
    {
    }

    public MCQQuestion(string body, int mark)
        : base("MCQ Qs ", body, mark)
    {
    }

    public override void ReadDetails()
    {
        Body = InputHelper.ReadString("enter the question:");
        Mark = InputHelper.ReadInt("enter the question mark:", 1, int.MaxValue);

        Console.WriteLine("Choices of Question: ");
        AnswerList = new Answer[ChoicesCount];
        for (int i = 0; i < ChoicesCount; i++)
        {
            string text = InputHelper.ReadString($"enter choice number {i + 1}:");
            AnswerList[i] = new Answer(i + 1, text);
        }

        int right = InputHelper.ReadInt($"enter correct answer (1 to {ChoicesCount}):", 1, ChoicesCount);
        RightAnswer = AnswerList[right - 1];
    }
}
