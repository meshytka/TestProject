using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using System.Xml.Linq;

namespace TestLinq
{
    class LinqTasksLevelTwo
    {
        // Output all elements excepting ArtObjects
        public void Task1()
        {
            Console.WriteLine(DataSource.Data()); // lul

            Console.WriteLine(DataSource.Data().Select(o => o is not ArtObject));
        }

        // Output all actors names
        public void Task2()
        {
            Console.WriteLine(DataSource.Data().SelectMany(o => o is Film f ? f.Actors : new List<Actor>()));
        }

        // Output number of actors born in august
        public void Task3()
        {
            Console.WriteLine(DataSource.Data().SelectMany(o => o is Film f ? f.Actors : new List<Actor>()).Distinct().Count(a => a.Birthdate.Month == 8));
        }

        // Output two oldest actors names
        public void Task4()
        {
            Console.WriteLine(DataSource.Data().SelectMany(o => o is Film f ? f.Actors : new List<Actor>()).Distinct().OrderByDescending(a => a.Birthdate).Take(2).Select(a => a.Name));
        }

        // Output number of books per authors
        public void Task5()
        {
            Console.WriteLine(DataSource.Data().Where(o => o is Book).Cast<Book>().GroupBy(b  => b.Author, (s,b) => new { Author = s, BooksNumber = b.Count() }));
        }

        //6. Output number of books per authors and films per director
        public void Task6()
        {
            Console.WriteLine(DataSource.Data().Where(o => o is Book).Cast<Book>().GroupBy(b => b.Author, (s, b) => new { Author = s, Number = b.Count() }).Union(DataSource.Data().Where(o => o is Film).Cast<Film>().GroupBy(f => f.Author, (a, f) => new { Author = a, Number = f.Count() })));
        }

        //7. Output how many different letters used in all actors names
        //8. Output names of all books ordered by names of their authors and number of pages
        //9. Output actor name and all films with this actor
        //10. Output sum of total number of pages in all books and all int values inside all sequences in data
        //11. Get the dictionary with the key - book author, value - list of author's books
        //12. Output all films of "Matt Damon" excluding films with actors whose name are presented in data as strings
    }

    class Actor
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }

    abstract class ArtObject
    {

        public string Author { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
    class Film : ArtObject
    {

        public int Length { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }
    class Book : ArtObject
    {

        public int Pages { get; set; }
    }

    static class DataSource
    {
        public static List<object> Data() => new List<object>() {
                        "Hello",
                        new Book() { Author = "Terry Pratchett", Name = "Guards! Guards!", Pages = 810 },
                        new List<int>() {4, 6, 8, 2},
                        new string[] {"Hello inside array"},
                        new Film() { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
                            new Actor() { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
                            new Actor() { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                            new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
                        }},
                        new Film() { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
                            new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                            new Actor() { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
                        }},
                        new Book() { Author = "Stephen King", Name="Finders Keepers", Pages = 200},
                        "Leonardo DiCaprio"
                    };
    }
}
