namespace Restman.Winform.Common.UiExtensions;

public static class ControlExtensions
{
    public static void InvokeIfRequired<TControl>(this TControl control, Action<TControl> action)
        where TControl : Control
    {
        if (control.InvokeRequired)
        {
            control.Invoke(new Action(() => action(control)));
        }
        else
        {
            action(control);
        }
    }
}