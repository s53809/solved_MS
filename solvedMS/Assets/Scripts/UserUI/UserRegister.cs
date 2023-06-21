using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using MySql.Data.MySqlClient;

public class UserRegister : MonoBehaviour {
    private string p_CurName = null;
    private string p_CurProfile = null;
    private Text p_CurProfileViewer;
    private TMP_InputField p_InputField;
    [SerializeField] private int testID = 10001;

    private void Awake() {
        p_CurProfileViewer = transform.GetChild(4).GetComponent<Text>();
        p_InputField = transform.GetChild(0).GetChild(0).GetComponent<TMP_InputField>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            p_InputField.text = "";
            p_CurProfileViewer.text = "현재 프로필 : ";
            p_CurName = null;
            p_CurProfile = null;
            gameObject.SetActive(false);
        }
    }

    private void OnEnable() {
        transform.localScale = new Vector3(0, 0, 0);
        transform.DOScale(new Vector3(1, 1, 1), 0.2f);
    }

    public void OnProfileButtonDown(Button curButton) {
        p_CurProfile = curButton.gameObject.name;
        p_CurProfileViewer.text = $"현재 프로필 : {p_CurProfile}";
    }

    public void OnRegisterButtonDown() {
        if (p_CurProfile == null || p_CurName == null) return;
        try {
            using (MySqlConnection conn = new MySqlConnection(ConnectionParams.getConnectionSql())) {
                conn.Open();
                string sql = "insert into 'playerprofile' value('" + testID.ToString() + "', '" + p_CurName +
                             "', '" + p_CurProfile + "');";

                MySqlCommand inscmd = new MySqlCommand(sql, conn);

                int rowUpdated = inscmd.ExecuteNonQuery();
                if (rowUpdated > 0) Debug.Log(p_CurName + " 학생의 정보 입력 성공!");
                else Debug.Log("정보 입력 실패");
            }
        }
        catch (Exception ex) {
            Debug.LogError(ex.Message);
        }
        
        gameObject.SetActive(false);
    }

    public void OnNameInput() {
        p_CurName = p_InputField.text;
        Debug.Log(p_CurName);
    }
}
