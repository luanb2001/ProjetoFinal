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

public class OperacoesSenha : Form 
    {
        private System.ComponentModel.IContainer components = null;

        Label lblSenhas;

        Button btnCancel;
        Button btnInsert;
        Button btnDeletar;
        Button btnUpdate;

        ListView listView;
        public OperacoesSenha()
        {
            /*this.lblSenhas = new Label();
            this.lblSenhas.Text = "Senhas";
            this.lblSenhas.Location = new Point(220, 10);*/

            this.Controls.Add(this.lblSenhas);

            listView = new ListView();
            listView.Location = new Point(45, 25);
            listView.Size = new Size(410, 500);
            listView.View = View.Details;
            /*ListViewItem lista1 = new ListViewItem("0");
            lista1.SubItems.Add("Arrancar dente");
            lista1.SubItems.Add("R$ 50,00");*/

            listView.Items.AddRange(new ListViewItem[] { /*lista1*/ });
            listView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Categoria", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Url", -2, HorizontalAlignment.Left);
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.AllowColumnReorder = true;
            listView.Sorting = SortOrder.Ascending;
    

            this.btnInsert = new Button();
            this.btnInsert.Text = "Inserir";
            this.btnInsert.Location = new Point(60, 546);
            this.btnInsert.Size = new Size(80, 30);
            this.btnInsert.Click += new EventHandler(this.handleConfirmClickSenhaInserir);

            this.btnUpdate = new Button();
            this.btnUpdate.Text = "Atualizar";
            this.btnUpdate.Location = new Point(160, 546);
            this.btnUpdate.Size = new Size(80, 30);
            this.btnUpdate.Click += new EventHandler(this.handleConfirmClickSenhaAtualizar);

            this.btnDeletar = new Button();
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.Location = new Point(260, 546);
            this.btnDeletar.Size = new Size(80, 30);
            this.btnDeletar.Click += new EventHandler(this.handleConfirmClickSenhaDeletar);

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
        }

        private void handleConfirmClickSenhaAtualizar(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem itemSelecionado = listView.SelectedItems[0];
                new AtualizarSenha(Convert.ToInt32(itemSelecionado.Text)).Show();
            }
            else
            {
                MessageBox.Show("Não há itens selecionados");
            }
        }
        private void handleConfirmClickSenhaDeletar(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem itemSelecionado = listView.SelectedItems[0];
                new ExcluirSenha(Convert.ToInt32(itemSelecionado.Text)).Show();
            }
            else
            {
                MessageBox.Show("Não há itens selecionados");
            }
        }
        private void handleConfirmClickSenhaInserir(object sender, EventArgs e)
        {
            InserirSenha menu = new InserirSenha();
            menu.ShowDialog();
        }
        private void handleCancelClick(object sender, EventArgs e)
        {

            this.Close();
        }
    }

    public class InserirSenha : Form 
    {
        private System.ComponentModel.IContainer components = null;

        Label lblNome;
        Label lblCategoria;
        Label lblUrl;
        Label lblUsuario;
        Label lblSenha;
        Label lblProcedimento;
        Label lblTags;

        TextBox txtNome;
        TextBox txtCategoria;
        TextBox txtUrl;
        TextBox txtUsuario;
        TextBox txtSenha;
        ListBox listProcedimento;
        CheckedListBox clbTags;

        ComboBox cbCategoria;

        Button btnConfirm;
        Button btnCancel;

        public InserirSenha()
        {
            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new Point(127, 20);
            this.lblNome.Size = new Size(300, 30);

            this.lblCategoria = new Label();
            this.lblCategoria.Text = "Categoria";
            this.lblCategoria.Location = new Point(120, 80);
            this.lblCategoria.Size = new Size(300, 30);

            this.lblUrl = new Label();
            this.lblUrl.Text = "Url";
            this.lblUrl.Location = new Point(132, 140);
            this.lblUrl.Size = new Size(300, 30);

            this.lblUsuario = new Label();
            this.lblUsuario.Text = "Usuário";
            this.lblUsuario.Location = new Point(122, 200);
            this.lblUsuario.Size = new Size(300, 30);

            this.lblSenha = new Label();
            this.lblSenha.Text = "Senha";
            this.lblSenha.Location = new Point(125, 260);
            this.lblSenha.Size = new Size(300, 30);

            this.lblProcedimento = new Label();
            this.lblProcedimento.Text = "Procedimento";
            this.lblProcedimento.Location = new Point(110, 320);
            this.lblProcedimento.Size = new Size(300, 30);

            this.lblTags = new Label();
            this.lblTags.Text = "Tags";
            this.lblTags.Location = new Point(129, 450);
            this.lblTags.Size = new Size(300, 30);


            this.txtNome = new TextBox();
            this.txtNome.Location = new Point(10, 50);
            this.txtNome.Size = new Size(280, 30);

            string[] categoria = {};
			cbCategoria = new ComboBox();
			foreach (var categorias in categoria)
			{
				cbCategoria.Items.Add(categorias);
			}
			cbCategoria.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			cbCategoria.Location = new Point(10, 110);
			cbCategoria.Size = new Size(280,30);
			cbCategoria.Sorted = true;

            this.txtUrl = new TextBox();
            this.txtUrl.Location = new Point(10, 170);
            this.txtUrl.Size = new Size(280, 30);

            this.txtUsuario = new TextBox();
            this.txtUsuario.Location = new Point(10, 230);
            this.txtUsuario.Size = new Size(280, 30);

            this.txtSenha = new TextBox();
            this.txtSenha.Location = new Point(10, 290);
            this.txtSenha.Size = new Size(280, 30);

            this.listProcedimento = new ListBox();
            this.listProcedimento.Location = new Point(10, 350);
            this.listProcedimento.Size = new Size(280, 100);

            this.clbTags = new CheckedListBox();
            this.clbTags.Location = new Point(10, 480);
            this.clbTags.Size = new Size(280, 100);
            string[] filmes = { "teste1", "teste2", "teste3" };
			clbTags.Items.AddRange(filmes);
			clbTags.SelectionMode = SelectionMode.One;
			clbTags.CheckOnClick = true;


            this.btnConfirm = new Button();
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.Location = new Point(100, 680);
            this.btnConfirm.Size = new Size(90, 30);
            this.btnConfirm.Click += new EventHandler(this.handleConfirmClick);

            this.btnCancel = new Button();
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Location = new Point(100, 720);
            this.btnCancel.Size = new Size(90, 30);
            this.btnCancel.Click += new EventHandler(this.handleCancelClick);

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.lblProcedimento);
            this.Controls.Add(this.lblTags);

            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.listProcedimento);
            this.Controls.Add(this.clbTags);

            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 770);
            this.Text = "Atualizar Senha";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void handleConfirmClick(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show(
                $"Deseja inserir uma nova senha?" +
                $"",
                "Inserir Senha",
                MessageBoxButtons.YesNo
            );
            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    $"Senha inserida com sucesso! " +
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

    public class AtualizarSenha : Form 
    {
        private System.ComponentModel.IContainer components = null;

        int id;
        Label lblNome;
        Label lblCategoria;
        Label lblUrl;
        Label lblUsuario;
        Label lblSenha;
        Label lblProcedimento;
        Label lblTags;

        TextBox txtNome;
        TextBox txtCategoria;
        TextBox txtUrl;
        TextBox txtUsuario;
        TextBox txtSenha;
        ListBox listProcedimento;
        CheckedListBox clbTags;

        ComboBox cbCategoria;

        Button btnConfirm;
        Button btnCancel;

        public AtualizarSenha(int id)
        {
            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new Point(127, 20);
            this.lblNome.Size = new Size(300, 30);

            this.lblCategoria = new Label();
            this.lblCategoria.Text = "Categoria";
            this.lblCategoria.Location = new Point(120, 80);
            this.lblCategoria.Size = new Size(300, 30);

            this.lblUrl = new Label();
            this.lblUrl.Text = "Url";
            this.lblUrl.Location = new Point(132, 140);
            this.lblUrl.Size = new Size(300, 30);

            this.lblUsuario = new Label();
            this.lblUsuario.Text = "Usuário";
            this.lblUsuario.Location = new Point(122, 200);
            this.lblUsuario.Size = new Size(300, 30);

            this.lblSenha = new Label();
            this.lblSenha.Text = "Senha";
            this.lblSenha.Location = new Point(125, 260);
            this.lblSenha.Size = new Size(300, 30);

            this.lblProcedimento = new Label();
            this.lblProcedimento.Text = "Procedimento";
            this.lblProcedimento.Location = new Point(110, 320);
            this.lblProcedimento.Size = new Size(300, 30);

            this.lblTags = new Label();
            this.lblTags.Text = "Tags";
            this.lblTags.Location = new Point(129, 450);
            this.lblTags.Size = new Size(300, 30);


            this.txtNome = new TextBox();
            this.txtNome.Location = new Point(10, 50);
            this.txtNome.Size = new Size(280, 30);

            string[] categoria = {};
			cbCategoria = new ComboBox();
			foreach (var categorias in categoria)
			{
				cbCategoria.Items.Add(categorias);
			}
			cbCategoria.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			cbCategoria.Location = new Point(10, 110);
			cbCategoria.Size = new Size(280,30);
			cbCategoria.Sorted = true;

            this.txtUrl = new TextBox();
            this.txtUrl.Location = new Point(10, 170);
            this.txtUrl.Size = new Size(280, 30);

            this.txtUsuario = new TextBox();
            this.txtUsuario.Location = new Point(10, 230);
            this.txtUsuario.Size = new Size(280, 30);

            this.txtSenha = new TextBox();
            this.txtSenha.Location = new Point(10, 290);
            this.txtSenha.Size = new Size(280, 30);

            this.listProcedimento = new ListBox();
            this.listProcedimento.Location = new Point(10, 350);
            this.listProcedimento.Size = new Size(280, 100);

            this.clbTags = new CheckedListBox();
            this.clbTags.Location = new Point(10, 480);
            this.clbTags.Size = new Size(280, 100);
            string[] filmes = { "teste1", "teste2", "teste3" };
			clbTags.Items.AddRange(filmes);
			clbTags.SelectionMode = SelectionMode.One;
			clbTags.CheckOnClick = true;


            this.btnConfirm = new Button();
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.Location = new Point(100, 680);
            this.btnConfirm.Size = new Size(90, 30);
            this.btnConfirm.Click += new EventHandler(this.handleConfirmClick);

            this.btnCancel = new Button();
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Location = new Point(100, 720);
            this.btnCancel.Size = new Size(90, 30);
            this.btnCancel.Click += new EventHandler(this.handleCancelClick);

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.lblProcedimento);
            this.Controls.Add(this.lblTags);

            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.listProcedimento);
            this.Controls.Add(this.clbTags);

            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 770);
            this.Text = "Atualizar Senha";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void handleConfirmClick(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show(
                $"Deseja atualizar uma senha?" +
                $"",
                "Atualizar Senha",
                MessageBoxButtons.YesNo
            );
            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    $"Senha atualizada com sucesso! " +
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

    public class ExcluirSenha : Form 
    {
            private System.ComponentModel.IContainer components = null;

            int id;
            Label lblDeletar;

            Button btnConfirm;
            Button btnCancel;

            public ExcluirSenha(int id)
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
                    SenhaController.ExcluirSenha(
                        this.id
                    );

                    MessageBox.Show("Senha deletada com sucesso!");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Erro ao deletar senha.");
                }*/ 
            }

            private void handleCancelClick(object sender, EventArgs e)
            {
                this.Close();
            }
        }