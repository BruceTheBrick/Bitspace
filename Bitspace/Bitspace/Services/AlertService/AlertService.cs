using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Forms;

namespace Bitspace.Services
{
    public class AlertService : IAlertService
    {
        public async Task<bool> Snackbar(string message)
        {
            var options = new SnackBarOptions { MessageOptions = { Message = message } };
            return await Application.Current.MainPage.DisplaySnackBarAsync(options);
        }

        public async Task<bool> Snackbar(string message, IEnumerable<Func<Task>> actions)
        {
            var options = new SnackBarOptions
            {
                MessageOptions =
                {
                    Message = message,
                },
                Actions = MakeActionOptions(actions),
            };
            return await Application.Current.MainPage.DisplaySnackBarAsync(options);
        }

        public async Task Toast(string message)
        {
            await Application.Current.MainPage.DisplayToastAsync(message);
        }

        public async Task Toast(string message, int milliseconds)
        {
            await Application.Current.MainPage.DisplayToastAsync(message, milliseconds);
        }

        private IEnumerable<SnackBarActionOptions> MakeActionOptions(IEnumerable<Func<Task>> actions)
        {
            var actionOptionsList = new List<SnackBarActionOptions>();
            foreach (var action in actions)
            {
                actionOptionsList.Add(new SnackBarActionOptions
                {
                    Action = action,
                });
            }

            return actionOptionsList;
        }
    }
}