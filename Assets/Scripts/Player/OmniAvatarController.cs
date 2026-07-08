using UnityEngine;

public class OmniAvatarController : MonoBehaviour
{
    public string avatarName = "Player Avatar";

    private string avatarStyle;

    private void Start()
    {
        InitializeAvatar();
    }

    private void InitializeAvatar()
    {
        avatarStyle = "Default";

        Debug.Log(
            avatarName + " initialized"
        );
    }

    public void ChangeStyle(string style)
    {
        avatarStyle = style;

        Debug.Log(
            "Avatar style changed: " + style
        );
    }

    public string GetStyle()
    {
        return avatarStyle;
    }
}