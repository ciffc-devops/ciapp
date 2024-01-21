using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Design;
using System.Windows.Forms.Integration;
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
        //this.AutoSize = true;

        box.SpellCheck.IsEnabled = true;
        box.VerticalContentAlignment = VerticalAlignment.Center;
        box.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
        box.TextChanged += new System.Windows.Controls.TextChangedEventHandler(SpellBox_TextChanged);

        this.Size = new System.Drawing.Size(100, 20);


        box.Loaded += delegate
        {
            var source = PresentationSource.FromVisual(box);
            var hwndTarget = source.CompositionTarget as HwndTarget;

            if (hwndTarget != null)
            {
                hwndTarget.RenderMode = RenderMode.SoftwareOnly;
            }
        };

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