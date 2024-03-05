using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Design;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;


[Designer(typeof(ControlDesigner))]
//[DesignerSerializer("System.Windows.Forms.Design.ControlCodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
class SpellBox : ElementHost
{
    public SpellBox()
    {
        box = new TextBox();
        base.Child = box;
        box.TextChanged += (s, e) => OnTextChanged(EventArgs.Empty); 
        box.KeyUp += OnNewKeyUp;

        //this.AutoSize = true;

        box.SpellCheck.IsEnabled = true;
        box.VerticalContentAlignment = VerticalAlignment.Center;
        box.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
        box.TextChanged += new System.Windows.Controls.TextChangedEventHandler(SpellBox_TextChanged);
        box.KeyUp += new KeyEventHandler(WPF_KeyUp);

        this.Size = new System.Drawing.Size(100, 20);


        box.Loaded += delegate
        {
            var source = PresentationSource.FromVisual(box);
            var hwndTarget = source.CompositionTarget as HwndTarget;

            if (hwndTarget != null)
            {
                hwndTarget.RenderMode = RenderMode.SoftwareOnly;
            }

            HwndSource s = HwndSource.FromVisual(box) as HwndSource;
            if (s != null)
                s.AddHook(new HwndSourceHook(ChildHwndSourceHook));
        };

    }
    private const UInt32 DLGC_WANTARROWS = 0x0001;
    private const UInt32 DLGC_WANTTAB = 0x0002;
    private const UInt32 DLGC_WANTALLKEYS = 0x0004;
    private const UInt32 DLGC_HASSETSEL = 0x0008;
    private const UInt32 DLGC_WANTCHARS = 0x0080;
    private const UInt32 WM_GETDLGCODE = 0x0087;

    IntPtr ChildHwndSourceHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        if (msg == WM_GETDLGCODE)
        {
            handled = true;
            return new IntPtr(DLGC_WANTCHARS | DLGC_WANTARROWS | DLGC_HASSETSEL);
        }
        return IntPtr.Zero;
    }


    private void OnNewKeyUp(object sender, KeyEventArgs e)
    {
        if (this.KeyUp != null)
            this.KeyUp(this, e);
    }
    [Browsable(true)]
    [Category("Action")]
    [Description("Invoked when Text Changes")]
    public new event KeyEventHandler KeyUp;
    protected void WPF_KeyUp(object sender, EventArgs e)
    {
        if (this.KeyUp != null)
            this.KeyUp(this, (KeyEventArgs)e);
    }

    [Browsable(true)]
    [Category("Action")]
    [Description("Invoked when Text Changes")]
    public new event EventHandler TextChanged;
    protected void SpellBox_TextChanged(object sender, EventArgs e)
    {
        if (this.TextChanged != null)
            this.TextChanged(this, e);
    }


    [Browsable(true)]
    [Category("Action")]
    [Description("Invoked when the control loses focus")]
    public new event EventHandler Leave;
    protected void SpellBox_Leave(object sender, EventArgs e)
    {
        if (this.Leave != null)
            this.Leave(this, e);
    }



    public override string Text
    {
        get { return box.Text; }
        set { box.Text = value; }
    }
    [DefaultValue(false)]
    public bool Multiline
    {
        get { return box.AcceptsReturn; }
        set
        {
            box.AcceptsReturn = value;
            if (value)
            {
                box.VerticalContentAlignment = VerticalAlignment.Top;

            }
            else
            {
                box.VerticalContentAlignment = VerticalAlignment.Center;
            }

        }
    }
    [DefaultValue(false)]
    public bool WordWrap
    {
        get { return box.TextWrapping != TextWrapping.NoWrap; }
        set { box.TextWrapping = value ? TextWrapping.Wrap : TextWrapping.NoWrap; }
    }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new System.Windows.UIElement Child
    {
        get { return base.Child; }
        set { /* Do nothing to solve a problem with the serializer !! */ }
    }

    public System.Windows.Media.Color TextboxBackColor
    {
        set { box.Background = new SolidColorBrush(value); }
    }

    public void SetBackColor(System.Drawing.Color c)
    {
        box.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(c.A, c.R, c.G, c.B));
    }

    private TextBox box;
}