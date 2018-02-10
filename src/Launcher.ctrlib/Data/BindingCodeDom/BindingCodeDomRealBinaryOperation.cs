using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yandere;

namespace Launcher.Data.BindingCodeDom
{
    public enum RealBinaryOperator
    {
        Add,
        Subtract,
        Multiply,
        Divide,
        //DivideRem,
        Power,
        Log
    }

    public class BindingCodeDomRealBinaryOperation : BindingCodeDomSpecificBinaryOperation<double, double>
    {
        private ValueBox<RealBinaryOperator> operatorBox = ValueBox<RealBinaryOperator>.NonValue;
        public RealBinaryOperator Operator
        {
            get => this.operatorBox.Value;
            set => this.operatorBox.Value = value;
        }

        protected override double ConvertLeft(object value) =>
            Convert.ToDouble(value ?? throw new ArgumentNullException(nameof(value)));

        protected override double ConvertRight(object value) =>
            Convert.ToDouble(value ?? throw new ArgumentNullException(nameof(value)));

        protected override object SpecificCalculationImplementation(double left, double right)
        {
            try
            {
                switch (this.Operator)
                {
                    case RealBinaryOperator.Add:
                        return left + right;
                    case RealBinaryOperator.Subtract:
                        return left - right;
                    case RealBinaryOperator.Multiply:
                        return left * right;
                    case RealBinaryOperator.Divide:
                        return left / right;
                    case RealBinaryOperator.Power:
                        return Math.Pow(left, right);
                    case RealBinaryOperator.Log:
                        return Math.Log(left, right);
                    default:
                        throw new NotSupportedException("不支持的运算符。");
                }
            }
            catch (Exception e)
            {
                throw new NotSupportedException("不支持的浮点数二元运算。", e);
            }
        }
    }
}
