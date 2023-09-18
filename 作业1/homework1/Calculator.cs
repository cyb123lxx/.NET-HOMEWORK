namespace AutoQuiz
{
    public class Calculator
    {
        public int Calculate(int operand1, int operand2, char @operator)
        {
            switch (@operator)
            {
                case '+':
                    return operand1 + operand2;
                case '-':
                    return operand1 - operand2;
                default:
                    throw new ArgumentException("Invalid operator");
            }
        }
    }
}
