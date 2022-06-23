using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Models;

public class Login : Form
{
    private System.ComponentModel.IContainer components = null;

    Label lblUser;
    Label lblPass;


    TextBox txtUser;
    TextBox txtPass;

    Button btnConfirm;
    Button btnCancel;
    Button btnCadastrar;

    public Login()
    {
        this.lblUser = new Label();
        this.lblUser.Text = "Usuário";
        this.lblUser.Location = new Point(120, 30);

        this.lblPass = new Label();
        this.lblPass.Text = "Senha";
        this.lblPass.Location = new Point(120, 90);

        this.txtUser = new TextBox();
        this.txtUser.Location = new Point(10, 60);
        this.txtUser.Size = new Size(280, 30);

        this.txtPass = new TextBox();
        this.txtPass.Location = new Point(10, 120);
        this.txtPass.Size = new Size(280, 30);
        this.txtPass.PasswordChar = '*';

        this.btnConfirm = new Button();
        this.btnConfirm.Text = "Confirmar";
        this.btnConfirm.Location = new Point(100, 180);
        this.btnConfirm.Size = new Size(80, 30);
        this.btnConfirm.Click += new EventHandler(this.handleConfirmClick);

        this.btnCancel = new Button();
        this.btnCancel.Text = "Cancelar";
        this.btnCancel.Location = new Point(100, 220);
        this.btnCancel.Size = new Size(80, 30);
        this.btnCancel.Click += new EventHandler(this.handleCancelClick);

        this.btnCadastrar = new Button();
        this.btnCadastrar.Text = "Cadastrar";
        this.btnCadastrar.Location = new Point(100, 260);
        this.btnCadastrar.Size = new Size(80, 30);
        this.btnCadastrar.Click += new EventHandler(this.handleCadastrarClick);

        this.Controls.Add(this.lblUser);
        this.Controls.Add(this.lblPass);
        this.Controls.Add(this.txtUser);
        this.Controls.Add(this.txtPass);
        this.Controls.Add(this.btnConfirm);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnCadastrar);

        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(300, 320);
        this.Text = "Login";
        this.StartPosition = FormStartPosition.CenterScreen;
    }

    private void handleConfirmClick(object sender, EventArgs e)
    {
        try
        {
            Usuario.Auth(this.txtUser.Text, this.txtPass.Text);
            (new TelaUsuario()).Show();
        }
        catch (Exception err)
        {
            MessageBox.Show(err.Message);
        }

        // TelaUsuario form = new TelaUsuario();
        // form.Size = new Size(320, 440);
        // form.Show();

    }

    private void handleCancelClick(object sender, EventArgs e)
    {
        this.Close();
    }

    private void handleCadastrarClick(object sender, EventArgs e)
    {

        InserirUsuario form = new InserirUsuario();
        form.Show();

    }

}