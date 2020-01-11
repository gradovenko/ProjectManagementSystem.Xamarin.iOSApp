using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ProjectManagementSystem.Xamarin.Domain.Pagination;
using ProjectManagementSystem.Xamarin.Domain.User.Projects;
using ProjectManagementSystem.Xamarin.Infrastructure.TokenStores;
using ProjectManagementSystem.Xamarin.Infrastructure.User.ProjectsApi;

namespace ProjectManagementSystem.Xamarin.Infrastructure.User.Projects
{
    public sealed class ProjectService : IProjectService
    {
        private readonly IProjectApi _projectApi;
        private readonly TokenStore _tokenStore;

        public ProjectService(IProjectApi projectApi, TokenStore tokenStore)
        {
            _projectApi = projectApi;
            _tokenStore = tokenStore;
        }

        public async Task<Page<Project>> GetProjectList(CancellationToken cancellationToken)
        {
            var projectListView = await _projectApi.GetProjectList(_tokenStore.Token.AccessToken);

            return new Page<Project>
            {
                Total = projectListView.Total,
                Offset = projectListView.Total,
                Limit = projectListView.Total,
                Items = projectListView.Items.Select(p => new Project(p.Id, p.Name))
            };
        }
    }
}
