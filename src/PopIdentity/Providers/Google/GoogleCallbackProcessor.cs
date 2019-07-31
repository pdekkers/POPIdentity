﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PopIdentity.Configuration;
using PopIdentity.Providers.OAuth2;

namespace PopIdentity.Providers.Google
{
	public interface IGoogleCallbackProcessor
	{
		Task<CallbackResult> VerifyCallback(string redirectUri);
		Task<CallbackResult> VerifyCallback(string redirectUri, string clientID, string clientSecret);
	}

	public class GoogleCallbackProcessor : OAuth2Base, IGoogleCallbackProcessor
	{
		private readonly IPopIdentityConfig _popIdentityConfig;

		public GoogleCallbackProcessor(IPopIdentityConfig popIdentityConfig, IStateHashingService stateHashingService, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor, stateHashingService)
		{
			_popIdentityConfig = popIdentityConfig;
		}

		public override string AccessTokenUrl => GoogleEndpoints.OAuthAccessTokenUrl;

        public async Task<CallbackResult> VerifyCallback(string redirectUri)
		{
			var clientID = _popIdentityConfig.GoogleClientID;
			var clientSecret = _popIdentityConfig.GoogleClientSecret;
			return await VerifyCallback(redirectUri, clientID, clientSecret);
		}
	}
}