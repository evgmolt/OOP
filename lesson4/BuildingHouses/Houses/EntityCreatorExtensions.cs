namespace Houses
{
    public static class EntityCreatorExtensions
    {
        public static EntityCreator CreateCreator() => new Creator();
        public static void RemoveByNumber(this EntityCreator creator, int number)
        {
            creator._houseSet.RemoveWhere(h => h.Number == number);
        }
        public static IEnumerable<House> GetList(this EntityCreator creator)
        {
            return creator._houseSet.ToList();
        }
    }
}
