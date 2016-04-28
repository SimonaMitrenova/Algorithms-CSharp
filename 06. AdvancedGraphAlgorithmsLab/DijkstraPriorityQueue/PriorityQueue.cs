namespace DijkstraPriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> heap;
        private Dictionary<T, int> indices; 

        public PriorityQueue()
        {
            this.heap = new List<T>();
            this.indices = new Dictionary<T, int>();
        }

        public PriorityQueue(IEnumerable<T> elements)
        {
            this.heap = new List<T>(elements);
            this.indices = new Dictionary<T, int>();
            
            for (int index = this.Count - 1; index >= 0; index--)
            {
                this.indices[this.heap[index]] = index;
                this.HeapifyDown(index);
            }
        }

        public int Count => this.heap.Count;

        public T ExtractMin()
        {
            var min = this.heap[0];
            this.heap[0] = this.heap[this.Count - 1];
            this.heap.RemoveAt(this.Count - 1);
            if (this.Count > 0)
            {
                this.HeapifyDown(0);
            }
            return min;
        }

        public T PeekMin()
        {
            return this.heap[0];
        }

        public void Insert(T node)
        {
            this.heap.Add(node);
            this.HeapifyUp(this.Count - 1);
        }

        public void InsertAt(int index, T node)
        {
            this.heap.RemoveAt(index);
            this.heap.Insert(index, node);
        }

        public int FindIndex(T node)
        {
            if (!this.indices.ContainsKey(node))
            {
                return -1;
            }

            return this.indices[node];
        }

        private void HeapifyDown(int index)
        {
            var left = (2 * index) + 1;
            var right = (2 * index) + 2;
            var smallest = index;

            if (left < this.heap.Count && this.heap[left].CompareTo(this.heap[smallest]) < 0)
            {
                smallest = left;
            }
            if (right < this.heap.Count && this.heap[right].CompareTo(this.heap[smallest]) < 0)
            {
                smallest = right;
            }
            if (smallest != index)
            {
                T old = this.heap[index];
                this.heap[index] = this.heap[smallest];
                this.heap[smallest] = old;
                this.indices[this.heap[smallest]] = smallest;
                this.indices[this.heap[index]] = index;
                this.HeapifyDown(smallest);
            }
        }

        private void HeapifyUp(int index)
        {
            var parent = (index - 1) / 2;
            while (index > 0 && this.heap[index].CompareTo(this.heap[parent]) < 0)
            {
                T old = this.heap[index];
                this.heap[index] = this.heap[parent];
                this.heap[parent] = old;
                this.indices[this.heap[parent]] = parent;
                this.indices[this.heap[index]] = index;

                index = parent;
                parent = (index - 1) / 2;
            }
        }
    }
}
