public static class ConnectionParams {
    private static string server = "127.0.0.1";
    private static string db = "solvedms";
    private static string uid = "root";
    private static string pwd = "qwer1234";

    public static string getConnectionSql()
        => string.Format("Server={0};Uid={1};pwd={2};Database={3};SslMode=none;", server, uid, pwd, db);
}
