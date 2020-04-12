using System.Linq;

namespace coding_challenges.implementations
{
    /// <summary>
    /// Evaluates a tape of binary symbols and manipulates them based on a set of rules, as defined in the transition function.
    /// </summary>
    public class TuringMachine
    {
        protected readonly TransitionFunction TransitionFunction;
        protected readonly int States;
        public int State;

        public TuringMachine(int states, TransitionFunction transitionFunction)
        {
            States = states;
            State = 1;
            TransitionFunction = transitionFunction;
        }

        public virtual int[] Execute(int[] tape)
        {
            var index = 0;
            while (index >= 0 && index < tape.Length && State <= States)
            {
                var context = TransitionFunction(State, tape[index]);
                tape[index] = context.NewSymbol;
                index = context.MoveRight ? index + 1 : index - 1;
                State = context.NewState;
            }
            return tape;
        }
    }

    /// <summary>
    /// A Turing Machine that aims to add the most 1's to the tape for a given number of states. The final state must be a halt state.
    /// </summary>
    public class BusyBeaver : TuringMachine
    {
        public static int Score(int[] output) => output.Count(i => i == 1);

        public BusyBeaver(int states, TransitionFunction transitionFunction)
        : base(states, transitionFunction)
        { }
    }

    /// <summary>
    /// A function to decide how to respond to the given state and symbol
    /// </summary>
    /// <param name="currentState"></param>
    /// <param name="currentSymbol"></param>
    /// <returns></returns>
    public delegate TuringContext TransitionFunction(int currentState, int currentSymbol);

    /// <summary>
    /// the response to the transition function
    /// </summary>
    public class TuringContext
    {
        public int NewState { get; set; }
        public bool MoveRight { get; set; }
        public int NewSymbol { get; set; }

        public TuringContext(int newState, int newSymbol, bool moveRight)
        {
            NewState = newState;
            MoveRight = moveRight;
            NewSymbol = newSymbol;
        }
    }
}
