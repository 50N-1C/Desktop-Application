using System;
using System.Windows.Forms;

public partial class ProfileForm : Form
{
    private string username;

    public ProfileForm(string username)
    {
        InitializeComponent();
        this.username = username;
        LoadProfile();
    }

    private void LoadProfile()
    {
        usernameLabel.Text = "Welcome, " + username;
    }
}
