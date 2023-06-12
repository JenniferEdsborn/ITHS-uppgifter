namespace DesignPatterns.Patterns.IteratorPattern
{
    public class MyIterator : IIterator
    {
        private int[] collection;
        private int currentIndex = 0;

        public MyIterator(int[] collection)
        {
            this.collection = collection;
        }

        public bool HasNext()
        {
            return currentIndex < collection.Length;
        }

        public object Next()
        {
            int element = collection[currentIndex];
            currentIndex++;
            return element;
        }
    }
}
