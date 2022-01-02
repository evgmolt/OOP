using System;
using System.Collections.Generic;
namespace Houses
{
    public sealed class Creator : EntityCreator
    {
        internal Creator()
        {
            _houseSet = new();
        }

        public override House Build(int height, int numOfEntrances, int numOfLevels, int numOfFlats)
        {
            var house = new House(height, numOfEntrances, numOfLevels, numOfFlats);
            _houseSet.Add(house);
            return house;
        }
    }
}
