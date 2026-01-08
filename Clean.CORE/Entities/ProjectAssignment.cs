namespace Clean.CORE.Entities
{
    public class ProjectAssignment
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeRoleInProject { get; set; }
    }
}



