namespace SeuApp.Models
{
    public class Group
    {
        public string Name { get; set; }
        public List<Group> Subgroups { get; set; }

        public Group(string name)
        {
            Name = name;
            Subgroups = new List<Group>();
        }

        public void AddSubgroup(Group subgroup)
        {
            Subgroups.Add(subgroup);
        }
    }
}