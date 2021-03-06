﻿namespace BestLecturesSchedule
{
    using System;
    public class Lecture : IComparable<Lecture>
    {
        public Lecture(string name, int startTime, int endTime)
        {
            this.Name = name;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public string Name { get; set; }

        public int StartTime { get; set; }

        public int EndTime { get; set; }


        public int CompareTo(Lecture other)
        {
            return this.EndTime.CompareTo(other.EndTime);
        }

        public override string ToString()
        {
            return string.Format($"{this.StartTime}-{this.EndTime} -> {this.Name}");
        }
    }
}
