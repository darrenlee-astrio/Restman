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

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern bool LockWindowUpdate(IntPtr hWndLock);

    public static void Suspend(this Control control)
    {
        LockWindowUpdate(control.Handle);
    }

    public static void Resume(this Control control)
    {
        LockWindowUpdate(IntPtr.Zero);
    }
}