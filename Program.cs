using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace exemplo_winforms
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }

    public class Login : Form
    {
        private System.ComponentModel.IContainer components = null;

        Label lblUser;
        Label lblPass;


        TextBox txtUser;
        TextBox txtPass;

        Button btnConfirm;
        Button btnCancel;

        public Login()
        {
            this.lblUser = new Label();
            this.lblUser.Text = "Usuário";
            this.lblUser.Location = new Point(120, 20);

            this.lblPass = new Label();
            this.lblPass.Text = "Senha";
            this.lblPass.Location = new Point(120, 80);

            this.txtUser = new TextBox();
            this.txtUser.Location = new Point(10, 50);
            this.txtUser.Size = new Size(280, 30);

            this.txtPass = new TextBox();
            this.txtPass.Location = new Point(10, 110);
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

            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Login";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void handleConfirmClick(object sender, EventArgs e)
        {

            TelaUsuario form = new TelaUsuario();
            form.Size = new Size(320, 440);
            form.Show();
           
        }

        private void handleCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

    }

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

            /*this.btnEspecialidade = new Button();
            this.btnEspecialidade.Text = "Especialidade";
            this.btnEspecialidade.Location = new Point(160, 150);
            this.btnEspecialidade.Size = new Size(100, 30);
            this.btnEspecialidade.Click += new EventHandler(this.handleEspecialidadeClick);*/

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
            /*this.Controls.Add(this.btnEspecialidade);
            this.Controls.Add(this.btnAgendamento);*/
            this.Controls.Add(this.btnCancel);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 400);
            this.Text = "Menu";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void handleCategoriasClick(object sender, EventArgs e)
        {
            OpCategorias menu = new OpCategorias();
            menu.ShowDialog();
        }

        private void handleTagsClick(object sender, EventArgs e)
        {
            OpTags menu = new OpTags();
            menu.ShowDialog();
        }

        private void handleSenhasClick(object sender, EventArgs e)
        {
            OpSenhas menu = new OpSenhas();
            menu.ShowDialog();
        }

        private void handleUsuarioClick(object sender, EventArgs e)
        {
            OpUsuarios menu = new OpUsuarios();
            menu.ShowDialog();
        }

        private void handleCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

    }

    public class OpCategorias : Form
    {
        private System.ComponentModel.IContainer components = null;

        Label lblCategorias;

        Button btnCancel;
        Button btnInsert;
        Button btnDeletar;
        Button btnUpdate;

        ListView listView;
        public OpCategorias()
        {

            /*this.lblCategorias = new Label();
            this.lblCategorias.Text = "Categorias";
            this.lblCategorias.Location = new Point(220, 10);*/

            this.Controls.Add(this.lblCategorias);

            listView = new ListView();
            listView.Location = new Point(45, 25);
            listView.Size = new Size(410, 500);
            listView.View = View.Details;
            /*ListViewItem lista1 = new ListViewItem("Lucas Rafael");
            lista1.SubItems.Add("Maria");
            lista1.SubItems.Add("Obturação");
            lista1.SubItems.Add("Clareamento");
            lista1.SubItems.Add("7");
            lista1.SubItems.Add("...");

            ListViewItem lista2 = new ListViewItem("Lucas Rafael");
            lista2.SubItems.Add("Maria");
            lista2.SubItems.Add("Obturação");
            lista2.SubItems.Add("Clareamento");
            lista2.SubItems.Add("7");
            lista2.SubItems.Add("...");

            ListViewItem lista3 = new ListViewItem("Lucas Rafael");
            lista3.SubItems.Add("Maria");
            lista3.SubItems.Add("Obturação");
            lista3.SubItems.Add("Clareamento");
            lista3.SubItems.Add("7");
            lista3.SubItems.Add("...");*/

            listView.Items.AddRange(new ListViewItem[] { /*lista1, lista2, lista3*/ });
            listView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Descrição", -2, HorizontalAlignment.Left);
            /*listView.Columns.Add("Especialidade", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Sala", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Status", -2, HorizontalAlignment.Left);*/
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
            AtualizarCategoria menu = new AtualizarCategoria();
            menu.ShowDialog();
        }
        private void handleConfirmClickDeletarCategoria(object sender, EventArgs e)
        {
            ExcluirCategoria menu = new ExcluirCategoria();
            menu.ShowDialog();
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
            Label lblNome;
            Label lblDescricao;

            TextBox txtNome;
            TextBox txtDescricao;


            Button btnConfirm;
            Button btnCancel;

            public AtualizarCategoria()
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
                

                //this.components = new System.ComponentModel.Container();
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
            Label lblId;
            TextBox TxtId;

            Button btnConfirm;
            Button btnCancel;

            public ExcluirCategoria()
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

                //this.components = new System.ComponentModel.Container();
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
    public class OpTags : Form 
    {
        private System.ComponentModel.IContainer components = null;

        Label lblTags;

        Button btnCancel;
        Button btnInsert;
        Button btnDeletar;
        Button btnUpdate;

        ListView listView;
        public OpTags()
        {
            /*this.lblTags = new Label();
            this.lblTags.Text = "Tags";
            this.lblTags.Location = new Point(220, 10);*/

            this.Controls.Add(this.lblTags);

            listView = new ListView();
            listView.Location = new Point(45, 25);
            listView.Size = new Size(410, 500);
            listView.View = View.Details;
            /*ListViewItem lista1 = new ListViewItem("0");
            lista1.SubItems.Add("Arrancar dente");
            lista1.SubItems.Add("R$ 50,00");*/

            listView.Items.AddRange(new ListViewItem[] { /*lista1*/ });
            listView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Descrição", -2, HorizontalAlignment.Left);
            /*listView.Columns.Add("Preço", -2, HorizontalAlignment.Left);*/
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.AllowColumnReorder = true;
            listView.Sorting = SortOrder.Ascending;


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

        private void handleConfirmClickTagAtualizar(object sender, EventArgs e)
        {
            AtualizarTag menu = new AtualizarTag();
            menu.ShowDialog();
        }
        private void handleConfirmClickTagDeletar(object sender, EventArgs e)
        {
            ExcluirTag menu = new ExcluirTag();
            menu.Size = new Size(320, 228);
            menu.ShowDialog();
        }
        private void handleConfirmClickTagInserir(object sender, EventArgs e)
        {
            InserirTag menu = new InserirTag();
            menu.ShowDialog();
        }
        private void handleCancelClick(object sender, EventArgs e)
        {

            this.Close();
        }
    }

    public class InserirTag : Form 
    {
        private System.ComponentModel.IContainer components = null;

        Label lblDescricao;

        TextBox txtDescricao;

        Button btnConfirm;
        Button btnCancel;

        public InserirTag()
        {
            this.lblDescricao = new Label();
            this.lblDescricao.Text = "Descrição";
            this.lblDescricao.Location = new Point(120, 20);

            this.txtDescricao = new TextBox();
            this.txtDescricao.Location = new Point(10, 50);
            this.txtDescricao.Size = new Size(280, 30);


            this.btnConfirm = new Button();
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.Location = new Point(105, 120);
            this.btnConfirm.Size = new Size(90, 30);
            this.btnConfirm.Click += new EventHandler(this.handleConfirmClick);

            this.btnCancel = new Button();
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Location = new Point(105, 160);
            this.btnCancel.Size = new Size(90, 30);
            this.btnCancel.Click += new EventHandler(this.handleCancelClick);

            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricao);

            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 230);
            this.Text = "Inserir Tag ";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void handleConfirmClick(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show(
                $"Deseja inserir uma nova Tag?" +
                $"",
                "Inserir Tag",
                MessageBoxButtons.YesNo
            );
            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    $"Tag inserida com sucesso! " +
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

    public class AtualizarTag : Form 
    {
        private System.ComponentModel.IContainer components = null;

        Label lblDescricao;

        TextBox txtDescricao;

        Button btnConfirm;
        Button btnCancel;

        public AtualizarTag()
        {
            this.lblDescricao = new Label();
            this.lblDescricao.Text = "Descrição";
            this.lblDescricao.Location = new Point(120, 20);

            this.txtDescricao = new TextBox();
            this.txtDescricao.Location = new Point(10, 50);
            this.txtDescricao.Size = new Size(280, 30);


            this.btnConfirm = new Button();
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.Location = new Point(105, 120);
            this.btnConfirm.Size = new Size(90, 30);
            this.btnConfirm.Click += new EventHandler(this.handleConfirmClick);

            this.btnCancel = new Button();
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Location = new Point(105, 160);
            this.btnCancel.Size = new Size(90, 30);
            this.btnCancel.Click += new EventHandler(this.handleCancelClick);

            this.Controls.Add(this.lblDescricao);

            this.Controls.Add(this.txtDescricao);

            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 230);
            this.Text = "Atualizar Tag ";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void handleConfirmClick(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show(
                $"Deseja atualizar uma Tag?" +
                $"",
                "Atualizar Tag",
                MessageBoxButtons.YesNo
            );
            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    $"Tag atualizada com sucesso! " +
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

    public class ExcluirTag : Form 
    {
        Label lblId;

        TextBox TxtId;

        Button btnConfirm;
        Button btnCancel;

        public ExcluirTag()
        {
            this.lblId = new Label();
            this.lblId.Text = "Digite o ID:";
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

            //this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Deletar Tag";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void handleConfirmClick(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show(
                $"Deseja excluir uma Tag?" +
                $"",
                "Excluir Tag",
                MessageBoxButtons.YesNo
            );
            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    $"Tag excluida com sucesso! " +
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

    public class OpSenhas : Form 
    {
        private System.ComponentModel.IContainer components = null;

        Label lblSenhas;

        Button btnCancel;
        Button btnInsert;
        Button btnDeletar;
        Button btnUpdate;

        ListView listView;
        public OpSenhas()
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
            AtualizarSenha menu = new AtualizarSenha();
            menu.ShowDialog();
        }
        private void handleConfirmClickSenhaDeletar(object sender, EventArgs e)
        {
            ExcluirSenha menu = new ExcluirSenha();
            menu.Size = new Size(320, 228);
            menu.ShowDialog();
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

        public AtualizarSenha()
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
        Label lblId;

        TextBox TxtId;

        Button btnConfirm;
        Button btnCancel;

        public ExcluirSenha()
        {
            this.lblId = new Label();
            this.lblId.Text = "Digite o ID:";
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

            //this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Deletar Senha";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void handleConfirmClick(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show(
                $"Deseja excluir uma senha?" +
                $"",
                "Excluir Senha",
                MessageBoxButtons.YesNo
            );
            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    $"Escpecialidade exlcuida com sucesso! " +
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
    

    public class OpUsuarios : Form 
    {
        private System.ComponentModel.IContainer components = null;

        Label lblUsuarios;

        Button btnCancel;
        Button btnInsert;
        Button btnDeletar;
        Button btnUpdate;

        ListView listView;
        public OpUsuarios()
        {
            /*this.lblUsuarios = new Label();
            this.lblUsuarios.Text = "Usuários";
            this.lblUsuarios.Location = new Point(220, 10);*/

            this.Controls.Add(this.lblUsuarios);

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
        }

        private void handleConfirmClickUsuarioAtualizar(object sender, EventArgs e)
        {
            AtualizarUsuario menu = new AtualizarUsuario();
            menu.ShowDialog();
        }
        private void handleConfirmClickUsuarioDeletar(object sender, EventArgs e)
        {
            ExcluirUsuario menu = new ExcluirUsuario();
            menu.Size = new Size(320, 228);
            menu.ShowDialog();
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

        TextBox txtNome;
        TextBox txtEmail;

        Button btnConfirm;
        Button btnCancel;

        public InserirUsuario()
        {
            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new Point(120, 20);

            this.lblEmail = new Label();
            this.lblEmail.Text = "Email";
            this.lblEmail.Location = new Point(130, 80);
            this.lblEmail.Size = new Size(300, 30);

            this.txtNome = new TextBox();
            this.txtNome.Location = new Point(10, 50);
            this.txtNome.Size = new Size(280, 30);

            this.txtEmail = new TextBox();
            this.txtEmail.Location = new Point(10, 110);
            this.txtEmail.Size = new Size(280, 30);

            this.btnConfirm = new Button();
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.Location = new Point(100, 190);
            this.btnConfirm.Size = new Size(90, 30);
            this.btnConfirm.Click += new EventHandler(this.handleConfirmClick);

            this.btnCancel = new Button();
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Location = new Point(100, 230);
            this.btnCancel.Size = new Size(90, 30);
            this.btnCancel.Click += new EventHandler(this.handleCancelClick);

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblEmail);

            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtEmail);

            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
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
        Label lblId;

        TextBox TxtId;

        Button btnConfirm;
        Button btnCancel;

        public ExcluirUsuario()
        {
            this.lblId = new Label();
            this.lblId.Text = "Digite o ID:";
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

            //this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Deletar Usuário";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void handleConfirmClick(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show(
                $"Deseja excluir esse Usuário?" +
                $"",
                "Excluir Usuário",
                MessageBoxButtons.YesNo
            );
            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    $"Usuário excluido com sucesso! " +
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

    public class AtualizarUsuario : Form
    {
        private System.ComponentModel.IContainer components = null;

        Label lblNome;
        Label lblEmail;

        TextBox txtNome;
        TextBox txtEmail;

        Button btnConfirm;
        Button btnCancel;

        public AtualizarUsuario()
        {
            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new Point(120, 20);

            this.lblEmail = new Label();
            this.lblEmail.Text = "Email";
            this.lblEmail.Location = new Point(130, 80);
            this.lblEmail.Size = new Size(300, 30);

            this.txtNome = new TextBox();
            this.txtNome.Location = new Point(10, 50);
            this.txtNome.Size = new Size(280, 30);

            this.txtEmail = new TextBox();
            this.txtEmail.Location = new Point(10, 110);
            this.txtEmail.Size = new Size(280, 30);

            this.btnConfirm = new Button();
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.Location = new Point(100, 190);
            this.btnConfirm.Size = new Size(90, 30);
            this.btnConfirm.Click += new EventHandler(this.handleConfirmClick);

            this.btnCancel = new Button();
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Location = new Point(100, 230);
            this.btnCancel.Size = new Size(90, 30);
            this.btnCancel.Click += new EventHandler(this.handleCancelClick);

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblEmail);

            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtEmail);

            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
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


}



