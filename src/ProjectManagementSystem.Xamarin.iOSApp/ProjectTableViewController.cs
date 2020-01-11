using System;
using Foundation;
using UIKit;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagementSystem.Xamarin.Infrastructure.AuthenticationApi;
using ProjectManagementSystem.Xamarin.Domain.Authentication;
using System.Threading.Tasks;
using System.Threading;
using ProjectManagementSystem.Xamarin.Domain.User.Projects;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagementSystem.Xamarin.iOSApp
{
    public partial class ProjectTableViewController : UITableViewController, IDisposable
    {
        private readonly IServiceScope _serviceScope;
        protected IServiceProvider ServiceProvider { get; }
        private readonly IProjectService _projectService;
        private IEnumerable<Project> _projects;

        public ProjectTableViewController(IntPtr handle) : base(handle)
        {
            _serviceScope = AppDelegate.ServiceProvider.CreateScope();
            ServiceProvider = _serviceScope.ServiceProvider;
            _projectService = ServiceProvider.GetService<IProjectService>();
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var projectListView = await _projectService.GetProjectList(CancellationToken.None);

            _projects = projectListView.Items;

            ProjectTableView.ReloadData();

            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _projects.Count();
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("ProjectTableViewCell") as ProjectTableViewCell;

            cell.ProjectNameLabel.Text = 1;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public new void Dispose()
        {
            _serviceScope?.Dispose();
        }
    }
}