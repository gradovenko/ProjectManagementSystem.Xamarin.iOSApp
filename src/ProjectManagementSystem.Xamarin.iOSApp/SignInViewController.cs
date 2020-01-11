using System;
using Foundation;
using UIKit;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagementSystem.Xamarin.Infrastructure.AuthenticationApi;
using ProjectManagementSystem.Xamarin.Domain.Authentication;
using System.Threading.Tasks;
using System.Threading;

namespace ProjectManagementSystem.Xamarin.iOSApp
{
    public partial class SignInViewController : UIViewController, IDisposable
    {
        private readonly IServiceScope _serviceScope;
        protected IServiceProvider ServiceProvider { get; }
        private readonly IAuthenticationService _authenticationService;

        public SignInViewController(IntPtr handle) : base(handle)
        {
            _serviceScope = AppDelegate.ServiceProvider.CreateScope();
            ServiceProvider = _serviceScope.ServiceProvider;
            _authenticationService = ServiceProvider.GetService<IAuthenticationService>();
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SignInButton.TouchUpInside += SignInButton_TouchUpInside;

            // Perform any additional setup after loading the view, typically from a nib.
        }

        private async void SignInButton_TouchUpInside(object sender, EventArgs e)
        {
            try
            {
                await _authenticationService.AuthenticationByPassword(EmailTextField.Text, PasswordTextField.Text, CancellationToken.None);
            }
            catch (Exception exception)
            {
                //Create Alert
                var okAlertController = UIAlertController.Create("Alert", exception.Message, UIAlertControllerStyle.Alert);

                //Add Action
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                // Present Alert
                ShowViewController(okAlertController, null);
            }
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            // if (segue.Identifier == "SignInSegue")
            // {
            //     var destinationViewController = segue.DestinationViewController as TestController;
            //     destinationViewController.email = EmailTextField.Text;
            //     destinationViewController.password = PasswordTextField.Text;
            // }
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