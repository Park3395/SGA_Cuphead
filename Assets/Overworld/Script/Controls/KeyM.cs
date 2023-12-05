using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyAction { Shot, ExShot, SwitchWeapon, Jump, Dash,Up,Down,Left,Right, KEYCOUNT }
public static class KeySetting { public static Dictionary<KeyAction, KeyCode> keys = new Dictionary<KeyAction, KeyCode>(); }
public class KeyM : MonoBehaviour
{
    KeyCode[] defaultKeys = new KeyCode[] { KeyCode.Z, KeyCode.X, KeyCode.Tab, KeyCode.LeftAlt,
        KeyCode.Space, KeyCode.W, KeyCode.S, KeyCode.A,KeyCode.D };
    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < (int)KeyAction.KEYCOUNT; i++)
        {
            KeySetting.keys.Add((KeyAction)i, defaultKeys[i]);
        }
    }
    private void OnGUI()
    {
        Event keyEvent = Event.current;
        if (keyEvent.isKey)
        {
            KeySetting.keys[(KeyAction)key] = keyEvent.keyCode;
            key = -1;
        }
    }
    int key = -1;
    public void ChangeKey(int num)
    {
        key = num;
    }
}
