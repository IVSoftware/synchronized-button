namespace synchronized_button
{
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
}


