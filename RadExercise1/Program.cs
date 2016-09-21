using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadExercise1
{
    class Program
    {
        static TestDbContext db = new TestDbContext();
        static void Main(string[] args)
        {
            TestDbContext db = new TestDbContext();

            //foreach(Club c in db.Clubs )
            //{
            //    Console.WriteLine(c.Info);
            //}
            //foreach (Student s in db.Students)
            //{
            //    Console.WriteLine(s.FirstName  + " " +  s.SecondName);
            //}

            db.AddEvent("ITS FC", new ClubEvent
            {
                attendees = new List<Member>(),
                Venue = "HTC Arena",
                StartDateTime = new DateTime(2016, 12, 12, 16, 00, 00, DateTimeKind.Local),
                EndDateTime = new DateTime(2016,12, 12, 18, 00, 00, DateTimeKind.Local),
            });
            db.AddEvent("ITS FC", new ClubEvent
            {
                attendees = new List<Member>(),
                Venue = "Trials",
                StartDateTime = new DateTime(2016,12, 09,  13, 00, 00, DateTimeKind.Local),
                EndDateTime = new DateTime(2016, 12, 09,  15, 00, 00, DateTimeKind.Local),
            });
            

            Console.ReadKey();
            
             
        }

        
    }
}
