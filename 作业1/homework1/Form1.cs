using System;
using System.Windows.Forms;

namespace AutoQuiz
{
    public partial class Form1 : Form
    {
        private Calculator calculator;
        private Random random;
        private int numQuestions;
        private int currentQuestion;
        private int correctAnswers;
        private int incorrectAnswers;

        public Form1()
        {
            InitializeComponent();
            calculator = new Calculator();
            random = new Random();
            numQuestions = 5; // 题目数量
            currentQuestion = 1;
            correctAnswers = 0;
            incorrectAnswers = 0;
            DisplayQuestion();
        }

        private void DisplayQuestion()
        {
            int operand1 = random.Next(10); // 随机生成操作数
            int operand2 = random.Next(10);
            int operatorIndex = random.Next(2); // 随机生成运算符索引，0表示加法，1表示减法
            char @operator = operatorIndex == 0 ? '+' : '-';
            int answer = calculator.Calculate(operand1, operand2, @operator);

            labelQuestion.Text = $"Question {currentQuestion}/{numQuestions}: {operand1} {@operator} {operand2} = ?";
            textBoxAnswer.Text = "";
            textBoxAnswer.BackColor = SystemColors.Window;
            textBoxAnswer.Focus();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            int operand1 = int.Parse(labelQuestion.Text.Split(':')[1].Split('+', '-')[0].Trim());
            int operand2 = int.Parse(labelQuestion.Text.Split(':')[1].Split('+', '-')[1].Trim());
            char @operator = labelQuestion.Text.Contains("+") ? '+' : '-';
            int answer = calculator.Calculate(operand1, operand2, @operator);

            int userAnswer;
            if (int.TryParse(textBoxAnswer.Text, out userAnswer))
            {
                if (userAnswer == answer)
                {
                    DisplayFeedback(true);
                    correctAnswers++;
                }
                else
                {
                    DisplayFeedback(false);
                    incorrectAnswers++;
                }

                currentQuestion++;

                if (currentQuestion > numQuestions)
                {
                    timer.Stop();
                    int score = (int)(((double)correctAnswers / numQuestions) * 100);
                    MessageBox.Show($"Quiz completed!\n\nCorrect Answers: {correctAnswers}\nIncorrect Answers: {incorrectAnswers}\nScore: {score}%");
                    buttonSubmit.Enabled = false;
                }
                else
                {
                    DisplayQuestion();
                }
            }
        }

        private void DisplayFeedback(bool isCorrect)
        {
            textBoxAnswer.BackColor = isCorrect ? Color.LightGreen : Color.LightCoral;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (currentQuestion > numQuestions)
            {
                timer.Stop();
                MessageBox.Show("Quiz time is up!");
                buttonSubmit.Enabled = false;
            }
            else
            {
                timer.Stop();
                IncorrectAnswerTimeout();
            }
        }

        private void IncorrectAnswerTimeout()
        {
            DisplayFeedback(false);
            incorrectAnswers++;
            currentQuestion++;

            if (currentQuestion > numQuestions)
            {
                MessageBox.Show($"Quiz completed!\n\nCorrect Answers: {correctAnswers}\nIncorrect Answers: {incorrectAnswers}");
                buttonSubmit.Enabled = false;
            }
            else
            {
                DisplayQuestion();
            }
        }
    }
}
