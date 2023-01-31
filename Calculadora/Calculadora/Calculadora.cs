using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Calculadora : Form
    {
        public Calculadora()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.ActiveControl = btnBugVirgula;
            txtResultado.Text = "0";
        }

        //ENUM PARA SELECIONAR A OPERAÇÃO:
        private enum Operacao
        {
            Adicao,
            Subtracao,
            Multiplicacao,
            Divisao,
            Igual
        }

        private Operacao OperacaoSelecionada
        {
            get;
            set;
        }

        /*--------------------------- INSTÂNCIANDO OBJETO E CRIANDO VARIÁVEIS E CONSTANTES AUXILIARES --------------------------*/
        Calculos c = new Calculos();

        private const string V = "";
        double auxResult;

        /*------------------------ HABILITANDO O USO DA MINHA CALCULADORA PELO TECLADO - KEYCHAR E KEYUP ------------------------*/
        private void Calculadora_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)48: btnZero_Click(sender, e); break;
                case (char)49: btnUm_Click(sender, e); break;
                case (char)50: btnDois_Click(sender, e); break;
                case (char)51: btnTres_Click(sender, e); break;
                case (char)52: btnQuatro_Click(sender, e); break;
                case (char)53: btnCinco_Click(sender, e); break;
                case (char)54: btnSeis_Click(sender, e); break;
                case (char)55: btnSete_Click(sender, e); break;
                case (char)56: btnOito_Click(sender, e); break;
                case (char)57: btnNove_Click(sender, e); break;

                case (char)43: btnAdicao_Click(this, EventArgs.Empty); break;
                case (char)45: btnSubtracao_Click(this, EventArgs.Empty); break;
                case (char)42: btnMultiplicacao_Click(this, EventArgs.Empty); break;
                case (char)47: btnDivisao_Click(this, EventArgs.Empty); break;
                case (char)61: btnIgual_Click(this, EventArgs.Empty); break;
                case (char)08: btnBackspace_Click(this, EventArgs.Empty); break;
                case (char)44: btnVirgula_Click(this, EventArgs.Empty); break;
            }

            //Irá determinar se o usuário apertou uma tecla não númerica. Se sim, cancela o evento keypress, previnindo a entrada de não númericos
            e.Handled = true;
        }

        private void Calculadora_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtOperador.Text.Length == 0)
            {
                OperacaoSelecionada = Operacao.Igual;
            }
            if (e.KeyCode == Keys.Enter)
            {
                btnIgual_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Escape)
            {
                btnC_Click(sender, e);
            }
        }

        /*------------------------ DEFINIÇÃO DOS BOTÕES DE ALGARISMO NA MINHA CALCULADORA E SUAS REGRAS -----------------------*/
        private void btnZero_Click(object sender, EventArgs e)
        {
            //Zero irá zerar a operação
            if ((txtOperador.Text == c.Num2 + "+" + c.Num1 && txtResultado.Text.Length > 0) || (txtOperador.Text == c.Num2 + "-" + c.Num1 && txtResultado.Text.Length > 0)
            || (txtOperador.Text == c.Num2 + "*" + c.Num1 && txtResultado.Text.Length > 0) || (txtOperador.Text == c.Num2 + "/" + c.Num1 && txtResultado.Text.Length > 0))
            {
                btnC_Click(sender, e);
            }

            //Realizando nova operação após receber uma divisão por zero
            if (txtResultado.Text == "Indeterminado." || txtResultado.Text == "Não é possível dividir por zero.")
            {
                txtResultado.Font = new Font("Arial", 30.0F);
                btnC_Click(sender, e);
            }

            //Impossibilitando mais de um zero a esquerda
            if (txtResultado.Text.StartsWith("0") && txtResultado.Text.Length == 1)
            {
                txtResultado.Text.TrimStart('0');
            }
            else
            {
                txtResultado.Text += "0";
            }

            this.ActiveControl = btnBugVirgula;
        }

        private void btnUm_Click(object sender, EventArgs e)
        {
            //Realizando nova operação após receber uma divisão por zero
            if (txtResultado.Text == "Indeterminado." || txtResultado.Text == "Não é possível dividir por zero.")
            {
                txtResultado.Font = new Font("Arial", 30.0F);
                btnC_Click(sender, e);
            }

            //Inicializando a calculadora com o zero, mas retirando ao digitar o primeiro número
            if (txtResultado.Text == "0" && txtResultado.Text.Length == 1)
            {
                txtResultado.Text = "1";
            }
            else
            {
                txtResultado.Text += "1";
            }
            this.ActiveControl = btnBugVirgula;
        }

        private void btnDois_Click(object sender, EventArgs e)
        {
            //Realizando nova operação após receber uma divisão por zero
            if (txtResultado.Text == "Indeterminado." || txtResultado.Text == "Não é possível dividir por zero.")
            {
                txtResultado.Font = new Font("Arial", 30.0F);
                btnC_Click(sender, e);
            }

            //Inicializando a calculadora com o zero, mas retirando ao digitar o primeiro número
            if (txtResultado.Text == "0" && txtResultado.Text.Length == 1)
            {
                txtResultado.Text = "2";
            }
            else
            {
                txtResultado.Text += "2";
            }

            this.ActiveControl = btnBugVirgula;
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            //Realizando nova operação após receber uma divisão por zero
            if (txtResultado.Text == "Indeterminado." || txtResultado.Text == "Não é possível dividir por zero.")
            {
                txtResultado.Font = new Font("Arial", 30.0F);
                btnC_Click(sender, e);
            }

            //Inicializando a calculadora com o zero, mas retirando ao digitar o primeiro número
            if (txtResultado.Text == "0" && txtResultado.Text.Length == 1)
            {
                txtResultado.Text = "3";
            }
            else
            {
                txtResultado.Text += "3";
            }

            this.ActiveControl = btnBugVirgula;
        }

        private void btnQuatro_Click(object sender, EventArgs e)
        {
            //Realizando nova operação após receber uma divisão por zero
            if (txtResultado.Text == "Indeterminado." || txtResultado.Text == "Não é possível dividir por zero.")
            {
                txtResultado.Font = new Font("Arial", 30.0F);
                btnC_Click(sender, e);
            }

            //Inicializando a calculadora com o zero, mas retirando ao digitar o primeiro número
            if (txtResultado.Text == "0" && txtResultado.Text.Length == 1)
            {
                txtResultado.Text = "4";
            }
            else
            {
                txtResultado.Text += "4";
            }

            this.ActiveControl = btnBugVirgula;
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            //Realizando nova operação após receber uma divisão por zero
            if (txtResultado.Text == "Indeterminado." || txtResultado.Text == "Não é possível dividir por zero.")
            {
                txtResultado.Font = new Font("Arial", 30.0F);
                btnC_Click(sender, e);
            }

            //Inicializando a calculadora com o zero, mas retirando ao digitar o primeiro número
            if (txtResultado.Text == "0" && txtResultado.Text.Length == 1)
            {
                txtResultado.Text = "5";
            }
            else
            {
                txtResultado.Text += "5";
            }

            this.ActiveControl = btnBugVirgula;
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            //Realizando nova operação após receber uma divisão por zero
            if (txtResultado.Text == "Indeterminado." || txtResultado.Text == "Não é possível dividir por zero.")
            {
                txtResultado.Font = new Font("Arial", 30.0F);
                btnC_Click(sender, e);
            }

            //Inicializando a calculadora com o zero, mas retirando ao digitar o primeiro número
            if (txtResultado.Text == "0" && txtResultado.Text.Length == 1)
            {
                txtResultado.Text = "6";
            }
            else
            {
                txtResultado.Text += "6";
            }

            this.ActiveControl = btnBugVirgula;
        }

        private void btnSete_Click(object sender, EventArgs e)
        {
            //Realizando nova operação após receber uma divisão por zero
            if (txtResultado.Text == "Indeterminado." || txtResultado.Text == "Não é possível dividir por zero.")
            {
                txtResultado.Font = new Font("Arial", 30.0F);
                btnC_Click(sender, e);
            }

            //Inicializando a calculadora com o zero, mas retirando ao digitar o primeiro número
            if (txtResultado.Text == "0" && txtResultado.Text.Length == 1)
            {
                txtResultado.Text = "7";
            }
            else
            {
                txtResultado.Text += "7";
            }

            this.ActiveControl = btnBugVirgula;
        }

        private void btnOito_Click(object sender, EventArgs e)
        {
            //Realizando nova operação após receber uma divisão por zero
            if (txtResultado.Text == "Indeterminado." || txtResultado.Text == "Não é possível dividir por zero.")
            {
                txtResultado.Font = new Font("Arial", 30.0F);
                btnC_Click(sender, e);
            }

            //Inicializando a calculadora com o zero, mas retirando ao digitar o primeiro número
            if (txtResultado.Text == "0" && txtResultado.Text.Length == 1)
            {
                txtResultado.Text = "8";
            }
            else
            {
                txtResultado.Text += "8";
            }

            this.ActiveControl = btnBugVirgula;
        }

        private void btnNove_Click(object sender, EventArgs e)
        {
            //Realizando nova operação após receber uma divisão por zero
            if (txtResultado.Text == "Indeterminado." || txtResultado.Text == "Não é possível dividir por zero.")
            {
                txtResultado.Font = new Font("Arial", 30.0F);
                btnC_Click(sender, e);
            }

            //Inicializando a calculadora com o zero, mas retirando ao digitar o primeiro número
            if (txtResultado.Text == "0" && txtResultado.Text.Length == 1)
            {
                txtResultado.Text = "9";
            }
            else
            {
                txtResultado.Text += "9";
            }

            this.ActiveControl = btnBugVirgula;
        }

        /*------------------------ DEFINIÇÃO DOS BOTÕES OPERADORES NA MINHA CALCULADORA E SUAS REGRAS -----------------------*/
        private void btnAdicao_Click(object sender, EventArgs e)
        {
            //Realizando nova operação após receber uma divisão por zero
            if (txtResultado.Text == "Indeterminado." || txtResultado.Text == "Não é possível dividir por zero.")
            {
                txtResultado.Font = new Font("Arial", 30.0F);
                btnC_Click(sender, e);
            }

            //Tratando caso o usuário aperte um operador sem números precedentes
            if (txtResultado.Text.Length == 0)
            {
                txtOperador.Text = c.Num1 + "+" + Convert.ToString(txtResultado.Text);
                OperacaoSelecionada = Operacao.Adicao;
            }
            else
            {
                //Tratando caso seja uma operação normal
                OperacaoSelecionada = Operacao.Adicao;
                c.Num1 = Convert.ToDouble(txtResultado.Text);
                txtOperador.Text = c.Num1 + "+";
            }

            txtResultado.Text = V;
            this.ActiveControl = btnBugVirgula;
        }

        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            //Realizando nova operação após receber uma divisão por zero
            if (txtResultado.Text == "Indeterminado." || txtResultado.Text == "Não é possível dividir por zero.")
            {
                txtResultado.Font = new Font("Arial", 30.0F);
                btnC_Click(sender, e);
            }

            //Tratando caso o usuário aperte um operador sem números precedentes
            if (txtResultado.Text.Length == 0)
            {
                txtOperador.Text = c.Num1 + "-" + Convert.ToString(txtResultado.Text);
                OperacaoSelecionada = Operacao.Subtracao;
            }
            else
            {
                //Tratando caso seja uma operação normal
                OperacaoSelecionada = Operacao.Subtracao;
                c.Num1 = Convert.ToDouble(txtResultado.Text);
                txtOperador.Text = c.Num1 + "-";
            }

            txtResultado.Text = V;
            this.ActiveControl = btnBugVirgula;
        }

        private void btnMultiplicacao_Click(object sender, EventArgs e)
        {
            //Realizando nova operação após receber uma divisão por zero
            if (txtResultado.Text == "Indeterminado." || txtResultado.Text == "Não é possível dividir por zero.")
            {
                txtResultado.Font = new Font("Arial", 30.0F);
                btnC_Click(sender, e);
            }

            //Tratando caso o usuário aperte um operador sem números precedentes
            if (txtResultado.Text.Length == 0)
            {
                txtOperador.Text = c.Num1 + "*" + Convert.ToString(txtResultado.Text);
                OperacaoSelecionada = Operacao.Multiplicacao;
            }
            else
            {
                //Tratando caso seja uma operação normal
                OperacaoSelecionada = Operacao.Multiplicacao;
                c.Num1 = Convert.ToDouble(txtResultado.Text);
                txtOperador.Text = c.Num1 + "*";
            }

            txtResultado.Text = V;
            this.ActiveControl = btnBugVirgula;
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            //Realizando nova operação após receber uma divisão por zero
            if (txtResultado.Text == "Indeterminado." || txtResultado.Text == "Não é possível dividir por zero.")
            {
                txtResultado.Font = new Font("Arial", 30.0F);
                btnC_Click(sender, e);
            }

            //Tratando caso o usuário aperte um operador sem números precedentes
            if (txtResultado.Text.Length == 0)
            {
                txtOperador.Text = c.Num1 + "/" + Convert.ToString(txtResultado.Text);
                OperacaoSelecionada = Operacao.Divisao;
            }
            else
            {
                //Tratando caso seja uma operação normal
                OperacaoSelecionada = Operacao.Divisao;
                c.Num1 = Convert.ToDouble(txtResultado.Text);
                txtOperador.Text = c.Num1 + "/";
            }

            txtResultado.Text = V;
            this.ActiveControl = btnBugVirgula;
        }

        /*------------------------ DEFINIÇÃO DO BOTÃO DA VIRGULA NA MINHA CALCULADORA E SUAS REGRAS -----------------------*/

        private void btnVirgula_Click(object sender, EventArgs e)
        {
            //Vírgula irá zerar a operação:
            if ((txtOperador.Text == c.Num2 + "+" + c.Num1 && txtResultado.Text.Length > 0) || (txtOperador.Text == c.Num2 + "-" + c.Num1 && txtResultado.Text.Length > 0)
            || (txtOperador.Text == c.Num2 + "*" + c.Num1 && txtResultado.Text.Length > 0) || (txtOperador.Text == c.Num2 + "/" + c.Num1 && txtResultado.Text.Length > 0))
            {
                btnC_Click(sender, e);
                txtResultado.Text = "0,";
            }

            if (!txtResultado.Text.Contains(","))
            {
                if (txtResultado.Text.Length == 0)
                {
                    txtResultado.Text = "0,";
                }
                else
                {
                    txtResultado.Text += ",";
                }
            }
            this.ActiveControl = btnBugVirgula;
        }

        /*------------------------ DEFINIÇÃO DO BOTÃO DE IGUALDADE NA MINHA CALCULADORA E SUAS REGRAS -----------------------*/
        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (txtOperador.Text.Length == 0 && txtResultado.Text == "0")
            {
                OperacaoSelecionada = Operacao.Igual;
            }

            switch (OperacaoSelecionada)
            {
                //Tratando caso o usuário aperte um operador sem números precedentes
                case Operacao.Igual:
                    c.Num1 = Convert.ToDouble(txtResultado.Text);
                    txtOperador.Text = c.Num1 + "=";
                    return;

                case Operacao.Adicao:
                    try
                    {
                        //Operação natural, já formatando os números com vírgula e "." divisórios
                        c.Num2 = Convert.ToDouble(txtResultado.Text);
                        auxResult = c.Adicao();
                        txtOperador.Text = Convert.ToString(c.Num2 + "+" + c.Num1);
                    }
                    catch
                    {
                        //Tratando caso o usuário aperte apenas o operador de adição sem números precedentes
                        txtOperador.Text = c.Num1 + "=";
                        txtResultado.Text = Convert.ToString(c.Num1);
                        return;
                    }

                    break;

                case Operacao.Subtracao:
                    try
                    {
                        //Operação natural, já formatando os números com vírgula e "." divisórios
                        c.Num2 = Convert.ToDouble(txtResultado.Text);
                        auxResult = c.Subtracao();
                        txtOperador.Text = Convert.ToString(c.Num2 + "-" + c.Num1);

                    }
                    catch
                    {
                        //Tratando caso o usuário aperte apenas o operador de adição sem números precedentes
                        txtOperador.Text = c.Num1 + "=";
                        txtResultado.Text = Convert.ToString(c.Num1);
                        return;
                    }
                    break;

                case Operacao.Multiplicacao:
                    try
                    {
                        //Operação natural, já formatando os números com vírgula e "." divisórios
                        c.Num2 = Convert.ToDouble(txtResultado.Text);
                        auxResult = c.Multiplicacao();
                        txtOperador.Text = Convert.ToString(c.Num2 + "*" + c.Num1);
                    }
                    catch
                    {
                        //Tratando caso o usuário aperte apenas o operador de adição sem números precedentes
                        txtOperador.Text = c.Num1 + "=";
                        txtResultado.Text = Convert.ToString(c.Num1);
                        return;
                    }
                    break;

                case Operacao.Divisao:
                    try
                    {
                        //Operação natural, já formatando os números com vírgula e "." divisórios
                        c.Num2 = Convert.ToDouble(txtResultado.Text);

                        if (c.Num1 == 0 && c.Num2 == 0)
                        {
                            txtOperador.Text = c.Num2 + "/" + c.Num1;
                            txtResultado.Font = new Font("Arial", 20.0F);
                            txtResultado.Text = "Indeterminado.";
                            return;
                        }
                        else if (c.Num2 == 0)
                        {
                            txtOperador.Text = c.Num2 + "/" + c.Num1;
                            txtResultado.Font = new Font("Arial", 16.0F);
                            txtResultado.Text = "Não é possível dividir por zero.";
                            return;
                        }

                        auxResult = c.Divisao();
                        txtOperador.Text = Convert.ToString(c.Num1 + "/" + c.Num2);
                    }
                    catch
                    {
                        //Tratando caso o usuário aperte apenas o operador de adição sem números precedentes
                        txtOperador.Text = c.Num1 + "=";
                        txtResultado.Text = Convert.ToString(c.Num1);
                        return;
                    }
                    break;
            }

            //Mostrando o resultado para o usuário e já formatando com os "." divisórios
            if (auxResult <= 10)
            {
                if (Convert.ToString(auxResult).Contains(","))
                {
                    txtResultado.Text = Convert.ToString(auxResult);
                }
                else
                {
                    txtResultado.Text = String.Format(@"{0:,0}", auxResult);
                }
            }
            else
            {
                if (Convert.ToString(auxResult).Contains(","))
                {
                    txtResultado.Text = Convert.ToString(auxResult);
                }
                else
                {
                    txtResultado.Text = String.Format(@"{0:0,0}", auxResult);
                }
            }
            this.ActiveControl = btnBugVirgula;
        }

        /*------------------------ DEFINIÇÃO DOS BOTÕES DE DELETAR NA MINHA CALCULADORA E SUAS REGRAS -----------------------*/
        private void btnBackspace_Click(object sender, EventArgs e)
        {
            char[] arr = txtResultado.Text.ToCharArray();

            string txt = V;

            int tamanho = arr.Length;

            for (int i = 0; i < arr.Length; i++)
            {
                if (i + 1 != tamanho)
                {
                    txt += arr[i].ToString();
                }
            }

            txtResultado.Text = txt;

            //Após apagar todo o txtbox, colocar o valor 0 inicial na calculadora novamente
            if (txtResultado.Text.Length == 0)
            {
                txtResultado.Text = "0";
            }

            this.ActiveControl = btnBugVirgula;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtResultado.Clear();
            txtOperador.Clear();
            c.Num1 = 0;
            c.Num2 = 0;
            txtResultado.Text = "0";
            this.ActiveControl = btnBugVirgula;
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            if ((txtOperador.Text == c.Num1 + "+" + c.Num2 && txtResultado.Text.Length > 0) || (txtOperador.Text == c.Num1 + "-" + c.Num2 && txtResultado.Text.Length > 0)
            || (txtOperador.Text == c.Num1 + "*" + c.Num2 && txtResultado.Text.Length > 0) || (txtOperador.Text == c.Num1 + "/" + c.Num2 && txtResultado.Text.Length > 0))
            {
                btnC_Click(sender, e);
            } else
            {
                txtResultado.Clear();
                c.Num2 = 0;
            }

            this.ActiveControl = btnBugVirgula;
        }

        /*------------------------- BLOQUEANDO A OPÇÃO DE FECHAR QUANDO DER DOIS CLIQUES NO ICONE -------------------------*/
        private void Calculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            Size iconSize = new Size(32, 32);
            Rectangle R = new Rectangle(this.Location, iconSize);
            if (R.Contains(Cursor.Position) && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }
    }
}