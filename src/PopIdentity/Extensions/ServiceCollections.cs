﻿using Microsoft.Extensions.DependencyInjection;
using PopIdentity.Configuration;
using PopIdentity.Providers.Facebook;
using PopIdentity.Providers.Google;

namespace PopIdentity.Extensions
{
	public static class ServiceCollections
	{
		public static IServiceCollection AddPopIdentity(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<ILoginLinkFactory, LoginLinkFactory>();
			serviceCollection.AddTransient<IStateHashingService, StateHashingService>();

			serviceCollection.AddTransient<IPopIdentityConfig, PopIdentityConfig>();

			serviceCollection.AddTransient<IFacebookCallbackProcessor, FacebookCallbackProcessor>();

			serviceCollection.AddTransient<IGoogleCallbackProcessor, GoogleCallbackProcessor>();

			return serviceCollection;
		}
	}
}