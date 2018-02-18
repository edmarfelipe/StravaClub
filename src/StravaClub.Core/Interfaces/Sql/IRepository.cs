using System.Collections.Generic;

namespace StravaClub.Core.Interfaces.Sql
{
	public interface IRepository<TEntity> where TEntity : class
	{
		int Insert(TEntity entity);

		bool Update(TEntity entity);

		bool Delete(TEntity entity);

		TEntity Get(long id);

		IEnumerable<TEntity> GetAll();

		IEnumerable<TReturn> Query<TReturn>(string sql, object param = null);

		TReturn QueryFirstOrDefault<TReturn>(string sql, object param = null);
	}
}
