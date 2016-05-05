namespace ProcessorScheduling
{
    using System;
    public class Task : IComparable<Task>
    {
        public Task(int id, int value, int deadline)
        {
            this.Id = id;
            this.Value = value;
            this.Deadline = deadline;
        }

        public int Id { get; set; }

        public int Value { get; set; }

        public int Deadline { get; set; }

        public int CompareTo(Task other)
        {
            return other.Value.CompareTo(this.Value);
        }
    }
}
