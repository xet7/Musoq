﻿using System;
using Musoq.Parser;
using Musoq.Parser.Nodes;

namespace Musoq.Evaluator.Visitors
{
    public class CollectColumnsBySchemasTraverseVisitor : IExpressionVisitor
    {
        private readonly ICollectColumnsBySchemasAwareVisitor _visitor;

        public CollectColumnsBySchemasTraverseVisitor(ICollectColumnsBySchemasAwareVisitor visitor)
        {
            _visitor = visitor ?? throw new ArgumentNullException(nameof(visitor));
        }

        public void Visit(SelectNode node)
        {
            _visitor.SetQueryPart(QueryPart.Select);
            foreach (var field in node.Fields)
                field.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(StringNode node)
        {
            node.Accept(_visitor);
        }

        public void Visit(IntegerNode node)
        {
            node.Accept(_visitor);
        }

        public void Visit(WordNode node)
        {
            node.Accept(_visitor);
        }

        public void Visit(ContainsNode node)
        {
            node.Left.Accept(this);
            node.Right.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(AccessMethodNode node)
        {
            foreach (var item in node.Arguments.Args)
                item.Accept(this);

            node.Accept(_visitor);
        }

        public void Visit(GroupByAccessMethodNode node)
        {
            node.Arguments.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(AccessRefreshAggreationScoreNode node)
        {
            node.Arguments.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(AccessColumnNode node)
        {
            node.Accept(_visitor);
        }

        public void Visit(AllColumnsNode node)
        {
            node.Accept(_visitor);
        }

        public void Visit(AccessObjectArrayNode node)
        {
            node.Accept(_visitor);
        }

        public void Visit(AccessObjectKeyNode node)
        {
            node.Accept(_visitor);
        }

        public void Visit(PropertyValueNode node)
        {
            node.Accept(_visitor);
        }

        public void Visit(DotNode node)
        {
            node.Expression.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(AccessCallChainNode node)
        {
            node.Accept(_visitor);
        }

        public virtual void Visit(WhereNode node)
        {
            _visitor.SetQueryPart(QueryPart.Where);
            node.Expression.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(TakeNode node)
        {
            node.Accept(_visitor);
        }

        public void Visit(ExistingTableFromNode node)
        {
            _visitor.SetQueryPart(QueryPart.From);
            node.Accept(_visitor);
        }

        public void Visit(SchemaFromNode node)
        {
            _visitor.SetQueryPart(QueryPart.From);
            node.Accept(_visitor);
        }

        public void Visit(NestedQueryFromNode node)
        {
            _visitor.SetQueryPart(QueryPart.From);
            node.Query.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(CteFromNode node)
        {
            _visitor.SetQueryPart(QueryPart.From);
            node.Accept(_visitor);
        }

        public void Visit(JoinFromNode node)
        {
            _visitor.SetQueryPart(QueryPart.From);
            node.Source.Accept(this);
            node.With.Accept(this);
            node.Expression.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(CreateTableNode node)
        {
            node.Accept(_visitor);
        }

        public void Visit(RenameTableNode node)
        {
            node.Accept(_visitor);
        }

        public void Visit(TranslatedSetTreeNode node)
        {
            foreach (var item in node.Nodes)
                item.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(IntoNode node)
        {
            node.Accept(_visitor);
        }

        public void Visit(IntoGroupNode node)
        {
            node.Accept(_visitor);
        }

        public void Visit(ShouldBePresentInTheTable node)
        {
            node.Accept(_visitor);
        }

        public void Visit(TranslatedSetOperatorNode node)
        {
            for (int i = node.CreateTableNodes.Length - 1; i >= 0; i--)
                node.CreateTableNodes[i].Accept(_visitor);

            node.FQuery.Accept(this);
            node.SQuery.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(QueryNode node)
        {
            _visitor.SetQueryStarts();
            _visitor.SetJoiningTablesPossible();
            node.From.Accept(this);
            node.Joins.Accept(this);
            _visitor.UnsetJoiningTablesPossible();
            node.Where.Accept(this);
            node.GroupBy?.Accept(this);
            node.GroupBy?.Having?.Accept(this);
            node.Select.Accept(this);
            node.Accept(_visitor);
            _visitor.UnsetQueryStarts();
        }

        public void Visit(OrNode node)
        {
            node.Left.Accept(this);
            node.Right.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(ShortCircuitingNodeLeft node)
        {
            node.Expression.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(ShortCircuitingNodeRight node)
        {
            node.Expression.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(HyphenNode node)
        {
            node.Left.Accept(this);
            node.Right.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(AndNode node)
        {
            node.Left.Accept(this);
            node.Right.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(EqualityNode node)
        {
            node.Left.Accept(this);
            node.Right.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(GreaterOrEqualNode node)
        {
            node.Left.Accept(this);
            node.Right.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(LessOrEqualNode node)
        {
            node.Left.Accept(this);
            node.Right.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(GreaterNode node)
        {
            node.Left.Accept(this);
            node.Right.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(LessNode node)
        {
            node.Left.Accept(this);
            node.Right.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(DiffNode node)
        {
            node.Left.Accept(this);
            node.Right.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(NotNode node)
        {
            node.Expression.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(LikeNode node)
        {
            node.Left.Accept(this);
            node.Right.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(FieldNode node)
        {
            node.Expression.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(ArgsListNode node)
        {
            foreach (var item in node.Args)
                item.Accept(this);
            node.Accept(_visitor);
        }

        /// <summary>
        ///     Visit Numeric node.
        /// </summary>
        /// <param name="node">Numeric node that will be visited.</param>
        public void Visit(DecimalNode node)
        {
            node.Accept(_visitor);
        }

        public void Visit(Node node)
        {
            throw new NotImplementedException();
        }

        public void Visit(DescNode node)
        {
            node.Accept(_visitor);
            node.From.Accept(this);
        }

        public void Visit(StarNode node)
        {
            node.Left.Accept(this);
            node.Right.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(FSlashNode node)
        {
            node.Left.Accept(this);
            node.Right.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(ModuloNode node)
        {
            node.Left.Accept(this);
            node.Right.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(AddNode node)
        {
            node.Left.Accept(this);
            node.Right.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(InternalQueryNode node)
        {
            node.From.Accept(this);
            node.Where.Accept(this);
            node.GroupBy?.Accept(this);
            node.Refresh?.Accept(this);
            node.GroupBy?.Having?.Accept(this);
            node.Select?.Accept(this);
            node.Into?.Accept(_visitor);
            node.ShouldBePresent?.Accept(_visitor);
            node.Accept(_visitor);
        }

        public void Visit(RootNode node)
        {
            node.Expression.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(SingleSetNode node)
        {
            node.Accept(_visitor);
            node.Query.Accept(this);
        }

        public void Visit(UnionNode node)
        {
            _visitor.SetInsideSetOperator();
            node.Left.Accept(this);
            node.Right.Accept(this);
            node.Accept(_visitor);
            _visitor.UnsetInsideSetOperator();
        }

        public void Visit(UnionAllNode node)
        {
            _visitor.SetInsideSetOperator();
            node.Left.Accept(this);
            node.Right.Accept(this);
            node.Accept(_visitor);
            _visitor.UnsetInsideSetOperator();
        }

        public void Visit(ExceptNode node)
        {
            _visitor.SetInsideSetOperator();
            node.Left.Accept(this);
            node.Right.Accept(this);
            node.Accept(_visitor);
            _visitor.UnsetInsideSetOperator();
        }

        public void Visit(RefreshNode node)
        {
            foreach (var item in node.Nodes)
                item.Accept(this);

            node.Accept(_visitor);
        }

        public void Visit(IntersectNode node)
        {
            _visitor.SetInsideSetOperator();
            node.Left.Accept(this);
            node.Right.Accept(this);
            node.Accept(_visitor);
            _visitor.UnsetInsideSetOperator();
        }

        public void Visit(PutTrueNode node)
        {
            node.Accept(_visitor);
        }

        public void Visit(MultiStatementNode node)
        {
            foreach (var cNode in node.Nodes)
                cNode.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(CteExpressionNode node)
        {
            _visitor.SetInsideCte();
            foreach (var exp in node.InnerExpression)
            {
                _visitor.IsInsideInnerCte(exp.Name);
                exp.Accept(this);
                _visitor.IsOutsideInnerCte(exp.Name);
            }
            node.Accept(_visitor);
            node.OuterExpression.Accept(this);
            _visitor.UnsetInsideCte();
        }

        public void Visit(CteInnerExpressionNode node)
        {
            node.Value.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(JoinsNode node)
        {
            foreach (var item in node.Joins)
                item.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(JoinNode node)
        {
            node.From.Accept(this);
            node.Expression.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(GroupByNode node)
        {
            _visitor.SetQueryPart(QueryPart.GroupBy);
            foreach (var field in node.Fields)
                field.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(HavingNode node)
        {
            _visitor.SetQueryPart(QueryPart.Having);
            node.Expression.Accept(this);
            node.Accept(_visitor);
        }

        public void Visit(SkipNode node)
        {
            node.Accept(_visitor);
        }
    }
}