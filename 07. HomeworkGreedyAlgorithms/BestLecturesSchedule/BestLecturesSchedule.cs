namespace BestLecturesSchedule
{
    using System;
    using System.Collections.Generic;

    public class BestLecturesSchedule
    {
        public static void Main(string[] args)
        {
            int lectureCount = int.Parse(Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)[1]);
            List<Lecture> lectures = new List<Lecture>();
            for (int i = 0; i < lectureCount; i++)
            {
                string[] lectureParams = Console.ReadLine()
                    .Split(new[] {':', '-', ' '}, StringSplitOptions.RemoveEmptyEntries);
                string lectureName = lectureParams[0];
                int startTime = int.Parse(lectureParams[1]);
                int endTime = int.Parse(lectureParams[2]);
                var lecture = new Lecture(lectureName, startTime, endTime);
                lectures.Add(lecture);
            }

            lectures.Sort();
            List<Lecture> selectedLectures = new List<Lecture>();
            while (lectures.Count > 0)
            {
                var currentLecture = lectures[0];
                selectedLectures.Add(currentLecture);
                lectures.RemoveAll(l => l.StartTime < currentLecture.EndTime);
            }

            Console.WriteLine($"Lectures ({selectedLectures.Count}):");
            foreach (var selectedLecture in selectedLectures)
            {
                Console.WriteLine(selectedLecture);
            }
        }
    }
}
