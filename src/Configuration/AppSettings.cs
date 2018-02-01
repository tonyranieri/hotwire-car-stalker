namespace HotwireCarStalker.Configuration
{
    public class AppSettings
    {
        public AppSettings()
        {
            HotWireApi = new HotWireApi();
            SearchCriteria = new SearchCriteria();
            Email = new Email();
        }

        public HotWireApi HotWireApi { get; set; }
        public SearchCriteria SearchCriteria { get; set; }
        public Email Email { get; set; }
    }
}