using UnityEngine;

public class OmniAvatarSystem : MonoBehaviour
{
    public string avatarName;
    public string avatarStyle;

    public void CreateAvatar(string name)
    {
        avatarName = name;

        Debug.Log(
        "Avatar creado: " + avatarName
        );
    }

    public void ChangeStyle(string style)
    {
        avatarStyle = style;

        Debug.Log(
        "Estilo cambiado: " + avatarStyle
        );
    }
}