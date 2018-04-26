namespace PriorityQueue
{
    public interface IPriorityQueue<T>
    {
        void Insert(T item);

        T Extract();

        T Peek();

        int GetSize();

        bool IsFull();

        bool IsEmpty();
    }
}