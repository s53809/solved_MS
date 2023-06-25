using UnityEngine;
using TMPro;
using System;
using UnityEngine.Android;

public class PlusProblem : MonoBehaviour
{
    private string m_problemName;
    private int m_problemIndex = 0;
    private int m_problemTierID = 0;

    private TMP_InputField m_inputField;
    private AlgorithmManager m_algorithm;
    public void Start()
    {
        m_inputField = transform.GetChild(1).GetComponent<TMP_InputField>();
        m_algorithm = transform.GetChild(3).GetComponent<AlgorithmManager>();
    }

    public void SetProblemTier(int problemTier)
    {
        m_problemTierID = problemTier + 10000;
        Debug.Log($"tier ID {m_problemTierID}");
    }

    public void OnInputProblemData()
    {
        try
        {
            m_problemName = m_inputField.text.Split(' ')[1];
            m_problemIndex = int.Parse(m_inputField.text.Split(' ')[0]);
            Debug.Log($"m_problem {m_problemTierID} / m_problemIndex {m_problemIndex}");
        }
        catch (Exception ex)
        {
            Debug.Log("데이터 입력이 잘못되었을 수 있습니다. \"문제번호 문제이름\" 양식을 꼭 지켜주세요");
            Debug.Log(ex.Message);
        }
    }

    public void OnInputProblem()
    {
        if (m_algorithm.AlgorithmSort == 0 || 
            m_problemName == null || 
            m_problemTierID == 0 || 
            m_problemIndex == 0) return;

        probleminfo pack = new probleminfo();
        pack.playerID = ServerSystem.Instance.selectedUser.playerID;
        pack.problemInfoID = m_problemIndex;
        pack.problemTierID = m_problemTierID;
        pack.algorithm = m_algorithm.AlgorithmSort;
        pack.problemName = m_problemName;

        WebServerManager.ins.Post<probleminfo, probleminfo>(pack, "API/problemInput/", response => {
            if (response.is_success)
            {
                Debug.Log($"{response.problemName} 입력 완료");
                gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("PlusProblem Responce Error!");
            }
        }, () => { Debug.LogError("PlusProblem Network Error!"); });
    }

    public void OnExitButtonDown()
    {
        gameObject.SetActive(false);
    }

}