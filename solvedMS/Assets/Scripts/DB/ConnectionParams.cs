public static class ConnectionParams {
    private static string server = "127.0.0.1";
    private static string db = "solvedms";
    private static string uid = "root";
    private static string pwd = "k42993897";

    public static string getConnectionSql()
        => string.Format("server={0};uid={1};pwd={2};database={3};charset=utf8 ;", server, uid, pwd, db);
}
