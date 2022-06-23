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
using Controllers;

public class OperacoesSenha : Form 
    {
        private System.ComponentModel.IContainer components = null;

        Label lblSenhas;

        Button btnCancel;
        Button btnInsert;
        Button btnDeletar;
        Button btnUpdate;

        ListView listView;
        ListViewItem newLine;
        public OperacoesSenha()
        {

            this.Controls.Add(this.lblSenhas);

            listView = new ListView();
            listView.Location = new Point(45, 25);
            listView.Size = new Size(410, 500);
            listView.View = View.Details;

            listView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Categoria", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Url", -2, HorizontalAlignment.Left);

            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.AllowColumnReorder = true;
            listView.Sorting = SortOrder.Ascending;

            foreach (Senha item in ControllerSenha.VisualizarSenha())
            {
                newLine = new ListViewItem(item.Id.ToString());
                newLine.SubItems.Add(item.Nome);
                newLine.SubItems.Add(item.Categoria.Nome);
                newLine.SubItems.Add(item.Url);

                listView.Items.Add(newLine);
            }

            this.btnInsert = new Button();
            this.btnInsert.Text = "Inserir";
            this.btnInsert.Location = new Point(60, 546);
            this.btnInsert.Size = new Size(80, 30);
            this.btnInsert.Click += new EventHandler(this.handleConfirmClickInserirSenha);

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
                new InserirSenha(Convert.ToInt32(itemSelecionado.Text)).Show();
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
        private void handleConfirmClickInserirSenha(object sender, EventArgs e)
        {
            InserirSenha menu = new InserirSenha();
            menu.ShowDialog();
        }
        private void handleCancelClick(object sender, EventArgs e)
        {

            this.Close();
        }
    }

    public class InserirSenha : Form //Inserir e Atualizar Senha
    {
        private System.ComponentModel.IContainer components = null;
    
        Senha senha;
    
        Label lblNome;
        Label lblCategoria;
        Label lblUrl;
        Label lblUsuario;
        Label lblSenha;
        Label lblProcedimento;
        Label lblTags;
    
        TextBox txtNome;
        TextBox txtUrl;
        TextBox txtUsuario;
        TextBox txtSenha;
        TextBox txtProcedimento;
    
        CheckedListBox clbTags;
    
        ComboBox cbCategoria;
    
        Button btnConfirm;
        Button btnCancel;
    
        public InserirSenha(int id = 0)
        {
            this.ClientSize = new System.Drawing.Size(300, 680);
    
            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new Point(20, 20);
            this.lblNome.Size = new Size(300, 30);
    
            this.lblCategoria = new Label();
            this.lblCategoria.Text = "Categoria";
            this.lblCategoria.Location = new Point(20, 80);
            this.lblCategoria.Size = new Size(300, 30);
    
            this.lblUrl = new Label();
            this.lblUrl.Text = "Url";
            this.lblUrl.Location = new Point(20, 140);
            this.lblUrl.Size = new Size(300, 30);
    
            this.lblUsuario = new Label();
            this.lblUsuario.Text = "Usuário";
            this.lblUsuario.Location = new Point(20, 200);
            this.lblUsuario.Size = new Size(300, 30);
    
            this.lblSenha = new Label();
            this.lblSenha.Text = "Senha";
            this.lblSenha.Location = new Point(20, 260);
            this.lblSenha.Size = new Size(300, 30);
    
            this.lblProcedimento = new Label();
            this.lblProcedimento.Text = "Procedimento";
            this.lblProcedimento.Location = new Point(20, 320);
            this.lblProcedimento.Size = new Size(300, 30);
    
            this.lblTags = new Label();
            this.lblTags.Text = "Tags";
            this.lblTags.Location = new Point(20, 453);
            this.lblTags.Size = new Size(300, 30);
    
            this.txtNome = new TextBox();
            this.txtNome.Location = new Point(10, 50);
            this.txtNome.Size = new Size(280, 30);
    
            IEnumerable<Categoria> categorias = ControllerCategoria.VisualizarCategoria();
            cbCategoria = new ComboBox();
            foreach (Categoria categoria in categorias)
            {
                cbCategoria.Items.Add($"{categoria.Id} - {categoria.Nome}");
            }
            
            cbCategoria.Location = new Point(10, 110);
            cbCategoria.Size = new Size(280, 30);
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
            this.txtSenha.PasswordChar = '*';
    
            this.txtProcedimento = new TextBox();
            this.txtProcedimento.Multiline = true;
            this.txtProcedimento.ScrollBars = ScrollBars.Vertical;
            this.txtProcedimento.AcceptsReturn = true;
            this.txtProcedimento.WordWrap = true;
            this.txtProcedimento.Location = new Point(10, 350);
            this.txtProcedimento.Size = new Size(280, 95);
    
            this.clbTags = new CheckedListBox();
            this.clbTags.Location = new Point(10, 483);
            this.clbTags.Size = new Size(280, 100);
            clbTags.SelectionMode = SelectionMode.One;
            clbTags.CheckOnClick = true;
    
            IEnumerable<Tag> tags = ControllerTag.VisualizarTag();
            foreach (Tag item in ControllerTag.VisualizarTag())
            {
                this.clbTags.Items.Add($"{item.Id} - {item.Descricao}");
            }
    
            btnConfirm = new Button();
            btnConfirm.Text = "Confirmar";
            btnConfirm.Location = new Point(60, 620);
            btnConfirm.Size = new Size(80, 30);
            btnConfirm.Click += new EventHandler(this.btnConfirmClick);
            
            btnCancel = new Button();
            btnCancel.Text = "Cancelar";
            btnCancel.Location = new Point(150, 620);
            btnCancel.Size = new Size(80, 30);
            btnCancel.Click += new EventHandler(this.btnCancelClick);
    
            if (id > 0) {
                this.senha = ControllerSenha.GetSenha(id);
                this.txtNome.Text = this.senha.Nome;
            }
    
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
            this.Controls.Add(this.txtProcedimento);
            this.Controls.Add(this.clbTags);
    
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
    
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = id > 0 ? "Alterar Senhas " : "Inserir Senhas ";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void btnConfirmClick(object sender, EventArgs e)
        {
            bool isUpdate = this.senha != null;
            try
            {
                string cbValue = cbCategoria.Text; // "1 - Nome"
                string[] destructCbValue = cbValue.Split('-'); // ["1 ", " Nome"]
                string idCategoria = destructCbValue[0].Trim();
    
                if (isUpdate) 
                {
                    ControllerSenha.AtualizarSenha(
                        this.senha.Id,
                        txtNome.Text,
                        Convert.ToInt32(idCategoria), 
                        txtUrl.Text,
                        txtUsuario.Text,
                        txtSenha.Text,
                        txtProcedimento.Text
                    );
                } else {
                    ControllerSenha.InserirSenha(
                        txtNome.Text,
                        Convert.ToInt32(idCategoria),
                        txtUrl.Text,
                        txtUsuario.Text,
                        txtSenha.Text,
                        txtProcedimento.Text
                    );
                }
    
                MessageBox.Show($"Dados {(isUpdate ? "alterados" : "incluídos")} com sucesso.");
                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show($"Não foi possível {(isUpdate ? "alterar" : "incluir")} os dados. {err.Message}");
            }
        }
    
        private void btnCancelClick(object sender, EventArgs e)
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
            this.id = id;

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
            try
            {
                ControllerSenha.RemoverItem(
                    this.id
                );
                MessageBox.Show("Senha deletada com sucesso!");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Erro ao deletar senha.");
            }
        }
        private void handleCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }