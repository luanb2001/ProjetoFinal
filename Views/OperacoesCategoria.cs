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

public class OperacoesCategoria : Form
    {
        private System.ComponentModel.IContainer components = null;

        Label lblCategorias;

        Button btnCancel;
        Button btnInsert;
        Button btnDeletar;
        Button btnUpdate;

        ListView listView;
        public OperacoesCategoria()
        {
            this.Controls.Add(this.lblCategorias);

            listView = new ListView();
            listView.Location = new Point(45, 25);
            listView.Size = new Size(410, 500);
            listView.View = View.Details;

            listView.Items.AddRange(new ListViewItem[] { /*lista1, lista2, lista3*/ });
            listView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Descrição", -2, HorizontalAlignment.Left);
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.AllowColumnReorder = true;
            listView.Sorting = SortOrder.Ascending;


            this.btnInsert = new Button();
            this.btnInsert.Text = "Inserir";
            this.btnInsert.Location = new Point(60, 546);
            this.btnInsert.Size = new Size(80, 30);
            this.btnInsert.Click += new EventHandler(this.handleConfirmClickInserirCategoria);

            this.btnUpdate = new Button();
            this.btnUpdate.Text = "Atualizar";
            this.btnUpdate.Location = new Point(160, 546);
            this.btnUpdate.Size = new Size(80, 30);
            this.btnUpdate.Click += new EventHandler(this.handleConfirmClickAtualizarCategoria);

            this.btnDeletar = new Button();
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.Location = new Point(260, 546);
            this.btnDeletar.Size = new Size(80, 30);
            this.btnDeletar.Click += new EventHandler(this.handleConfirmClickDeletarCategoria);
            
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


        private void handleConfirmClickInserirCategoria(object sender, EventArgs e)
        {
            InserirCategoria menu = new InserirCategoria();
            menu.ShowDialog();
        }
        private void handleConfirmClickAtualizarCategoria(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem itemSelecionado = listView.SelectedItems[0];
                new AtualizarCategoria(Convert.ToInt32(itemSelecionado.Text)).Show();
            }
            else
            {
                MessageBox.Show("Não há itens selecionados");
            }
            // AtualizarCategoria menu = new AtualizarCategoria();
            // menu.ShowDialog();
        }
        private void handleConfirmClickDeletarCategoria(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)

            {

                ListViewItem itemSelecionado = listView.SelectedItems[0];

                new ExcluirCategoria(Convert.ToInt32(itemSelecionado.Text)).Show();

            }

            else

            {

                MessageBox.Show("Não há itens selecionados");

            }
            // ExcluirCategoria menu = new ExcluirCategoria();
            // menu.ShowDialog();
        }

        
        private void handleConfirmClick(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show(
                $"Deseja realmente confirmar o agendamento?" +
                $"",
                "STATUS!",
                MessageBoxButtons.YesNo
            );
            if (result == DialogResult.Yes)
            {
                this.Close();
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

        public class InserirCategoria : Form
        {
            private System.ComponentModel.IContainer components = null;

            int id;
            Label lblNome;
            Label lblDescricao;

            TextBox txtNome;
            TextBox txtDescricao;

            Button btnConfirm;
            Button btnCancel;

            public InserirCategoria()
            {
                this.lblNome = new Label();
                this.lblNome.Text = "Nome";
                this.lblNome.Location = new Point(132, 20);

                this.lblDescricao = new Label();
                this.lblDescricao.Text = "Descrição";
                this.lblDescricao.Location = new Point(125, 80);
                this.lblDescricao.Size = new Size(300, 30);


                this.txtNome = new TextBox();
                this.txtNome.Location = new Point(10, 50);
                this.txtNome.Size = new Size(280, 30);

                this.txtDescricao = new TextBox();
                this.txtDescricao.Location = new Point(10, 110);
                this.txtDescricao.Size = new Size(280, 30);

                this.btnConfirm = new Button();
                this.btnConfirm.Text = "Confirmar";
                this.btnConfirm.Location = new Point(110, 180);
                this.btnConfirm.Size = new Size(80, 30);
                this.btnConfirm.Click += new EventHandler(this.handleConfirmClick);

                this.btnCancel = new Button();
                this.btnCancel.Text = "Fechar";
                this.btnCancel.Location = new Point(110, 220);
                this.btnCancel.Size = new Size(80, 30);
                this.btnCancel.Click += new EventHandler(this.handleCancelClick);


                this.Controls.Add(this.lblNome);
                this.Controls.Add(this.lblDescricao);

                this.Controls.Add(this.txtNome);
                this.Controls.Add(this.txtDescricao);

                this.Controls.Add(this.btnConfirm);
                this.Controls.Add(this.btnCancel);

                this.components = new System.ComponentModel.Container();
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(300, 300);
                this.Text = "Inserir Categoria";
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            private void handleConfirmClick(object sender, EventArgs e)
            {
                DialogResult result;
            result = MessageBox.Show(
                $"Deseja inserir uma nova categoria?" +
                $"",
                "Inserir Categoria",
                MessageBoxButtons.YesNo
            );
            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    $"Categoria inserido com sucesso! " +
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

        public class AtualizarCategoria : Form
        {
            int id;
            Label lblNome;
            Label lblDescricao;

            TextBox txtNome;
            TextBox txtDescricao;


            Button btnConfirm;
            Button btnCancel;

            public AtualizarCategoria(int id)
            {
                this.lblNome = new Label();
                this.lblNome.Text = "Nome";
                this.lblNome.Location = new Point(132, 20);

                this.lblDescricao = new Label();
                this.lblDescricao.Text = "Descrição";
                this.lblDescricao.Location = new Point(125, 80);
                this.lblDescricao.Size = new Size(300, 30);


                this.txtNome = new TextBox();
                this.txtNome.Location = new Point(10, 50);
                this.txtNome.Size = new Size(280, 30);

                this.txtDescricao = new TextBox();
                this.txtDescricao.Location = new Point(10, 110);
                this.txtDescricao.Size = new Size(280, 30);

                this.btnConfirm = new Button();
                this.btnConfirm.Text = "Confirmar";
                this.btnConfirm.Location = new Point(110, 180);
                this.btnConfirm.Size = new Size(80, 30);
                this.btnConfirm.Click += new EventHandler(this.handleConfirmClick);

                this.btnCancel = new Button();
                this.btnCancel.Text = "Fechar";
                this.btnCancel.Location = new Point(110, 220);
                this.btnCancel.Size = new Size(80, 30);
                this.btnCancel.Click += new EventHandler(this.handleCancelClick);


                this.Controls.Add(this.lblNome);
                this.Controls.Add(this.lblDescricao);

                this.Controls.Add(this.txtNome);
                this.Controls.Add(this.txtDescricao);

                this.Controls.Add(this.btnConfirm);
                this.Controls.Add(this.btnCancel);
                

                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(300, 300);
                this.Text = "Inserir Categoria";
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            private void handleConfirmClick(object sender, EventArgs e)
            {
                DialogResult result;
            result = MessageBox.Show(
                $"Deseja atualizar uma categoria?" +
                $"",
                "Atualizar Categoria",
                MessageBoxButtons.YesNo
            );
            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    $"Categoria atualizada com sucesso! " +
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

        public class ExcluirCategoria : Form
        {
            int id;
            Label lblId;
            TextBox TxtId;

            Button btnConfirm;
            Button btnCancel;

            public ExcluirCategoria(int id)
            {
                this.lblId = new Label();
                this.lblId.Text = "Digite o Id:";
                this.lblId.Location = new Point(110, 20);

                this.TxtId = new TextBox();
                this.TxtId.Location = new Point(10, 50);
                this.TxtId.Size = new Size(280, 30);

                this.btnConfirm = new Button();
                this.btnConfirm.Text = "Confirmar";
                this.btnConfirm.Location = new Point(50, 150);
                this.btnConfirm.Size = new Size(80, 30);
                this.btnConfirm.Click += new EventHandler(this.handleConfirmClick);

                this.btnCancel = new Button();
                this.btnCancel.Text = "Cancelar";
                this.btnCancel.Location = new Point(140, 150);
                this.btnCancel.Size = new Size(80, 30);
                this.btnCancel.Click += new EventHandler(this.handleCancelClick);

                this.Controls.Add(this.lblId);
                this.Controls.Add(this.TxtId);
                this.Controls.Add(this.btnConfirm);
                this.Controls.Add(this.btnCancel);

                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(300, 300);
                this.Text = "Deletar Categoria ";
                this.StartPosition = FormStartPosition.CenterScreen;
            }

            private void handleConfirmClick(object sender, EventArgs e)
            {
                DialogResult result;
            result = MessageBox.Show(
                $"Deseja excluir uma categoria?" +
                $"",
                "Excluir Categoria",
                MessageBoxButtons.YesNo
            );
            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    $"Categoria excluida com sucesso! " +
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
    }