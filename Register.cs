using System;
using System.Windows.Forms;

public partial class RegisterForm : Form
{
    private DatabaseHelper dbHelper;

    public RegisterForm()
    {
        InitializeComponent();
        dbHelper = new DatabaseHelper("your_connection_string");
    }

    private void registerButton_Click(object sender, EventArgs e)
    {
        string username = usernameTextBox.Text;
        string password = passwordTextBox.Text;
        string email = emailTextBox.Text;

        if (dbHelper.RegisterUser(username, password, email))
        {
            MessageBox.Show("Registration successful!");
        }
        else
        {
            MessageBox.Show("Registration failed.");
        }
    }
}
