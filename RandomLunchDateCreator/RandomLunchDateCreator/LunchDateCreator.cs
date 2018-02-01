using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomLunchDateCreator
{
    public class LunchDateCreator
    {
        private readonly string[] _teamNames;

        public LunchDateCreator()
        {
            _teamNames = GetAListOfTeams().ToArray();
        }

        public List<TeamGroups> GroupedMembersIntoTeams(IEnumerable<string> teamMemebers, int numberOfTeams)
        {
            var taskFactory = new TaskFactory();
            IEnumerable<string> shuffledTeamMembers = new List<string>();
            List<TeamGroups> teamGroups = null;
            var allRunningTasks = new List<Task>
            {
                taskFactory.StartNew(() => ShuffleTeamMembers(teamMemebers.ToArray()))
                    .ContinueWith(a => shuffledTeamMembers = a.Result),
                taskFactory.StartNew(() => InitiateRandomGroups(numberOfTeams))
                    .ContinueWith(a => teamGroups = a.Result)
            };


            taskFactory.ContinueWhenAll(allRunningTasks.ToArray(), delegate
            {
                var currentTeam = 0;
                foreach (var member in shuffledTeamMembers)
                {
                    teamGroups[currentTeam].Memebers.Add(member);

                    if (currentTeam < numberOfTeams - 1)
                    {
                        currentTeam++;
                    }
                    else
                    {
                        currentTeam = 0;
                    }
                }
            }).Wait();
            return teamGroups;
        }

        private IEnumerable<string> ShuffleTeamMembers(string[] teamMemebers)
        {
            var shuffledTeamMembers = new List<string>();

            var randomNameLocation = GetAListOfRandomNumberInRandom(0, teamMemebers.Length, teamMemebers.Length);
            foreach (var nameIndex in randomNameLocation)
            {
                shuffledTeamMembers.Add(teamMemebers[nameIndex]);
            }
            return shuffledTeamMembers;
        }

        private List<TeamGroups> InitiateRandomGroups(int numberOfTeams)
        {
            var randomGroups = new List<TeamGroups>();
            var randomTeamNameLocation = GetAListOfRandomNumberInRandom(0, _teamNames.Length, numberOfTeams);
            foreach (var teamNameIndex in randomTeamNameLocation)
            {
                randomGroups.Add(new TeamGroups() { Memebers = new List<string>(), TeamName = _teamNames[teamNameIndex] });
            }
            return randomGroups;
        }


        private static IEnumerable<int> GetAListOfRandomNumberInRandom(int lowest, int largest, int sizeOfCollection)
        {
            var numbers = new HashSet<int>();
            for (int i = 0; i < sizeOfCollection; i++)
            {
                numbers.Add(FindANewRandomNumber(lowest, largest, numbers));
            }
            return numbers.ToArray();
        }

        private static int FindANewRandomNumber(int lowest, int largest, HashSet<int> numbers)
        {
            var rnd = new Random();
            while (true)
            {
                var randomNumber = rnd.Next(lowest, largest);
                if (!numbers.Contains(randomNumber))
                {
                    return randomNumber;
                }
            }
        }

        private static IEnumerable<string> GetAListOfTeams()
        {
            return new[] { "The Salty Pretzels",
                "Fried Containers",
                "Shaved Monitors",
                "Jalapeno Hotties",
                "Tiquila Mockingbirds",
                "Prawn Stars",
                "Pickeled Sponges",
                "Coocked Chickens",
                "Caramlised Typhoons" };
        }

        private static IEnumerable<string> GetAListOfTeamsOld()
        {
            return new[] { "HOUSE STARK",
                "HOUSE LANNISTER",
                "HOUSE BARATHEON",
                "HOUSE TARGARYEN",
                "HOUSE GREYJOY",
                "HOUSE ARRYN",
                "HOUSE MARTELL",
                "HOUSE TULLY",
                "HOUSE TYRELL" };
        }
    }

    public class TeamGroups
    {
        public List<string> Memebers { get; set; }
        public string TeamName { get; set; }
    }
}
