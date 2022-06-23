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

public class OperacoesUsuario : Form 
    {
        private System.ComponentModel.IContainer components = null;

        Label lblUsuarios;

        Button btnCancel;
        Button btnInsert;
        Button btnDeletar;
        Button btnUpdate;

        ListView listView;
        public OperacoesUsuario()
        {
            this.Controls.Add(this.lblUsuarios);

            listView = new ListView();
            listView.Location = new Point(45, 25);
            listView.Size = new Size(410, 500);
            listView.View = View.Details;

            listView.Items.AddRange(new ListViewItem[] { /*lista1*/ });
            listView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Email", -2, HorizontalAlignment.Left);
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.AllowColumnReorder = true;
            listView.Sorting = SortOrder.Ascending;


            this.btnInsert = new Button();
            this.btnInsert.Text = "Inserir";
            this.btnInsert.Location = new Point(60, 546);
            this.btnInsert.Size = new Size(80, 30);
            this.btnInsert.Click += new EventHandler(this.handleConfirmClickUsuarioInserir);

            this.btnUpdate = new Button();
            this.btnUpdate.Text = "Atualizar";
            this.btnUpdate.Location = new Point(160, 546);
            this.btnUpdate.Size = new Size(80, 30);
            this.btnUpdate.Click += new EventHandler(this.handleConfirmClickUsuarioAtualizar);

            this.btnDeletar = new Button();
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.Location = new Point(260, 546);
            this.btnDeletar.Size = new Size(80, 30);
            this.btnDeletar.Click += new EventHandler(this.handleConfirmClickUsuarioDeletar);

            this.btnCancel = new Button();
            this.btnCancel.Text = "Voltar";
            this.btnCancel.Location = new Point(360, 546);
            this.btnCancel.Size = new Size(80, 30);
            this.btnCancel.Click += new EventHandler(this.handleCancelClick);


            this.Controls.Add(listView);

            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDeletar);            
            this.Controls.Add(this.btnCancel);

            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Text = "Usuário";
        }

        private void handleConfirmClickUsuarioAtualizar(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem itemSelecionado = listView.SelectedItems[0];
                new AtualizarUsuario(Convert.ToInt32(itemSelecionado.Text)).Show();
            }
            else
            {
                MessageBox.Show("Não há itens selecionados");
            }
        }
        private void handleConfirmClickUsuarioDeletar(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem itemSelecionado = listView.SelectedItems[0];
                new ExcluirUsuario(Convert.ToInt32(itemSelecionado.Text)).Show();
            }
            else
            {
                MessageBox.Show("Não há itens selecionados");
            }
        }
        private void handleConfirmClickUsuarioInserir(object sender, EventArgs e)
        {
            InserirUsuario menu = new InserirUsuario();
            menu.ShowDialog();
        }
        private void handleCancelClick(object sender, EventArgs e)
        {

            this.Close();
        }
    }

    public class InserirUsuario : Form 
    {
        private System.ComponentModel.IContainer components = null;

        Label lblNome;
        Label lblEmail;
        Label lblSenha;

        TextBox txtNome;
        TextBox txtEmail;
        TextBox txtSenha;

        Button btnConfirm;
        Button btnCancel;

        public InserirUsuario()
        {
            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new Point(130, 20);

            this.lblEmail = new Label();
            this.lblEmail.Text = "Email";
            this.lblEmail.Location = new Point(130, 80);
            this.lblEmail.Size = new Size(300, 30);
            
            this.lblSenha = new Label();
            this.lblSenha.Text = "Senha";
            this.lblSenha.Location = new Point(130, 140);
            this.lblSenha.Size = new Size(300, 30);

            this.txtNome = new TextBox();
            this.txtNome.Location = new Point(10, 50);
            this.txtNome.Size = new Size(280, 30);

            this.txtEmail = new TextBox();
            this.txtEmail.Location = new Point(10, 110);
            this.txtEmail.Size = new Size(280, 30);

            this.txtSenha = new TextBox();
            this.txtSenha.Location = new Point(10, 170);
            this.txtSenha.Size = new Size(280, 30);

            this.btnConfirm = new Button();
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.Location = new Point(100, 280);
            this.btnConfirm.Size = new Size(90, 30);
            this.btnConfirm.Click += new EventHandler(this.handleConfirmClick);

            this.btnCancel = new Button();
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Location = new Point(100, 320);
            this.btnCancel.Size = new Size(90, 30);
            this.btnCancel.Click += new EventHandler(this.handleCancelClick);

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblSenha);

            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtSenha);

            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 360);
            this.Text = "Inserir Usuário ";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void handleConfirmClick(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show(
                $"Deseja inserir um novo Usuario?" +
                $"",
                "Inserir Usuario",
                MessageBoxButtons.YesNo
            );
            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    $"Usuario inserido com sucesso! " +
                    $"",
                    "",
                    MessageBoxButtons.OK
                );
            }
            else
            {
                Console.WriteLine("Clicou não");
            }
        }

        private void handleCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class ExcluirUsuario : Form
    {
        private System.ComponentModel.IContainer components = null;
        int id;
        Label lblDeletar;
        Button btnConfirm;
        Button btnCancel;
        public ExcluirUsuario(int id)
        {
            this.lblDeletar = new Label();
            this.lblDeletar.Text = $"Deseja realmente excluir esse item? (ID: {id})";
            this.lblDeletar.Size = new Size(200, 40);
            this.lblDeletar.TextAlign = ContentAlignment.MiddleCenter;
            this.lblDeletar.Location = new Point(0, 20);
            this.btnConfirm = new Button();
            this.btnConfirm.Text = "Sim";
            this.btnConfirm.Size = new Size(80, 30);
            this.btnConfirm.Location = new Point(15, 90);
            this.btnConfirm.Click += new EventHandler(this.handleConfirmClick);

            this.btnCancel = new Button();
            this.btnCancel.Text = "Não";
            this.btnCancel.Size = new Size(80, 30);
            this.btnCancel.Location = new Point(105, 90);
            this.btnCancel.Click += new EventHandler(this.handleCancelClick);
            this.Controls.Add(this.lblDeletar);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 140);
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void handleConfirmClick(object sender, EventArgs e)
        {
            /*try
            {
                UsuarioController.ExcluirUsuario(
                    this.id
                );
                MessageBox.Show("Usuario deletado com sucesso!");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Erro ao deletar tag.");
            }*/ 
        }
        private void handleCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class AtualizarUsuario : Form
    {
        private System.ComponentModel.IContainer components = null;

        int id;
        Label lblNome;
        Label lblEmail;
        Label lblSenha;

        TextBox txtNome;
        TextBox txtEmail;
        TextBox txtSenha;

        Button btnConfirm;
        Button btnCancel;

        public AtualizarUsuario(int id)
        {
            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new Point(130, 20);

            this.lblEmail = new Label();
            this.lblEmail.Text = "Email";
            this.lblEmail.Location = new Point(130, 80);
            this.lblEmail.Size = new Size(300, 30);
            
            this.lblSenha = new Label();
            this.lblSenha.Text = "Senha";
            this.lblSenha.Location = new Point(130, 140);
            this.lblSenha.Size = new Size(300, 30);

            this.txtNome = new TextBox();
            this.txtNome.Location = new Point(10, 50);
            this.txtNome.Size = new Size(280, 30);

            this.txtEmail = new TextBox();
            this.txtEmail.Location = new Point(10, 110);
            this.txtEmail.Size = new Size(280, 30);

            this.txtSenha = new TextBox();
            this.txtSenha.Location = new Point(10, 170);
            this.txtSenha.Size = new Size(280, 30);

            this.btnConfirm = new Button();
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.Location = new Point(100, 280);
            this.btnConfirm.Size = new Size(90, 30);
            this.btnConfirm.Click += new EventHandler(this.handleConfirmClick);

            this.btnCancel = new Button();
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Location = new Point(100, 320);
            this.btnCancel.Size = new Size(90, 30);
            this.btnCancel.Click += new EventHandler(this.handleCancelClick);

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblSenha);

            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtSenha);

            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 360);
            this.Text = "Atualizar Usuário ";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void handleConfirmClick(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show(
                $"Deseja atualizar um Usuário?" +
                $"",
                "Atualizar Usuário",
                MessageBoxButtons.YesNo
            );
            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    $"Usuário atualizado com sucesso! " +
                    $"",
                    "",
                    MessageBoxButtons.OK
                );
            }
            else
            {
                Console.WriteLine("Clicou não");
            }
        }

        private void handleCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
