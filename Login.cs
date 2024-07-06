using System;
using System.Windows.Forms;

public partial class LoginForm : Form
{
    private DatabaseHelper dbHelper;

    public LoginForm()
    {
        InitializeComponent();
        dbHelper = new DatabaseHelper("your_connection_string");
    }

    private void loginButton_Click(object sender, EventArgs e)
    {
        string username = usernameTextBox.Text;
        string password = passwordTextBox.Text;

        if (dbHelper.ValidateUser(username, password))
        {
            RegistryHelper.SaveLoginInfo(username, password);
            ProfileForm profileForm = new ProfileForm(username);
            profileForm.Show();
            this.Hide();
        }
        else
        {
            MessageBox.Show("Invalid username or password.");
        }
    }
}
