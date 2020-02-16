using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
   public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work.");

            var trashold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();

            if (grades[trashold-1] <= averageGrade)
                return 'A';
            else if (grades[trashold*2-1] <= averageGrade)
                return 'B';
            else if (grades[trashold*3-1] <= averageGrade)
                return 'C';
            else if (grades[trashold*4-1] <= averageGrade)
                return 'D';
            else
                return 'F';

        }
    }
}
