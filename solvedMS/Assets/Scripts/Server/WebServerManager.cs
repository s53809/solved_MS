using System.Text;
using System;
using UnityEngine.Networking;
using UnityEngine;
using System.Collections;
using Newtonsoft.Json;

public class WebServerManager : MonoBehaviour
{
    private String m_ip;
    private Int32 m_port;
    private Int32 m_nowProcessingRequestID = -1;
    private Int32 m_lastProcessedRequestID = 10000;

    private static WebServerManager m_ins;

    public static WebServerManager ins
    {
        get
        {
            return m_ins;
        }
    }

    public static void Init(String pIP, Int32 pPort)
    {
        GameObject go = new GameObject("WebServerManager");
        m_ins = go.AddComponent<WebServerManager>();

        m_ins.m_ip = pIP;
        m_ins.m_port = pPort;
    }

    public void Post<TRequest, TResponse>(
        TRequest pRequest,
        String pRoute,
        Action<TResponse> pResponseCallback,
        Action pErrorCallback)
    {
        Int32 id = ++m_lastProcessedRequestID;
        StartCoroutine(SendPostRequest(pRequest, pRoute, pResponseCallback, pErrorCallback, id));
    }

    private IEnumerator SendPostRequest<TRequest, TResponse>(
        TRequest pRequest,
        String pRoute,
        Action<TResponse> pResponseCallback,
        Action pErrorCallback,
        Int32 pRequestID
        )
    {
        if (m_nowProcessingRequestID != -1)
            yield return new WaitUntil(() => m_lastProcessedRequestID == -1);

        m_nowProcessingRequestID = pRequestID;

        String requestToJson = JsonConvert.SerializeObject(pRequest);
        using (UnityWebRequest request = UnityWebRequest.PostWwwForm($"http://{m_ip}:{m_port}/{pRoute}", requestToJson))
        {
            Debug.Log($"Sending Request {pRequest}(POST) to {request.uri}");

            Byte[] byteToSend = Encoding.UTF8.GetBytes(requestToJson);

            request.uploadHandler = new UploadHandlerRaw(byteToSend);
            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            String responseData = request?.downloadHandler?.text;

            Debug.Log($"Received Reponse {responseData}(POST) from {request.uri}");

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                pErrorCallback?.Invoke();
            }
            else
            {
                try
                {
                    TResponse res = JsonConvert.DeserializeObject<TResponse>(responseData);
                    pResponseCallback.Invoke(res);
                }
                catch (Exception ex)
                {
                    Debug.LogError(responseData);
                    Debug.LogError(ex);

                    pErrorCallback?.Invoke();
                }
            }

            request.uploadHandler.Dispose();
            request.downloadHandler.Dispose();

            m_nowProcessingRequestID = -1;
        }
    }
}