namespace ProjectManagementSystem.Xamarin.Domain.User.Projects
{
    public sealed class Project
    {
        public string Id { get; }
        public string Name { get; }

        public Project(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
