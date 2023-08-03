using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wolt.Entities.Entities.BaseEntities;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WOLT.DAL.DATA.ForBaseEntity
{
    internal static class BaseQueries
    {
        public static void IgnoreDeleted(this ModelBuilder modelBuilder)
        {

            Expression<Func<BaseEntity, bool>> filterExpr = bm => !bm.IsDeleted;
            foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes())
            {
                
                if (mutableEntityType.ClrType.IsAssignableTo(typeof(BaseEntity)))
                {
                    
                    var parameter = Expression.Parameter(mutableEntityType.ClrType);
                    var body = ReplacingExpressionVisitor.Replace(filterExpr.Parameters.First(), parameter, filterExpr.Body);
                    var lambdaExpression = Expression.Lambda(body, parameter);

                   
                    mutableEntityType.SetQueryFilter(lambdaExpression);
                }
            }
        }
    }
}
             

   
