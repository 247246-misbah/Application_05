using System;

namespace Application_05.Services
{
    public class AuthenticationStateService
    {
        public bool IsAuthenticated { get; private set; } = false;
        public event Action? OnChange;

        public void LogIn()
        {
            if (!IsAuthenticated)
            {
                IsAuthenticated = true;
                NotifyStateChanged();
            }
        }

        public void LogOut()
        {
            if (IsAuthenticated)
            {
                IsAuthenticated = false;
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}