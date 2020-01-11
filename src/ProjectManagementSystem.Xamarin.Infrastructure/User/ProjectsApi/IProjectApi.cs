using System.Threading.Tasks;
using ProjectManagementSystem.Xamarin.Domain.Pagination;
using Refit;

namespace ProjectManagementSystem.Xamarin.Infrastructure.User.ProjectsApi
{
    public interface IProjectApi
    {
        [Get("/projects")]
        Task<Page<ProjectListItemView>> GetProjectList([Header("Authorization")]string token);
    }
}
