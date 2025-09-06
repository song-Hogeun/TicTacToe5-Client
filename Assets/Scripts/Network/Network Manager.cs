using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class NetworkManager : Singleton<NetworkManager>
{
    // 로그인
    public IEnumerator Signin(SigninData signinData, Action success, Action<int> failure)
    {
        string jsonString = JsonUtility.ToJson(signinData);
        byte[] byteRaw = System.Text.Encoding.UTF8.GetBytes(jsonString);

        using (UnityWebRequest www = new UnityWebRequest(Constants.ServerURL + "/users/signin",
                   UnityWebRequest.kHttpVerbPOST))
        {
            www.uploadHandler = new UploadHandlerRaw(byteRaw);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError ||
                www.result == UnityWebRequest.Result.ProtocolError)
            {
                // TODO: 서버 연결 오류에 대해 알림
            }
            else
            {
                var resultString = www.downloadHandler.text;
                var result = JsonUtility.FromJson<SigninResult>(resultString);

                if (result.result == 0)
                {
                    GameManager.Instance.OpenConfirmPanel("유저네임이 유효하지 않습니다.", 
                        () =>
                    {
                        failure?.Invoke(result.result);
                    });
                }
                else if(result.result == 1)
                {
                    GameManager.Instance.OpenConfirmPanel("패스워드가 유효하지 않습니다.", 
                        () =>
                        {
                            failure?.Invoke(result.result);
                        });
                }
                else if (result.result == 2)
                {
                    GameManager.Instance.OpenConfirmPanel("로그인에 성공하였습니다.", 
                        () =>
                        {
                            success?.Invoke();
                        });
                }
            }
        };
    }
    
    protected override void OnSceneLoad(Scene scene, LoadSceneMode mode) { }
}
