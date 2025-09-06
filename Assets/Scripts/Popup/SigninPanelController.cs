using UnityEngine;
using TMPro;

public struct SigninData
{
    public string username;
    public string password;
}

public struct SigninResult
{
    public int result;
}

public class SigninPanelController : PanelController
{
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;

    public void Show()
    {
        base.Show();
    }
    
    public void OnClickConfirmButton()
    {
        string username = usernameInputField.text;
        string password = passwordInputField.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            // TODO: 누락된 값을 입력하도록 요청
            return;
        }

        var signinData = new SigninData();
        signinData.username = username;
        signinData.password = password;
        
        // Signin 함수로 Username/Password 전달하면서 로그인 요청
        StartCoroutine(NetworkManager.Instance.Signin(signinData,
            () =>
            {
                Hide();
            }, (result) =>
            {
                if (result == 0)
                {
                    GameManager.Instance.OpenConfirmPanel("유저네임이 유효하지 않습니다.",
                        () =>
                        {
                            
                        });
                }
                else if (result == 1)
                {
                    
                }
            }));
    }
}
