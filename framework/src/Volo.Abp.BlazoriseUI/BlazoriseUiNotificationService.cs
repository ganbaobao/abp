﻿using System;
using System.Threading.Tasks;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.Localization;
using Volo.Abp.AspNetCore.Components.WebAssembly;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.BlazoriseUI
{
    [Dependency(ReplaceServices = true)]
    public class BlazoriseUiNotificationService : IUiNotificationService, IScopedDependency
    {
        /// <summary>
        /// An event raised after the notification is received.
        /// </summary>
        public event EventHandler<UiNotificationEventArgs> NotificationReceived;

        private readonly IStringLocalizer<AbpUiResource> localizer;

        public BlazoriseUiNotificationService(
            IStringLocalizer<AbpUiResource> localizer)
        {
            this.localizer = localizer;
        }

        public Task Info(string message, string title = null, Action<UiNotificationOptions> options = null)
        {
            var uiNotificationOptions = CreateDefaultOptions();
            options?.Invoke(uiNotificationOptions);

            NotificationReceived?.Invoke(this, new UiNotificationEventArgs(UiNotificationType.Info, message, title, uiNotificationOptions));

            return Task.CompletedTask;
        }

        public Task Success(string message, string title = null, Action<UiNotificationOptions> options = null)
        {
            var uiNotificationOptions = CreateDefaultOptions();
            options?.Invoke(uiNotificationOptions);

            NotificationReceived?.Invoke(this, new UiNotificationEventArgs(UiNotificationType.Success, message, title, uiNotificationOptions));

            return Task.CompletedTask;
        }

        public Task Warn(string message, string title = null, Action<UiNotificationOptions> options = null)
        {
            var uiNotificationOptions = CreateDefaultOptions();
            options?.Invoke(uiNotificationOptions);

            NotificationReceived?.Invoke(this, new UiNotificationEventArgs(UiNotificationType.Warning, message, title, uiNotificationOptions));

            return Task.CompletedTask;
        }

        public Task Error(string message, string title = null, Action<UiNotificationOptions> options = null)
        {
            var uiNotificationOptions = CreateDefaultOptions();
            options?.Invoke(uiNotificationOptions);

            NotificationReceived?.Invoke(this, new UiNotificationEventArgs(UiNotificationType.Error, message, title, uiNotificationOptions));

            return Task.CompletedTask;
        }

        protected virtual UiNotificationOptions CreateDefaultOptions()
        {
            return new UiNotificationOptions
            {
            };
        }
    }
}
