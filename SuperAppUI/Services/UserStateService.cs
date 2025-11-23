namespace SuperApp_UI.Services
{
    public class UserStateService
    {
        private string _activeSubUserName;

        public string ActiveSubUserName
        {
            get => _activeSubUserName;
            set
            {
                _activeSubUserName = value;
                NotifyStateChanged();
            }
        }

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
