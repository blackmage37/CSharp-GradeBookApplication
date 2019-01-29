using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count<5)
            {
                throw new System.InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            int sRank = Students.Count + 1;

            foreach (Student s in Students)
            {

                if (averageGrade > s.AverageGrade) { sRank -= 1; }

            }

            float fRank = sRank / Students.Count;

            if (fRank <= 0.2)
            {
                return 'A';
            } else if(fRank <= 0.4)
            {
                return 'B';
            } else if(fRank <= 0.6)
            {
                return 'C';
            } else if(fRank <= 0.8)
            {
                return 'D';
            } else
            {
                return 'F';
            }

        }

    }
}
