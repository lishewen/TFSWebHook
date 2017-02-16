using Microsoft.AspNet.WebHooks;
using Microsoft.AspNet.WebHooks.Payloads;
using Newtonsoft.Json.Linq;
using Senparc.Weixin.QY.AdvancedAPIs;
using Senparc.Weixin.QY.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TFSWebHook.Webhooks
{
	public class VstsWebHookHandler : VstsWebHookHandlerBase
	{
		protected string Token = "lishewen";//对应微信后台设置的Token，建议设置地复杂一些
		protected string EncodingAESKey = "78FUjPzmKb9CWo3bTQfvPzWVWqYXbbNSqXgGDKzkzI7";
		public const string CorpId = "wx6c74c79d9de0e186";
		protected string Secret = "OUxcQTjKijn79qsELxXxOaG1sR-ZvLKkXHR0nE4mA-ijAIMkkkviO_eXk9F61vTi";
		public static string AccessToken;
		public static string AgentId = "10";
		public VstsWebHookHandler() : base()
		{
			AccessToken = AccessTokenContainer.TryGetToken(CorpId, Secret);
		}
		/// <summary>
		/// We use <see cref="VstsWebHookHandlerBase"/> so just have to override the methods we want to process WebHooks for.
		/// This one processes the <see cref="BuildCompletedPayload"/> WebHook.
		/// </summary>
		public override Task ExecuteAsync(WebHookHandlerContext context, BuildCompletedPayload payload)
		{
			return Task.FromResult(true);
		}

		/// <summary>
		/// We use <see cref="VstsWebHookHandlerBase"/> so just have to override the methods we want to process WebHooks for.
		/// This one processes the <see cref="TeamRoomMessagePostedPayload"/> WebHook.
		/// </summary>
		public override Task ExecuteAsync(WebHookHandlerContext context, TeamRoomMessagePostedPayload payload)
		{
			return Task.FromResult(true);
		}

		/// <summary>
		/// We use <see cref="VstsWebHookHandlerBase"/> so just have to override the methods we want to process WebHooks for.
		/// This one processes the <see cref="WorkItemCreatedPayload"/> WebHook.
		/// </summary>
		public override Task ExecuteAsync(WebHookHandlerContext context, WorkItemCreatedPayload payload)
		{
			return Task.FromResult(true);
		}

		/// <summary>
		/// We use <see cref="VstsWebHookHandlerBase"/> so just have to override the methods we want to process WebHooks for.
		/// This one processes the <see cref="WorkItemCommentedOnPayload"/> WebHook.
		/// </summary>
		public override Task ExecuteAsync(WebHookHandlerContext context, WorkItemCommentedOnPayload payload)
		{
			return Task.FromResult(true);
		}

		/// <summary>
		/// We use <see cref="VstsWebHookHandlerBase"/> so just have to override the methods we want to process WebHooks for.
		/// This one processes the <see cref="CodeCheckedInPayload"/> WebHook.
		/// </summary>
		public override Task ExecuteAsync(WebHookHandlerContext context, CodeCheckedInPayload payload)
		{
			MassApi.SendText(AccessToken, "@all", "", "", AgentId, $"{payload.Resource.CheckedInBy.DisplayName} 签入代码：{payload.Message.Text} At {payload.CreatedDate.ToString()}。\r\n DetailMessage：{payload.DetailedMessage.Text}");
			return Task.FromResult(true);
		}

		/// <summary>
		/// We use <see cref="VstsWebHookHandlerBase"/> so just have to override the methods we want to process WebHooks for.
		/// This one processes the <see cref="WorkItemDeletedPayload"/> WebHook.
		/// </summary>
		public override Task ExecuteAsync(WebHookHandlerContext context, WorkItemDeletedPayload payload)
		{
			return Task.FromResult(true);
		}

		/// <summary>
		/// We use <see cref="VstsWebHookHandlerBase"/> so just have to override the methods we want to process WebHooks for.
		/// This one processes the <see cref="WorkItemRestoredPayload"/> WebHook.
		/// </summary>
		public override Task ExecuteAsync(WebHookHandlerContext context, WorkItemRestoredPayload payload)
		{
			return Task.FromResult(true);
		}

		/// <summary>
		/// We use <see cref="VstsWebHookHandlerBase"/> so just have to override the methods we want to process WebHooks for.
		/// This one processes the <see cref="WorkItemUpdatedPayload"/> WebHook.
		/// </summary>
		public override Task ExecuteAsync(WebHookHandlerContext context, WorkItemUpdatedPayload payload)
		{
			return Task.FromResult(true);
		}

		public override Task ExecuteAsync(WebHookHandlerContext context, GitPushPayload payload)
		{
			MassApi.SendText(AccessToken, "@all", "", "", AgentId, $"{payload.Resource.PushedBy.DisplayName} 签入代码：{payload.Message.Text} At {payload.CreatedDate.ToString()}。\r\n DetailMessage：{payload.DetailedMessage.Text}");
			return Task.FromResult(true);
		}

		/// <summary>
		/// We use <see cref="VstsWebHookHandlerBase"/> so just have to override the methods we want to process WebHooks for.
		/// This one processes the payload for unknown <c>eventType</c>.
		/// </summary>
		public override Task ExecuteAsync(WebHookHandlerContext context, JObject payload)
		{
			return Task.FromResult(true);
		}

	}
}