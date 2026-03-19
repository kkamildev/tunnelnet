

using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;

namespace Tunnelnet.Utils.Managers;


public sealed partial class Input
{
    private KeyboardState _currentKeyboardState;
    private KeyboardState _previrousKeyboardState;
    public enum Controls {
        FORWARD = 0,
        BACKWARD = 1,
        LEFT = 2,
        RIGHT = 3,
        TARGET_TOP = 4,
        TARGET_DOWN = 5,
        TARGET_LEFT = 6,
        TARGET_RIGHT = 7,
        SHOOT = 8
    }

    private Dictionary<Controls, Keys> _controls;


    public Input()
    {
        _controls = new()
        {
            {Controls.FORWARD, Keys.W},
            {Controls.BACKWARD, Keys.S},
            {Controls.LEFT, Keys.A},
            {Controls.RIGHT, Keys.D},
            {Controls.SHOOT, Keys.Space},
            {Controls.TARGET_TOP, Keys.Up},
            {Controls.TARGET_DOWN, Keys.Down},
            {Controls.TARGET_LEFT, Keys.Left},
            {Controls.TARGET_RIGHT, Keys.Right}
        };
    }
    

    public void SetCurrentState()
    {
        _currentKeyboardState = Keyboard.GetState();
    }
    
    public void SetPrevirousState()
    {
        _previrousKeyboardState = _currentKeyboardState;
    }

    public bool CheckPressed(Keys key)
    {
        return _currentKeyboardState.IsKeyDown(key);
    }
    public bool CheckClicked(Keys key)
    {
        if(CheckPressed(key))
        {
            if(!_previrousKeyboardState.GetPressedKeys().Contains(key))
            {
                return true;
            }
        }
        return false;
    }
    public bool CheckPressed(Controls control)
    {
        return CheckPressed(_controls[control]);
    }
    public bool CheckClicked(Controls control)
    {
        return CheckClicked(_controls[control]);
    }

    public Keys? GetFirstPressedKey()
    {
        Keys[] pressedKeys = _currentKeyboardState.GetPressedKeys();
        if(pressedKeys.Length == 0)
        {
            return null;
        } else
        {
            return pressedKeys[0];
        }
    }
    public void SetControl(Controls control, Keys newKey)
    {
        _controls[control] = newKey;
    }
}