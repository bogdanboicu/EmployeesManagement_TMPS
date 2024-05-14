using System.Text;

namespace EmployeesManagement.DataAccess.Queries;

public class EmployeeQueryBuilder
{
    // The Director class, responsible for constructing the query
   
        private readonly List<string> _selectedColumns;
        private string _tableName;
        private string _whereClause;
        private string _orderByColumn;
        private int _limit;

        public EmployeeQueryBuilder()
        {
            _selectedColumns = new List<string>();
        }

        public EmployeeQueryBuilder Select(params string[] columns)
        {
            _selectedColumns.AddRange(columns);
            return this;
        }

        public EmployeeQueryBuilder From(string tableName)
        {
            _tableName = tableName;
            return this;
        }

        public EmployeeQueryBuilder Where(string condition)
        {
            _whereClause = condition;
            return this;
        }

        public EmployeeQueryBuilder OrderBy(string column)
        {
            _orderByColumn = column;
            return this;
        }

        public EmployeeQueryBuilder Limit(int limit)
        {
            _limit = limit;
            return this;
        }

        public string GetQuery()
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT ");
            queryBuilder.Append(string.Join(", ", _selectedColumns));
            queryBuilder.Append(" FROM ");
            queryBuilder.Append(_tableName);
            if (!string.IsNullOrEmpty(_whereClause))
            {
                queryBuilder.Append(" WHERE ");
                queryBuilder.Append(_whereClause);
            }
            if (!string.IsNullOrEmpty(_orderByColumn))
            {
                queryBuilder.Append(" ORDER BY ");
                queryBuilder.Append(_orderByColumn);
            }
            if (_limit > 0)
            {
                queryBuilder.Append(" LIMIT ");
                queryBuilder.Append(_limit);
            }
            return queryBuilder.ToString();
        }
        
    }
