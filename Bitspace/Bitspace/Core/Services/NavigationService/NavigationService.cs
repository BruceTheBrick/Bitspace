﻿using System.Threading.Tasks;
using Prism.Navigation;

namespace Bitspace.Core
{
    public class NavigationService : INavigationService
    {
        private readonly Prism.Navigation.INavigationService _navigationService;
        public NavigationService(Prism.Navigation.INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public Task<INavigationResult> NavigateAsync(string url)
        {
            return _navigationService.NavigateAsync(url, null, false, true);
        }

        public Task<INavigationResult> NavigateAsync(string url, INavigationParameters parameters)
        {
            return _navigationService.NavigateAsync(url, parameters, false, true);
        }

        public Task<INavigationResult> NavigateAsync(string url, bool useModalNavigation)
        {
            return _navigationService.NavigateAsync(url, null, useModalNavigation, true);
        }

        public Task<INavigationResult> NavigateAsync(string url, INavigationParameters parameters, bool useModalNavigation)
        {
            return _navigationService.NavigateAsync(url, parameters, useModalNavigation, false);
        }

        public Task<INavigationResult> GoBack()
        {
            return _navigationService.GoBackAsync();
        }

        public Task<INavigationResult> GoBack(INavigationParameters parameters)
        {
            return _navigationService.GoBackAsync(parameters);
        }
    }
}