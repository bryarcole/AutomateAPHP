namespace TFSCommon.Repository
{
    class BaseRepository
    {
        private static string _baseConnection;

        public BaseRepository()
        {
            _baseConnection = "Data Source=./../TFSReporting.db";
        }
    }
}
