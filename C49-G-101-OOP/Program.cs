namespace C49_G_101_OOP;


internal class Program
{
    static void Main(string[] args)
    {
        Subject subject = new Subject(1, "exam");

        subject.CreateExam();

        Console.Clear();
        if (InputHelper.ReadYesNo(" Start exam ? Y/N "))
        {
            subject.Exam!.ShowExam();
        }
    }
}
