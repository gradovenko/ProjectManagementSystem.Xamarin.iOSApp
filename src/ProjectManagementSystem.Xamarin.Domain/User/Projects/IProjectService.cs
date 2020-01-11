using System;
using System.Threading;
using System.Threading.Tasks;
using ProjectManagementSystem.Xamarin.Domain.Pagination;

namespace ProjectManagementSystem.Xamarin.Domain.User.Projects
{
    public interface IProjectService
    {
        Task<Page<Project>> GetProjectList(CancellationToken cancellationToken);
    }
}
