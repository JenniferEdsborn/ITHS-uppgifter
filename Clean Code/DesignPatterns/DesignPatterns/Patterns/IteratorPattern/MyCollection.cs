namespace DesignPatterns.Patterns.IteratorPattern
{
    internal class MyCollection : IContainer
    {
        private int[] collection;

        public MyCollection(int[] collection)
        {
            this.collection = collection;
        }

        public IIterator GetIterator()
        {
            return new MyIterator(collection);
        }
    }
}
