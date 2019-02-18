using log4net;
using Microsoft.AspNet.Identity;
using MvcMusicStore.PerformanceCounters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcMusicStore
{
    public class MvcApplication : HttpApplication
    {

        ILog logger = LogManager.GetLogger(typeof(MvcApplication));

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            if (!PerformanceCounterCategory.Exists(PerformanceCounterConstants.LogCategoryName))
            {
                var counterCreationDataCollection = new CounterCreationDataCollection();
                var loginCounter = new CounterCreationData()
                {
                    CounterName = PerformanceCounterConstants.LoginCounter,
                    CounterType = PerformanceCounterType.NumberOfItems32
                };
                counterCreationDataCollection.Add(loginCounter);

                var logoutCounter = new CounterCreationData()
                {
                    CounterName = PerformanceCounterConstants.LogoutCounter,
                    CounterType = PerformanceCounterType.NumberOfItems32
                };
                counterCreationDataCollection.Add(logoutCounter);

                var homeVisitCounter = new CounterCreationData()
                {
                    CounterName = PerformanceCounterConstants.HomePageVisitCounter,
                    CounterType = PerformanceCounterType.NumberOfItems32
                };
                counterCreationDataCollection.Add(homeVisitCounter);

                try
                {
                    PerformanceCounterCategory.Create(
                       PerformanceCounterConstants.LogCategoryName, "Custom counter for loging", PerformanceCounterCategoryType.MultiInstance, counterCreationDataCollection);
                }
                catch (UnauthorizedAccessException)
                {
                }
            }

            CreatePerformanceCounterInstances();

            log4net.Config.XmlConfigurator.Configure();

            logger.Info("Starting the application...");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            HttpException httpException = exception as HttpException;
            var log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Fatal($"The error with the {httpException.GetHttpCode()} code occured: {exception.Message}");
        }

        public void CreatePerformanceCounterInstances()
        {
            using (var logInCounetr = new PerformanceCounter(PerformanceCounterConstants.LogCategoryName, PerformanceCounterConstants.LoginCounter, PerformanceCounterConstants.InstanceName, false))
            {
                logInCounetr.RawValue = 0;
            }

            using (var logOutCounetr = new PerformanceCounter(PerformanceCounterConstants.LogCategoryName, PerformanceCounterConstants.LogoutCounter, PerformanceCounterConstants.InstanceName, false))
            {
                logOutCounetr.RawValue = 0;
            }

            using (var homeVisitCounter = new PerformanceCounter(PerformanceCounterConstants.LogCategoryName, PerformanceCounterConstants.HomePageVisitCounter, PerformanceCounterConstants.InstanceName, false))
            {
                homeVisitCounter.RawValue = 0;
            }
        }
    }
}
