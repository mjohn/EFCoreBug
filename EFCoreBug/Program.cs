using EFCoreBug.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreBug
{
    class Program
    {
        static void Main(string[] args)
        {
            

            AddTestData();
            Console.WriteLine("Test data is added");
            LoadTestData();
            Console.WriteLine("Test data is loaded");
            LoadTestDataWithPaging();
            Console.WriteLine("Test data is loaded with paging");

            Console.ReadKey();
        }

        static void AddTestData()
        {
            using (NoteDbContext context = new NoteDbContext())
            {
                Note note = new Note()
                {
                    Text = "Foo Bar",
                    User = new User()
                    {
                        Email = "foobar@foo.com",
                        Fullname = "Mehmet Can Kamar"
                    }
                };
                context.Note.Add(note);
                context.SaveChanges();
            }
        }

        static List<Note> LoadTestData()
        {
            using (NoteDbContext context = new NoteDbContext())
            {
                return context.Note.Where(x => x.Text == "Foo Bar").ToList();
            }
        }
        static List<Note> LoadTestDataWithPaging()
        {
            using (NoteDbContext context = new NoteDbContext())
            {
                var queryableObj =  context.Note.Where(x => x.Text == "Foo Bar").AsQueryable();
                return queryableObj.Skip(0).Take(100).ToList();
            }
        }
    }
}
