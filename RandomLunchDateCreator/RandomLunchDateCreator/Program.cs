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
                "Adam Moore[@adam.moore]",
                "Amy Martin[@amym]",
                "Bryan Tee[@bryan.tee]",
                "Chloe Graham[@chloe.graham]",
                "Matthew Mortimer[@matthew.mortimer]",
                "Nick Green[@nick.green]",
                "Phil Alsford[@phil]",
                "Russell Dear[@russell]",
                "Steven McDonald[@steven.mcdonald]",
                "Tim Caldwell[@tim.caldwell]",
                "Vanessa Thornton[@vanessa.thornton]",
                "Welli Abdullah[@welli.abdullah]",
                "Steven Brown[@steven.brown]",
                "Yasmine Sefouane[@yasmine.sefouane]",
                "Dan Young[@dan.young]",
                "Jay Lowe[@jay.lowe]",
                "Kent Le Quesne[@kent.lequesne]",
                "Marlon Gonzales[@marlon.gonzales]",
                "Mehendra Munasinghe[@mehendra]",
                "Pedro Azevedo[@pedro.azevedo]",
                "Richard Fortune[@richard.fortune]",
                "Russell Briggs[@briggsy]",
                "Samitha Nair[@samitha.nair]",
                "Dan O'Donnell [@danny]"
            };
        }

        public static string[] ApiMeebersNotParticipating()
        {
            return new[] {""};
            /*
            return new[]
            {
                "Phil Alsford[@phil]","Samitha Nair[@samitha.nair]"
            };
            */
        }

    }
}
