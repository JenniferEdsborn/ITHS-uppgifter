namespace DesignPatterns.Patterns.BuilderPattern
{
    public interface IHouseBuilder
    {
        void BuildFoundation();
        void BuildStructure();
        void BuildRoof();
        House GetHouse();
    }
}
