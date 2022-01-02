namespace Houses
{
    public sealed class House
    {
        private readonly int _number;
        private readonly int _height;
        private readonly int _numOfEntrances;
        private readonly int _numOfLevels;
        private readonly int _numOfFlats;

        private static int LastNumber;

        internal House(int height, int numOfEntrances, int numOfLevels, int numOfFlats)
        {
            _number = GetNumber();
            _height = height;
            _numOfEntrances = numOfEntrances;
            _numOfLevels = numOfLevels;
            _numOfFlats = numOfFlats;
        }
        private static int GetNumber()
        {
            return ++LastNumber;
        }

        public int Number
        {
            get => _number;
        }

        public int Height
        {
            get => _height;
        }

        public int NumOfEntrances
        {
            get => _numOfEntrances;
        }

        public int NumOfLevels
        {
            get => _numOfLevels;
        }
        public int NumOfFlats
        {
            get => _numOfFlats;
        }

        public int GetLevelHeight()
        {
            var result = _numOfLevels is 0? -1 : _height / _numOfLevels;
            return result;
        }
        public int GetNumOfFlatsPerEntrance()
        {
            var result = _numOfEntrances is 0 ? -1 : _numOfFlats / _numOfEntrances;
            return result;
        }
        public int GetNumOfFlatsPerLevel()
        {
            var result = _numOfLevels is 0 ? -1 : GetNumOfFlatsPerEntrance() / _numOfLevels;
            return result;
        }
        public override string ToString()
        {
            return "House " + _number.ToString();
        }
    }
}