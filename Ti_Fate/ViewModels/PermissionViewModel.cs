namespace Ti_Fate.ViewModels
{
    public class PermissionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsWelfare { get; set; }
        public bool IsClubs { get; set; }
        public bool IsMeetUp { get; set; }
        public bool IsExternal { get; set; }
        public bool IsImportant { get; set; }
        public bool IsStore { get; set; }
    };
}