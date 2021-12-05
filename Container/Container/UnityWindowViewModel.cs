namespace Container
{
    public class UnityWindowViewModel
    {
        private static UnityWindowViewModel _instance;
        public static UnityWindowViewModel Instance => _instance ?? (_instance = new UnityWindowViewModel());

        public WPF_UserControl myUserControl;

        public UnityWindowViewModel()
        {
            myUserControl = new WPF_UserControl();
        }
    }
}