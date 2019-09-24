using System;
using System.Collections.Generic;
using System.Linq;

namespace DocusignChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            selectRandomServer(args);
        }

        /// <summary>
        /// I thought of three different ways you could approach this problem.
        /// 1) Add all each server to a list the number of times the server appears. This runs into space complexity issues with larger data sets. O(n*M) space and O(n) time
        /// 2) Add each server to a frequency table, generate a random number based on how many elements were found then lookup the frequency using something resembling a bianry search. O(n) space, O(n) + O(log(n)) time
        /// 3) Get the total number of servers, pick a random number from 0 to the range, iterate over the servers again until the current index is greater than the sum of servers. O(1) space and O(2n) time which is really just O(n)
        /// Because option three has the lowest combination of space and time complexity I decide to go with that route. With large datasets and persistant storage, option two would probably be a better option.
        /// </summary>

        private static void selectRandomServer(string[] input)
        {
            // Find the total number of servers
            var totalServers = 0;
            foreach (var entry in input)
            {                
                totalServers += getServerCount(entry);
            }

            // Make a random selection from the list
            var randomObj = new Random();
            var randomNumber = randomObj.Next(totalServers);

            // Go through the list again until we exceed the random number
            var sum = 0;
            foreach (var entry in input)
            {
                sum += getServerCount(entry);

                if (sum > randomNumber)
                {
                    Console.WriteLine(getServerName(entry));
                    return;
                }
            }
        }

        private static int getServerCount(string input)
        {
            var entrySplit = input.Split(':');
            var serverCountString = entrySplit[1];
            var serverCount = int.Parse(serverCountString);
            return serverCount;
        }

        private static string getServerName(string input)
        {
            var entrySplit = input.Split(':');
            var serverName = entrySplit[0];
            return serverName;
        }
    }
}
