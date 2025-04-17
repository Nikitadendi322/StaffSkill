namespace StaffSkill.Core.Model
{
    public class Skill
    {
        public string Name { get; set; }
        public byte Level { get; set; } // 1-10
        public long PersonId { get; set; }
        public Person Person { get; set; }
    }
}
