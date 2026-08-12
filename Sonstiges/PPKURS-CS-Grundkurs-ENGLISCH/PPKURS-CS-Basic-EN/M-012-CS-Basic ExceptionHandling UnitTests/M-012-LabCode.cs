using System;

namespace Lab12_ExceptionHandling
{
    public enum Operation { Addition = 1, Subtraction, Multiplication, Division }

    class Program
    {
        static void Main(string[] args)
        {
            string input = GetInput();

            Term term = new Term(input);

            int result = CalculateTerm(term);

            Console.WriteLine($"\t={result}");
        }

        //Only edit the code in the main method.
        static string GetInput()
        {
            Console.WriteLine("Please enter a term with two numbers and a basic arithmetic operator (+ - * /) (e.g.: 25+13):");
            return Console.ReadLine();
        }

        static int CalculateTerm(Term term)
        {
            switch (term.Operation)
            {
                case Operation.Addition:
                    return term.Number1 + term.Number2;
                case Operation.Subtraction:
                    return term.Number1 - term.Number2;
                case Operation.Multiplication:
                    return term.Number1 * term.Number2;
                default:
                    return term.Number1 / term.Number2;
            }
        }
    }

    class Term
    {
        public string Input { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public Operation Operation { get; set; }

        public Term(string term)
        {
            this.Input = term;
            this.Operation = this.GetOperation();

            string[] numbers = this.SplitTerm();

            this.Number1 = int.Parse(numbers[0]);
            this.Number2 = int.Parse(numbers[1]);
        }

        private Operation GetOperation()
        {
            if (this.Input.Contains('+'))
                return Operation.Addition;
            else if (this.Input.Contains('-'))
                return Operation.Subtraction;
            else if (this.Input.Contains('*'))
                return Operation.Multiplication;
            else if (this.Input.Contains('/'))
                return Operation.Division;
            else
                return 0;
        }

        private string[] SplitTerm()
        {
            switch (this.Operation)
            {
                case Operation.Addition:
                    return this.Input.Split('+');
                case Operation.Subtraction:
                    return this.Input.Split('-');
                case Operation.Multiplication:
                    return this.Input.Split('*');
                case Operation.Division:
                    return this.Input.Split('/');
            }
            return null;
        }
    }
}
