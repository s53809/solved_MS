public static class ConnectionParams {
    private static string server = "localhost";
    private static string db = "Solved_MS";
    private static string uid = "root";
    private static string pwd = "k42993897";

    public static string getConnectionSql() 
        => "Server=" + server + ";Database=" + db + ";Uid=" + uid + ";pwd=" + pwd;
}