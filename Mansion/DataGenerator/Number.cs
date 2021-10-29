namespace Mansion.DataGenerator
{
    class Number : ICharacter
    {
        public int N;

        public Number()
        {
            N = 0;
        }

        public bool Increment()
        {
            N = (N + 1) % 10;
            return N == 0;
        }

        public override string ToString()
        {
            return N.ToString();
        }
    }
}
