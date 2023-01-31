using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Calculos
    {
        //Atributos da classe:
        private double _num1;
        private double _num2;

        //Construtor vazio:
        public Calculos()
        {
        }

        //Construtor para receber um cálculo básico:
        public Calculos(double num1, double num2)
        {
            _num1 = num1;
            _num2 = num2;
        }

        //Propriedades com o GET/SET:
        public double Num1
        {
            get { return _num1; }
            set { _num1 = value; }
        }

        public double Num2
        {
            get { return _num2; }
            set { _num2 = value; }
        }

        //Métodos da classe:
        public double Adicao()
        {
            return _num1 + _num2;
        }

        public double Subtracao()
        {
            return _num1 - _num2;
        }

        public double Multiplicacao()
        {
            return _num1 * _num2;
        }

        public double Divisao()
        {
            return _num1 / _num2;
        }
    }
}
