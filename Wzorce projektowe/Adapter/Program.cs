using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace WzorzecAdapter
{
    public class UsersApi
    {
        public async Task<string> GetUsersXmlAsync()
        {
            var apiResponse = "<?xml version= \"1.0\" encoding= \"UTF-8\"?><users><user name=\"John\" surname=\"Doe\"/><user name=\"John\" surname=\"Wayne\"/><user name=\"John\" surname=\"Rambo\"/></users>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(apiResponse);

            return await Task.FromResult(doc.InnerXml);
        }
    }


    public interface IUserRepository
    {
        List<List<string>> GetUserNames();
    }

    public class UsersApiAdapter : IUserRepository
    {
        private UsersApi _adaptee = null;

        public UsersApiAdapter(UsersApi adaptee)
        {
            _adaptee = adaptee;
        }

        public List<List<string>> GetUserNames()
        {
            string incompatibleApiResponse = this._adaptee
              .GetUsersXmlAsync()
              .GetAwaiter()
              .GetResult();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(incompatibleApiResponse);

            var rootEl = doc.LastChild;

            List<List<string>> users = new List<List<string>>();

            if (rootEl.HasChildNodes)
            {
                List<string> user = new List<string> { };
                foreach (XmlNode node in rootEl.ChildNodes)
                {
                    user = new List<string> { node.Attributes["name"].InnerText, node.Attributes["surname"].InnerText };
                    users.Add(user);
                }
            }
            return users;
        }

    }

    public class UsersCsv
    {
        public List<List<string>> GetUsersCsv()
        {
            string path = "users.csv"; // ustaw ścieżkę do pliku csv
            var lines = File.ReadAllLines(path);
            List<List<string>> users = new List<List<string>>();

            for (int i = 0; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                users.Add(new List<string> { parts[0], parts[1] });
            }

            return users;
        }
    }
    public class UsersCsvAdapter : IUserRepository
    {
        private UsersCsv _adaptee = null;

        public UsersCsvAdapter(UsersCsv adaptee)
        {
            _adaptee = adaptee;
        }

        public List<List<string>> GetUserNames()
        {
            return this._adaptee.GetUsersCsv();
        }
    }

    public class Program
    {

        static void Main(string[] args)
        {
            UsersApi usersRepository = new UsersApi();
            IUserRepository apiAdapter = new UsersApiAdapter(usersRepository);

            Console.WriteLine("Użytkownicy z API:");
            List<List<string>> apiUsers = apiAdapter.GetUserNames();
            int i = 1;
            apiUsers.ForEach(user =>
            {
                Console.WriteLine(" " + i + ". " + user[0] + " " + user[1]);
                i++;
            });

            Console.WriteLine();

            UsersCsv csvRepository = new UsersCsv();
            IUserRepository csvAdapter = new UsersCsvAdapter(csvRepository);

            Console.WriteLine("Użytkownicy z CSV:");

            //List<List<string>> csvUsers = csvAdapter.GetUserNames();
            //i = 1;
            //csvUsers.ForEach(user => {
            //    Console.WriteLine(" " + i + ". " + user[0] + " " + user[1]);
            //    i++;
            List<List<string>> csvUsers = csvAdapter.GetUserNames();
            i = 1;
            csvUsers.ForEach(user =>
            {
                Console.WriteLine("{0,2}. {1} {2}", i, user[0], user[1]);
                i++;
            });
        }


    }


}