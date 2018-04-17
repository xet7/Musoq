﻿namespace Musoq.Parser.Nodes
{
    public class InnerJoinNode : JoinNode
    {
        public InnerJoinNode(FromNode from, Node expression) 
            : base(from, expression)
        {
            Id = CalculateId(this);
        }

        public override void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string Id { get; }

        public override string ToString()
        {
            return $"inner join {Left.ToString()} on {Right.ToString()}";
        }
    }
}