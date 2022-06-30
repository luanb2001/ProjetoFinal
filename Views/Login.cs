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

    PictureBox pbImagem;

    public Login()
    {
        this.MinimizeBox = false;
        this.MaximizeBox = false;

        this.lblUser = new Label();
        this.lblUser.Text = "Usuário";
        this.lblUser.Location = new Point(35, 202);
        this.lblUser.Size = new Size(60, 20);
        this.lblUser.Font = new Font("Calibri", 12, FontStyle.Bold);

        this.lblPass = new Label();
        this.lblPass.Text = "Senha";
        this.lblPass.Location = new Point(40, 262);
        this.lblPass.Size = new Size(50, 20);
        this.lblPass.Font = new Font("Calibri", 12, FontStyle.Bold);

        this.txtUser = new TextBox();
        this.txtUser.Location = new Point(100, 200);
        this.txtUser.Size = new Size(230, 30);

        this.txtPass = new TextBox();
        this.txtPass.Location = new Point(100, 260);
        this.txtPass.Size = new Size(230, 30);
        this.txtPass.PasswordChar = '*';

        this.btnConfirm = new Button();
        this.btnConfirm.Text = "Confirmar";
        this.btnConfirm.Location = new Point(90, 390);
        this.btnConfirm.Size = new Size(100, 30);
        this.btnConfirm.Click += new EventHandler(this.handleConfirmClick);

        this.btnCancel = new Button();
        this.btnCancel.Text = "Cancelar";
        this.btnCancel.Location = new Point(200, 390);
        this.btnCancel.Size = new Size(100, 30);
        this.btnCancel.Click += new EventHandler(this.handleCancelClick);

        this.btnCadastrar = new Button();
        this.btnCadastrar.Text = "Cadastrar";
        this.btnCadastrar.Location = new Point(155, 300);
        this.btnCadastrar.Size = new Size(80, 30);
        this.btnCadastrar.Click += new EventHandler(this.handleCadastrarClick);

        pbImagem = new PictureBox();
        pbImagem.Size = new Size(150, 150);
        pbImagem.Location = new Point(130, 20);
        pbImagem.ClientSize = new Size(150, 150);
        pbImagem.Load("Views/logo.png");
        pbImagem.SizeMode = PictureBoxSizeMode.Zoom;

        this.Controls.Add(this.lblUser);
        this.Controls.Add(this.lblPass);
        this.Controls.Add(this.txtUser);
        this.Controls.Add(this.txtPass);
        this.Controls.Add(this.btnConfirm);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnCadastrar);
        this.Controls.Add(pbImagem);

        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(400, 470);
        this.Text = "Login";
        this.StartPosition = FormStartPosition.CenterScreen;
        //this.FormBorderStyle = FormBorderStyle.None;
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