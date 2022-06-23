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

public class OperacoesTag : Form 
    {
        private System.ComponentModel.IContainer components = null;

        Label lblTags;

        Button btnCancel;
        Button btnInsert;
        Button btnDeletar;
        Button btnUpdate;

        ListView listView;
        ListViewItem newLine;   
        public OperacoesTag()
        {
            this.Controls.Add(this.lblTags);

            listView = new ListView();
            listView.Location = new Point(45, 25);
            listView.Size = new Size(410, 500);
            listView.View = View.Details;

            listView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Descrição", -2, HorizontalAlignment.Left);
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.AllowColumnReorder = true;
            listView.Sorting = SortOrder.Ascending;

            foreach (Tag item in ControllerTag.VisualizarTag())
            {
                newLine = new ListViewItem(item.Id.ToString());
                newLine.SubItems.Add(item.Descricao);

                listView.Items.Add(newLine);
            }

            this.btnInsert = new Button();
            this.btnInsert.Text = "Inserir";
            this.btnInsert.Location = new Point(60, 546);
            this.btnInsert.Size = new Size(80, 30);
            this.btnInsert.Click += new EventHandler(this.handleConfirmClickTagInserir);

            this.btnUpdate = new Button();
            this.btnUpdate.Text = "Atualizar";
            this.btnUpdate.Location = new Point(160, 546);
            this.btnUpdate.Size = new Size(80, 30);
            this.btnUpdate.Click += new EventHandler(this.handleConfirmClickTagAtualizar);

            this.btnDeletar = new Button();
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.Location = new Point(260, 546);
            this.btnDeletar.Size = new Size(80, 30);
            this.btnDeletar.Click += new EventHandler(this.handleConfirmClickTagDeletar);

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

        private void handleConfirmClickTagInserir(object sender, EventArgs e)
        {
            InserirTag menu = new InserirTag();
            menu.ShowDialog();
        }

        private void handleConfirmClickTagAtualizar(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem itemSelecionado = listView.SelectedItems[0];
                new InserirTag(Convert.ToInt32(itemSelecionado.Text)).Show();
            }
            else
            {
                MessageBox.Show("Não há itens selecionados");
            }
        }
        
        private void handleConfirmClickTagDeletar(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem itemSelecionado = listView.SelectedItems[0];
                new ExcluirTag(Convert.ToInt32(itemSelecionado.Text)).Show();
            }
            else
            {
                MessageBox.Show("Não há itens selecionados");
            }
        }
        
        private void handleCancelClick(object sender, EventArgs e)
        {

            this.Close();
        }
    }

    public class InserirTag : Form //Inserir e Atualizar Tag
        {
            private System.ComponentModel.IContainer components = null;

            Tag tag;

            Label lblNome;
            Label lblDescricao;

            TextBox txtNome;
            TextBox txtDescricao;

            Button btnConfirm;
            Button btnCancel;

            public InserirTag(int id = 0)
            {

                this.lblDescricao = new Label();
                this.lblDescricao.Text = "Descrição";
                this.lblDescricao.Location = new Point(110, 40);
                this.lblDescricao.Size = new Size(300, 20);

                this.txtDescricao = new TextBox();
                this.txtDescricao.Location = new Point(10, 70);
                this.txtDescricao.Size = new Size(270, 20);

                this.btnConfirm = new Button();
                this.btnConfirm.Text = "Confirmar";
                this.btnConfirm.Location = new Point(100, 150);
                this.btnConfirm.Size = new Size(80, 30);
                this.btnConfirm.Click += new EventHandler(this.btnConfirmClick);

                this.btnCancel = new Button();
                this.btnCancel.Text = "Cancelar";
                this.btnCancel.Location = new Point(100, 190);
                this.btnCancel.Size = new Size(80, 30);
                this.btnCancel.Click += new EventHandler(this.btnCancelClick);

                if (id > 0) {
                    this.tag = ControllerTag.GetTag(id);
                    this.txtDescricao.Text = this.tag.Descricao;
                }

                this.Controls.Add(this.lblDescricao);

                this.Controls.Add(this.txtDescricao);

                this.Controls.Add(this.btnConfirm);
                this.Controls.Add(this.btnCancel);

                this.components = new System.ComponentModel.Container();
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.Text = id > 0 ? "Alterar Tag " : "Inserir Tag ";
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            private void btnConfirmClick(object sender, EventArgs e)
            {
                bool isUpdate = this.tag != null;
                try
                {
                
                    if (isUpdate) 
                    {
                    ControllerTag.AtualizarTag(
                        this.tag.Id,
                        txtDescricao.Text
                    );
                    } else {
                        ControllerTag.InserirTag(
                            txtDescricao.Text
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

    public class ExcluirTag : Form 
    {
        private System.ComponentModel.IContainer components = null;
        int Id;
        Label lblDeletar;
        Button btnConfirm;
        Button btnCancel;
        public ExcluirTag(int Id)
        {
            this.Id = Id;

            this.lblDeletar = new Label();
            this.lblDeletar.Text = $"Deseja realmente excluir esse item? (ID: {Id})";
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
                ControllerTag.RemoverItem(
                    this.Id
                );
                MessageBox.Show("Tag deletada com sucesso!");
                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show($"Erro ao deletar tag. {err.Message}");
            } 
        }
        private void handleCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }