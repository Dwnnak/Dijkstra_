namespace DijkstraAlgorhitm
{
    public class PQElement<T>
    {
        public int Priority { get; set; }
        public T Element { get; set; }

        public PQElement(T value, int priority)
        {
            Priority = priority;
            Element = value;
        }
    }
}
