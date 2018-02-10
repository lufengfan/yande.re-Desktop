using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yandere;

namespace Launcher.Data.BindingCodeDom
{
    public enum LogicalBinaryOperator
    {
        Equality,
        Inequality,
        Add,
        BooleanAdd,
        Or,
        BooleanOr,
        Xor,
        Xnor
    }
    
    public class BindingCodeDomLogicalBinaryOperation : BindingCodeDomSpecificBinaryOperation<bool, bool>
    {
        private ValueBox<LogicalBinaryOperator> operatorBox = ValueBox<LogicalBinaryOperator>.NonValue;
        public virtual LogicalBinaryOperator Operator
        {
            get => this.operatorBox.Value;
            set => this.operatorBox.Value = value;
        }

        public BindingCodeDomLogicalBinaryOperation() { }

        protected BindingCodeDomLogicalBinaryOperation(LogicalBinaryOperator _operator)
        {
            if (!Enum.IsDefined(typeof(LogicalBinaryOperator), _operator))
                throw new ArgumentOutOfRangeException(nameof(_operator), _operator, "不支持的操作符枚举值。");

            this.operatorBox.Value = _operator;
        }

        protected override bool ConvertLeft(object value) => (bool)value;

        protected override bool ConvertRight(object value) => (bool)value;

        protected override object SpecificCalculationImplementation(bool left, bool right)
        {
            try
            {
                switch (this.Operator)
                {
                    case LogicalBinaryOperator.Equality:
                        return left == right;
                    case LogicalBinaryOperator.Inequality:
                        return left != right;
                    case LogicalBinaryOperator.Add:
                        return left & right;
                    case LogicalBinaryOperator.BooleanAdd:
                        return left && right;
                    case LogicalBinaryOperator.Or:
                        return left | right;
                    case LogicalBinaryOperator.BooleanOr:
                        return left || right;
                    case LogicalBinaryOperator.Xor:
                        return left ^ right;
                    case LogicalBinaryOperator.Xnor:
                        return !(left ^ right);
                    default:
                        throw new NotSupportedException("不支持的运算符。");
                }
            }
            catch (Exception e)
            {
                throw new NotSupportedException("不支持的逻辑二元运算。", e);
            }
        }
    }

    public abstract class KnownBindingCodeDomLogicalBinaryOperation : BindingCodeDomLogicalBinaryOperation
    {
        public sealed override LogicalBinaryOperator Operator
        {
            get => base.Operator;
            set => throw new ArgumentNullException(nameof(value));
        }

        protected KnownBindingCodeDomLogicalBinaryOperation(LogicalBinaryOperator _operator) : base(_operator) { }
    }

    public sealed class BindingCodeDomEqualityLogicalBinaryOperation : KnownBindingCodeDomLogicalBinaryOperation
    {
        public BindingCodeDomEqualityLogicalBinaryOperation() : base(LogicalBinaryOperator.Equality) { }
    }

    public sealed class BindingCodeDomInequalityLogicalBinaryOperation : KnownBindingCodeDomLogicalBinaryOperation
    {
        public BindingCodeDomInequalityLogicalBinaryOperation() : base(LogicalBinaryOperator.Inequality) { }
    }

    public sealed class BindingCodeDomAddLogicalBinaryOperation : KnownBindingCodeDomLogicalBinaryOperation
    {
        public BindingCodeDomAddLogicalBinaryOperation() : base(LogicalBinaryOperator.Add) { }
    }

    public sealed class BindingCodeDomBooleanAddLogicalBinaryOperation : KnownBindingCodeDomLogicalBinaryOperation
    {
        public BindingCodeDomBooleanAddLogicalBinaryOperation() : base(LogicalBinaryOperator.BooleanAdd) { }
    }

    public sealed class BindingCodeDomOrLogicalBinaryOperation : KnownBindingCodeDomLogicalBinaryOperation
    {
        public BindingCodeDomOrLogicalBinaryOperation() : base(LogicalBinaryOperator.Or) { }
    }

    public sealed class BindingCodeDomBooleanOrLogicalBinaryOperation : KnownBindingCodeDomLogicalBinaryOperation
    {
        public BindingCodeDomBooleanOrLogicalBinaryOperation() : base(LogicalBinaryOperator.BooleanOr) { }
    }

    public sealed class BindingCodeDomXorLogicalBinaryOperation : KnownBindingCodeDomLogicalBinaryOperation
    {
        public BindingCodeDomXorLogicalBinaryOperation() : base(LogicalBinaryOperator.Xor) { }
    }

    public sealed class BindingCodeDomXnorLogicalBinaryOperation : KnownBindingCodeDomLogicalBinaryOperation
    {
        public BindingCodeDomXnorLogicalBinaryOperation() : base(LogicalBinaryOperator.Xnor) { }
    }
}
