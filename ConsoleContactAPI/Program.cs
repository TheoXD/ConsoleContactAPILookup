using System;

using System.Threading.Tasks;
using Nito.AsyncEx;

namespace ConsoleContactAPI
{
    class Program
    {
        private static bool IsValidEmail(string _email)
        {
            if (_email.Contains("@"))
            {
                string[] email_exploded = _email.Split("@");
                if (email_exploded[0].Length > 0 && email_exploded[1].Length > 0)
                {
                    return IsValidDomain(email_exploded[1]);
                }

            }

            return false;
        }

        private static bool IsValidDomain(string _domain)
        {
            if (_domain.Contains("."))
            {
                string[] domain_exploded = _domain.Split(".");
                for(int i = 0; i < domain_exploded.Length; i++)
                {
                    if (domain_exploded[i].Length == 0) return false;
                }

                if (Uri.CheckHostName(_domain) != UriHostNameType.Unknown)
                {
                    return true;
                }

            }

            return false;
        }

        private static async Task<FullContactPerson> GetPersonalInfoByEmail(string _email)
        {
            if (IsValidEmail(_email))
            {
                FullContactAPI api = new FullContactAPI();

                FullContactPerson person = await api.LookupPersonByEmailAsync(_email);

                return person;
            }
            else
            {
                //Console.WriteLine("invalid email address");
                throw new Exception("invalid email address");
            }
        }

        private static async Task ProcessUserInput(string _user_input)
        {
            Console.WriteLine("Looking up user with email '" + _user_input + "'");
            try {
                FullContactPerson person = await GetPersonalInfoByEmail(_user_input);
                //We have to make sure data is fetched before we print
                Console.WriteLine(person);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Main(string[] args)
        {
            try
            {
                string external_api_key = System.IO.File.ReadAllText(@"./api_key.txt");
                Config.Instance.APIKey = external_api_key;
            }
            catch
            {
                Console.WriteLine("[WARNING] : unable to open ./api_key.txt, you can enter your APIKey there.");
            }



            while (true)
            {
                Console.WriteLine("Enter e-mail:");

                string fallback_email = "bart@fullcontact.com"; //demo email
                string probably_email = Console.ReadLine();
                probably_email = (probably_email.Length > 0) ? probably_email : fallback_email;

                Task process_user_input = ProcessUserInput(probably_email);
                process_user_input.Wait();

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
