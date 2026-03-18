namespace MyApp.WinForms;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private TextBox txtUsername;
    private TextBox txtPassword;
    private Button btnLogin;
    private Button btnRegister;
    private Label lblMessage;
    private Label label1;
    private Label label2;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.txtUsername = new TextBox();
        this.txtPassword = new TextBox();
        this.btnLogin = new Button();
        this.btnRegister = new Button();
        this.lblMessage = new Label();
        this.label1 = new Label();
        this.label2 = new Label();
        this.SuspendLayout();

        // label1
        this.label1.AutoSize = true;
        this.label1.Location = new Point(30, 30);
        this.label1.Name = "label1";
        this.label1.Size = new Size(60, 15);
        this.label1.TabIndex = 0;
        this.label1.Text = "Username:";

        // txtUsername
        this.txtUsername.Location = new Point(30, 50);
        this.txtUsername.Name = "txtUsername";
        this.txtUsername.Size = new Size(200, 23);
        this.txtUsername.TabIndex = 1;

        // label2
        this.label2.AutoSize = true;
        this.label2.Location = new Point(30, 80);
        this.label2.Name = "label2";
        this.label2.Size = new Size(60, 15);
        this.label2.TabIndex = 2;
        this.label2.Text = "Password:";

        // txtPassword
        this.txtPassword.Location = new Point(30, 100);
        this.txtPassword.Name = "txtPassword";
        this.txtPassword.PasswordChar = '*';
        this.txtPassword.Size = new Size(200, 23);
        this.txtPassword.TabIndex = 3;

        // btnLogin
        this.btnLogin.Location = new Point(30, 140);
        this.btnLogin.Name = "btnLogin";
        this.btnLogin.Size = new Size(95, 30);
        this.btnLogin.TabIndex = 4;
        this.btnLogin.Text = "Login";
        this.btnLogin.UseVisualStyleBackColor = true;
        this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

        // btnRegister
        this.btnRegister.Location = new Point(135, 140);
        this.btnRegister.Name = "btnRegister";
        this.btnRegister.Size = new Size(95, 30);
        this.btnRegister.TabIndex = 5;
        this.btnRegister.Text = "Register";
        this.btnRegister.UseVisualStyleBackColor = true;
        this.btnRegister.Click += new EventHandler(this.btnRegister_Click);

        // lblMessage
        this.lblMessage.AutoSize = true;
        this.lblMessage.Location = new Point(30, 180);
        this.lblMessage.Name = "lblMessage";
        this.lblMessage.Size = new Size(200, 15);
        this.lblMessage.TabIndex = 6;
        this.lblMessage.Text = "";

        // Form1
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(284, 221);
        this.Controls.Add(this.lblMessage);
        this.Controls.Add(this.btnRegister);
        this.Controls.Add(this.btnLogin);
        this.Controls.Add(this.txtPassword);
        this.Controls.Add(this.txtUsername);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Name = "Form1";
        this.Text = "MyApp Login";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}