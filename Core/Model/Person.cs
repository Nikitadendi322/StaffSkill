namespace StaffSkill.Core.Model
{
    public class Person
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string DisplayName { get; set; }
        public List<Skill>? Skills { get; set; } = new();
    }
}
