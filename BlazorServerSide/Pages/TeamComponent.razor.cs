using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerSide.Pages
{
    public partial class TeamComponent
    {
        [Parameter]
        public int Id { get; set; }

        private Team team;
        private List<Team> teams;
        private IEnumerable<Member> members;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            teams = new List<Team>();
            teams.Add(new Team { Id = 1, Name = "Red", Region = "Region One" });
            teams.Add(new Team { Id = 2, Name = "Blue", Region = "Region Two" });
            teams.Add(new Team { Id = 3, Name = "Green", Region = "Region Three" });

            var allMembers = new List<Member>();
            allMembers.Add(new Member { Id = 1, Name = "John", Age = 20, TeamId = 3 });
            allMembers.Add(new Member { Id = 2, Name = "Mike", Age = 24, TeamId = 1 });
            allMembers.Add(new Member { Id = 3, Name = "Nick", Age = 25, TeamId = 2 });
            allMembers.Add(new Member { Id = 4, Name = "Ross", Age = 36, TeamId = 3 });
            allMembers.Add(new Member { Id = 5, Name = "Ryan", Age = 19, TeamId = 2 });
            allMembers.Add(new Member { Id = 6, Name = "Brid", Age = 29, TeamId = 1 });

            team = teams.FirstOrDefault(x => x.Id == this.Id);
            members = allMembers.Where(x => x.TeamId == this.Id);
        }

        public class Team
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Region { get; set; }
        }

        public class Member
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public int TeamId { get; set; }
        }
    }
}
