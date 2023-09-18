namespace Interpreter
{
    /// <summary>
    /// Context
    /// This contains information that is global to the interpreter
    /// </summary>
    public class RomanContext
    {
        public int Input { get; set; }
        public string Output { get; set; } = string.Empty;

        public RomanContext(int input)
        {
            Input = input;
        }
    }

    /// <summary>
    /// AbstractExpression
    /// This declares an abstract Interpret operation that is commone to all
    /// nodes in the abstract syntax tree
    /// </summary>
    public abstract class RomanExpression
    {
        public abstract void Interpret(RomanContext context);
    }

    /// <summary>
    /// Terminal Expression
    /// This implements an interpret operation associated with terminal symbol
    /// in the grammar
    /// </summary>
    public class RomanHundredExpression : RomanExpression
    {
        public override void Interpret(RomanContext context)
        {
            while ((context.Input - 900) >= 0)
            {
                context.Output += "CM";
                context.Input -= 900;
            }

            while ((context.Input - 500) >= 0)
            {
                context.Output += "D";
                context.Input -= 500;
            }

            while ((context.Input - 400) >= 0)
            {
                context.Output += "CD";
                context.Input -= 400;
            }

            while ((context.Input - 100) >= 0)
            {
                context.Output += "C";
                context.Input -= 100;
            }
        }
    }

    /// <summary>
    /// Terminal Expression
    /// This implements an interpret operation associated with terminal symbol
    /// in the grammar
    /// </summary>
    public class RomanTenExpression : RomanExpression
    {
        public override void Interpret(RomanContext context)
        {
            while ((context.Input - 90) >= 0)
            {
                context.Output += "XC";
                context.Input -= 90;
            }

            while ((context.Input - 50) >= 0)
            {
                context.Output += "L";
                context.Input -= 50;
            }

            while ((context.Input - 40) >= 0)
            {
                context.Output += "XL";
                context.Input -= 40;
            }

            while ((context.Input - 10) >= 0)
            {
                context.Output += "X";
                context.Input -= 10;
            }
        }
    }

    /// <summary>
    /// Terminal Expression
    /// This implements an interpret operation associated with terminal symbol
    /// in the grammar
    /// </summary>
    public class RomanOneExpression : RomanExpression
    {
        public override void Interpret(RomanContext context)
        {
            while ((context.Input - 9) >= 0)
            {
                context.Output += "IX";
                context.Input -= 9;
            }

            while ((context.Input - 5) >= 0)
            {
                context.Output += "V";
                context.Input -= 5;
            }

            while ((context.Input - 4) >= 0)
            {
                context.Output += "IV";
                context.Input -= 4;
            }

            while ((context.Input - 1) >= 0)
            {
                context.Output += "I";
                context.Input -= 1;
            }
        }
    }
}
