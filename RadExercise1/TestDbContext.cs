using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RadExercise1
{

    public class Student
    {
        public Guid playerid;
        public string FirstName;
        public string SecondName;
    

        public static Student FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Student ImportedStudentRecord = new Student();
            ImportedStudentRecord.playerid = Guid.NewGuid();
            ImportedStudentRecord.FirstName = values[0];
            ImportedStudentRecord.SecondName = values[1];
            return ImportedStudentRecord;
        }
    }
    // Implement IDisposable to allow using 
    class TestDbContext : IDisposable
    {
        private bool disposed = false;
        public List<Student> Students = new List<Student>();
        // Create a set of Clubs

        // Make a random list of students
        public List<Club> Clubs;
        public TestDbContext()
        {

              Students = File.ReadAllLines(@"random Names.csv")
                                           //.Skip(1) // Only needed if the first row contains the Field names
                                           .Select(v => Student.FromCsv(v))
                                           .ToList();
              seedClubs();
            }


        private Guid GetRandomAdmin()
        {
            // This query will create a random ordered selection based on Guids
            Guid result = Students.Select(s =>
            new { s.playerid, r = Guid.NewGuid() }) // generate a list of player ids with a 
            .OrderBy(o => o.r)                      // orderby the guid which is a randomly generated unique id
            .ToList()                               // convert the IEnumeral to a list
            .First().playerid;                      // take the first record and grab th eplayerid Guid field value
            return result;
        }

        private void seedClubs()
        {
            // Create a list of clubs and populate it test data
            List<string> strs = new List<string>() { "1", "2", "3" };

            Clubs = new List<Club>()
            // Club collection
            {
                // First club record 
                new Club {
                id = Guid.NewGuid(),
                ClubName = "ITS FC",
                // Select a random student
                adminID = GetRandomAdmin(),
                 ClubEvents = new List<ClubEvent>(),
                 ClubMembers = new List<Member>(),
                   CreationDate = DateTime.Now
                    },
                // Second Club record
                new Club {
                id = Guid.NewGuid(),
                ClubName = "ITS GAA ",
                // Select a random student
                adminID = GetRandomAdmin(),
                 ClubEvents = new List<ClubEvent>(),
                 ClubMembers = new List<Member>(),
                   CreationDate = DateTime.Now
                    },
                // Third Club record
                new Club {
                id = Guid.NewGuid(),
                ClubName = "The Chess Club ",
                // Select a random student
                adminID = GetRandomAdmin(),
                 ClubEvents = new List<ClubEvent>(),
                 ClubMembers = new List<Member>(),
                   CreationDate = DateTime.Now
                    },

            };

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

            if (!disposed)
            {
                if (disposing)
                {
                    // Manual release of managed resources.
                }
                // Release unmanaged resources.
                disposed = true;
            }
        }
        public List<Student> getTop(int count)
        {
            return Students.Take(count).ToList();
        }

        public void AddEvent(string ClubName, ClubEvent clubEvent)
        {
            Club clubFound = Clubs.FirstOrDefault(c => c.ClubName == ClubName);
            if (clubFound != null)
            {
                clubFound.ClubEvents.Add(clubEvent);
            }
            else Console.WriteLine("Club Name not found {0}", ClubName);
        }

        public void AddMember(string ClubName, Member member)
        {
            Club clubFound = Clubs.FirstOrDefault(c => c.ClubName == ClubName);
            if (clubFound != null)
            {
                clubFound.ClubMembers.Add(member);
            }
            else Console.WriteLine("Club Name not found {0}", ClubName);
        }

        public object Clone()
        {
            return this.Clone();
        }
    }
}
