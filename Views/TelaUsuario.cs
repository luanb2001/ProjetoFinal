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

public class TelaUsuario : Form
    {
        private System.ComponentModel.IContainer components = null;

        Label lblUsuario;

        Button btnCategorias;
        Button btnTags;
        Button btnSenhas;
        Button btnUsuario;
        Button btnCancel;

        public TelaUsuario()
        {
            this.lblUsuario = new Label();
            this.lblUsuario.Text = "Olá João";
            this.lblUsuario.Location = new Point(120, 50);

            this.btnCategorias = new Button();
            this.btnCategorias.Text = "Categorias";
            this.btnCategorias.Location = new Point(100, 110);
            this.btnCategorias.Size = new Size(100, 30);
            this.btnCategorias.Click += new EventHandler(this.handleCategoriasClick);

            this.btnTags = new Button();
            this.btnTags.Text = "Tags";
            this.btnTags.Location = new Point(100, 150);
            this.btnTags.Size = new Size(100, 30);
            this.btnTags.Click += new EventHandler(this.handleTagsClick);

            this.btnSenhas = new Button();
            this.btnSenhas.Text = "Senhas";
            this.btnSenhas.Location = new Point(100, 190);
            this.btnSenhas.Size = new Size(100, 30);
            this.btnSenhas.Click += new EventHandler(this.handleSenhasClick);

            this.btnUsuario = new Button();
            this.btnUsuario.Text = "Usuario";
            this.btnUsuario.Location = new Point(100, 230);
            this.btnUsuario.Size = new Size(100, 30);
            this.btnUsuario.Click += new EventHandler(this.handleUsuarioClick);

            this.btnCancel = new Button();
            this.btnCancel.Text = "Fechar";
            this.btnCancel.Location = new Point(100, 300);
            this.btnCancel.Size = new Size(100, 30);
            this.btnCancel.Click += new EventHandler(this.handleCancelClick);

            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnCategorias);
            this.Controls.Add(this.btnTags);
            this.Controls.Add(this.btnSenhas);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.btnCancel);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 400);
            this.Text = "Menu";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void handleCategoriasClick(object sender, EventArgs e)
        {
            OperacoesCategoria menu = new OperacoesCategoria();
            menu.ShowDialog();
        }

        private void handleTagsClick(object sender, EventArgs e)
        {
            OperacoesTag menu = new OperacoesTag();
            menu.ShowDialog();
        }

        private void handleSenhasClick(object sender, EventArgs e)
        {
            // OperacoesSenha menu = new OperacoesSenha();
            // menu.ShowDialog();
        }

        private void handleUsuarioClick(object sender, EventArgs e)
        {
            // OperacoesUsuario menu = new OperacoesUsuario();
            // menu.ShowDialog();
        }

        private void handleCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

    }