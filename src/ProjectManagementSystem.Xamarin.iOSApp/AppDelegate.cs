using System;
using Foundation;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagementSystem.Xamarin.Domain.Authentication;
using ProjectManagementSystem.Xamarin.Infrastructure.Authentication;
using ProjectManagementSystem.Xamarin.Infrastructure.AuthenticationApi;
using ProjectManagementSystem.Xamarin.Infrastructure.TokenStores;
using Refit;
using UIKit;

namespace ProjectManagementSystem.Xamarin.iOSApp
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIResponder, IUIApplicationDelegate
    {
        private static ServiceProvider _serviceProvider;
        public static IServiceProvider ServiceProvider => _serviceProvider;

        [Export("window")]
        public UIWindow Window { get; set; }

        [Export("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();

            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method
            return true;
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            #region Authentication

            serviceCollection.AddScoped(sp => RestService.For<IAuthenticationApi>("http://85.192.132.112:57264"));
            serviceCollection.AddSingleton<TokenStore>();
            serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();

            #endregion
        }

        // UISceneSession Lifecycle

        [Export("application:configurationForConnectingSceneSession:options:")]
        public UISceneConfiguration GetConfiguration(UIApplication application, UISceneSession connectingSceneSession, UISceneConnectionOptions options)
        {
            // Called when a new scene session is being created.
            // Use this method to select a configuration to create the new scene with.
            return UISceneConfiguration.Create("Default Configuration", connectingSceneSession.Role);
        }

        [Export("application:didDiscardSceneSessions:")]
        public void DidDiscardSceneSessions(UIApplication application, NSSet<UISceneSession> sceneSessions)
        {
            // Called when the user discards a scene session.
            // If any sessions were discarded while the application was not running, this will be called shortly after `FinishedLaunching`.
            // Use this method to release any resources that were specific to the discarded scenes, as they will not return.
        }
    }
}

