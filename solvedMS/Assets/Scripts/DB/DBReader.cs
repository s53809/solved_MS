using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;

public class DBReader : MonoBehaviour {
    private MySqlConnection p_conn = new MySqlConnection(ConnectionParams.getConnectionSql());
}
