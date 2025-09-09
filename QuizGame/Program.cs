
namespace QuizGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;

            string[] questions = new string[]
            {
                "1. What is the capital of France?",
                "2. What is the red planet?",
                "3. What is the largest planet in the solar system?",
                "4. Who developed the theory of relativity?",
                "5. What is the chemical symbol for water?",
                "6. Which continent is the Sahara Desert located on?",
                "7. What is the fastest land animal?",
                "8. Who painted the Mona Lisa?",
                "9. How many continents are there on Earth?",
                "10. What is the smallest prime number?"
            };

           string[] answers = new string[]
            {
                "Paris",
                "Mars",
                "Jupiter",
                "Einstein",   
                "H2O",
                "Africa",
                "Cheetah",
                "Da Vinci",   
                "7",
                "2"
            };

            Console.WriteLine("=== Welcome to the Quiz Game! ===\n");
            Console.WriteLine("Please answer the following questions:\n");

            for (int i = 0; i < questions.Length; i++) 
            {
                Console.WriteLine(questions[i]);
                string userAnswer = Console.ReadLine();

                if (string.Equals(userAnswer, answers[i], StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct!\n");
                    Console.ResetColor();
                    score++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Incorrect! The correct answer is {answers[i]}.\n");
                    Console.ResetColor();
                }
            }

            Console.WriteLine($" You got {score} out of {questions.Length} correct!");
            Console.ReadKey();
        }
    }
}