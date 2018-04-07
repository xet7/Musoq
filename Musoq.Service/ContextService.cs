﻿using System;
using System.IO;
using System.ServiceProcess;
using Microsoft.Owin.Hosting;
using Musoq.Service.Client.Helpers;
using Musoq.Service.Environment;
using Environment = Musoq.Plugins.Environment;

namespace Musoq.Service
{
    public partial class ContextService : ServiceBase
    {
        private IDisposable _server;

        public ContextService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var env = new Plugins.Environment();

            env.SetValue(EnvironmentServiceHelper.PluginsFolderKey, ApplicationConfiguration.PluginsFolder);
            env.SetValue(EnvironmentServiceHelper.HttpServerAddressKey, ApplicationConfiguration.HttpServerAdress);
            env.SetValue(EnvironmentServiceHelper.ServerAddressKey, ApplicationConfiguration.ServerAddress);

            _server = WebApp.Start<ApiStartup>(ApplicationConfiguration.HttpServerAdress);
        }

        protected override void OnStop()
        {
            _server.Dispose();
        }

#if DEBUG
        public void Start(string[] args)
        {
            OnStart(args);
            Console.WriteLine("{1} started at {0}.", ApplicationConfiguration.ServerAddress, nameof(Musoq));
            //var api = new ApplicationFlowApi(ApplicationConfiguration.ServerAddress);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            OnStop();
            Console.WriteLine("Stopped");
        }
#endif
    }
}