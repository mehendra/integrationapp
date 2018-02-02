using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomLunchDateCreator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var allInterestedMemebers = AllOfApiInWellington().Except(ApiMeebersNotParticipating());
            var lunchDateCreator = new LunchDateCreator();
            var allTeamGroups = lunchDateCreator.GroupedMembersIntoTeams(allInterestedMemebers, 4);
            foreach (var teamGroups in allTeamGroups)
            {
                Console.WriteLine(teamGroups.TeamName);
                var names = String.Join(",", teamGroups.Memebers);
                Console.WriteLine(names);
            }
            Console.ReadLine();
        }

        public static string[] AllOfApiInWellington()
        {
            return new[]
            {

            };
        }

        public static string[] ApiMeebersNotParticipating()
        {
            return new[] {""};
 
        }

    }
}
