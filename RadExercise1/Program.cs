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
            //TestDbContext db = new TestDbContext()

            // Q1
            foreach (Club c in db.Clubs)
            {
                Console.WriteLine(c.Info);
            }

            //foreach (Student s in db.Students)
            //{
            //    Console.WriteLine(s.FirstName + " " + s.SecondName);
            //}
            db.AddEvent("ITS FC", new ClubEvent
            {
                attendees = new List<Member>(),
                Venue = "Sligo",
                EventName = "Indoor Soccer",
                StartDateTime = new DateTime(2016, 6, 16, 16, 00, 00, DateTimeKind.Local),
                EndDateTime = new DateTime(2016, 6, 16, 18, 00, 00, DateTimeKind.Local)

            });
            db.AddEvent("ITS FC", new ClubEvent
            {
                attendees = new List<Member>(),
                Venue = "Dublin",
                EventName = "Trials",
                StartDateTime = new DateTime(2016, 12, 09, 14, 00, 00, DateTimeKind.Local),
                EndDateTime = new DateTime(2016, 12, 09, 14, 30, 00, DateTimeKind.Local)

            });

            db.AddMember("ITS GAA ", new Member
            {
                memberID = Guid.NewGuid(),
                approved = true,
                admin = false
            });

            // Question 2
            foreach (ClubEvent c in Question2(new DateTime(2016, 12, 09, 13, 00, 00), new DateTime(2016, 12, 09, 15, 00, 00)))
            {
                Console.WriteLine("{0} Event on at {1} sarts {2} and finishes at {3}", c.EventName, c.Venue, c.StartDateTime, c.EndDateTime);
            }

            // Question 3
            Question3("ITS FC");
            Console.ReadKey();


        }

        static public List<ClubEvent> Question2(DateTime start, DateTime end)
        {
            // Get the events across all the clubs
            List<ClubEvent> AllClubEvents = (List<ClubEvent>)db.Clubs.SelectMany(c => c.ClubEvents).ToList();
            // Get those events in the range
            return AllClubEvents.Where(
                                    e => e.StartDateTime >= start &&
                                    e.EndDateTime <= end).ToList();
        }

        static public void Question3(string clubName)
        {
            Console.WriteLine("Events for " + clubName);
            foreach (Club c in db.Clubs)
            {
                var query = from e in c.ClubEvents
                            where c.ClubName == clubName
                            select e;
                
                foreach (ClubEvent clubEv in query)
                {
                    Console.WriteLine(clubEv.Venue + " " + clubEv.EventName);
                }
            }
        }

        //static public List<Member> Question4()
        //{

        //}
    }
}
