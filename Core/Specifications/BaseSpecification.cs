using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecifications<T>
    {
        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {

            Criteria = criteria;
        }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, bool>> Criteria { get; }

        public Expression<Func<T, object>> Orderby { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        protected void AddOrderby(Expression<Func<T, object>> OrderbyExpression)
        {
            Orderby = OrderbyExpression;
        }
        protected void AddOrderbyDescending(Expression<Func<T, object>> OrderbyDescExpression)
        {
            OrderByDescending = OrderbyDescExpression;
        }
        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}