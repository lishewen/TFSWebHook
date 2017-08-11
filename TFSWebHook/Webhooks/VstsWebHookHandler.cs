using Microsoft.AspNet.WebHooks;
using Microsoft.AspNet.WebHooks.Payloads;
using Newtonsoft.Json.Linq;
using Senparc.Weixin.Work.AdvancedAPIs;
using Senparc.Weixin.Work.Containers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TFSWebHook.Webhooks
{
    public class VstsWebHookHandler : VstsWebHookHandlerBase
    {
        protected string CorpId = ConfigurationManager.AppSettings["CorpId"];
        protected string Secret = ConfigurationManager.AppSettings["Secret"];
        public static string AccessToken;
        public static string AgentId = ConfigurationManager.AppSettings["AgentId"];
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
            try
            {
                MassApi.SendText(AccessToken, AgentId, $"{payload.Message.Text} At {payload.CreatedDate.ToString()}。\r\n DetailMessage：{payload.DetailedMessage.Text}", "@all");
            }
            catch
            {
                MassApi.SendText(AccessToken, AgentId, $"{payload.Message.Text} At {payload.CreatedDate.ToString()}。\r\n DetailMessage：内容太多已省略！", "@all");
            }
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
            try
            {
                MassApi.SendText(AccessToken, AgentId, $"{payload.Message.Text} At {payload.CreatedDate.ToString()}。\r\n DetailMessage：{payload.DetailedMessage.Text}", "@all");
            }
            catch
            {
                MassApi.SendText(AccessToken, AgentId, $"{payload.Message.Text} At {payload.CreatedDate.ToString()}。\r\n DetailMessage：内容太多已省略！", "@all");
            }
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