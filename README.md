## Synchronized inherited button

Just to elaborate on the excellent comment by Ňɏssa Pøngjǣrdenlarp, form inheritance is more of a design-time behavior where the subclass inherits the _layout_ properties you specify. But at runtime, when you make a instance of `InheritedClass`, its instance of (for example) `buttonSetting` is distinct as well.

So to "mirror" the color change behavior, add a handler for when `buttonSetting.BackColor` changes and go through all of the forms in the app to synchronize the change.

```
buttonSetting.BackColorChanged += (sender, e) =>
{
    if (
        sender is Button srce
        &&
        string.Equals(srce.Name, "buttonSetting"))
    {
        foreach (var form in Application.OpenForms.OfType<MainForm>())
        {
            // Find the button on each form and update its color.
            if (form.Controls["buttonSetting"] is Button dest)
            {
                dest.BackColor = srce.BackColor;
            }
        }
    }
};
```
___

##### Example

Here's that snippet with some context:

[![demo showing synchronized color changes][1]][1]

###### Inherited Form Class
```
public class InheritedForm : MainForm 
{
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if(e.CloseReason.Equals(CloseReason.UserClosing))
        {
            e.Cancel = true;
            Hide();
            Application.OpenForms["MainForm"]?.BringToFront(); // Workaroud 'last visible child' issue
        }
        base.OnFormClosing(e);
    }
}
```
___

##### MainForm runtime

```
public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        buttonSetting.BackColorChanged += (sender, e) =>
        {
            if (
                sender is Button srce
                &&
                string.Equals(srce.Name, "buttonSetting"))
            {
                foreach (var form in Application.OpenForms.OfType<MainForm>())
                {
                    // Find the button on each form and update its color.
                    if (form.Controls["buttonSetting"] is Button dest)
                    {
                        dest.BackColor = srce.BackColor;
                    }
                }
            }
        };

        // Toggle color
        buttonSetting.Click += (sender, e) =>
            buttonSetting.BackColor = buttonSetting.BackColor.Equals(Color.LightSkyBlue) ?
            Color.FromArgb(151, 242, 0) : Color.LightSkyBlue;

        buttonShowForm1.Click += (sender, e) =>
        {
            var mainForm = Application.OpenForms["MainForm"];
            if (Application.OpenForms["f1"] is Form form)                   
            {
                if(!form.Visible) form.Show(mainForm);
            }
            else
            {
                new InheritedForm
                {
                    Text = "Inherited Form 1",
                    Name = "f1",
                    StartPosition = FormStartPosition.Manual,
                    Size = mainForm.Size,
                    Location = new Point(mainForm.Left + mainForm.Width + 10, mainForm.Top),
                }.Show(mainForm);
            }
        };
        buttonShowForm2.Click += (sender, e) =>
        {
            var mainForm = Application.OpenForms["MainForm"];
            if (Application.OpenForms["f2"] is Form form)
            {
                if (!form.Visible) form.Show(mainForm);
            }
            else
            {
                new InheritedForm
                { 
                    Text = "Inherited Form 2",
                    Name = "f2",
                    StartPosition = FormStartPosition.Manual,
                    Size = mainForm.Size,
                    Location = new Point(
                        mainForm.Left + mainForm.Width + 10, 
                        mainForm.Top + mainForm.Height + 10),
                }.Show(mainForm);
            }
        };
    }
}
```

  [1]: https://i.stack.imgur.com/HSbzm.png