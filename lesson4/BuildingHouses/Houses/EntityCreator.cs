using System;
using System.Collections.Generic;
using System.Linq;
namespace Houses
{
    public abstract class EntityCreator
    {
        internal HashSet<House> _houseSet;
        public abstract House Build(int height, int numOfEntrances, int numOfLevels, int numOfFlats);
    }
}
