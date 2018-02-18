using System;
using System.Collections.Generic;
using System.Data.Common;
using Dapper;
using DapperExtensions;
using DapperExtensions.Sql;
using Microsoft.Data.Sqlite;
using StravaClub.Core.Interfaces;
using StravaClub.Core.Interfaces.Sql;

namespace StravaClub.Core.Infra.Sql
{
	public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		private readonly IAppSettings _appSettings;

		public BaseRepository(IAppSettings appSettings) 
		{
			_appSettings = appSettings;
			DapperExtensions.DapperExtensions.SqlDialect = new SqliteDialect();
		}

		private DbConnection GetDefaultConnection()
		{
			if (string.IsNullOrEmpty(_appSettings.DatabaseConnectionString))
			{
				throw new ArgumentNullException("DatabaseConnectionString");
			}

			return new SqliteConnection(_appSettings.DatabaseConnectionString);
		}

		public int Insert(TEntity entity)
		{
			using (var conn = GetDefaultConnection())
			{
				return conn.Insert(entity);
			}
		}

		public bool Update(TEntity entity)
		{
			using (var conn = GetDefaultConnection())
			{
				return conn.Update(entity);
			}
		}

		public bool Delete(TEntity entity)
		{
			using (var conn = GetDefaultConnection())
			{
				return conn.Delete(entity);
			}
		}

		public TEntity Get(long id)
		{
			using (var conn = GetDefaultConnection())
			{
				return conn.Get<TEntity>(id);
			}
		}

		public IEnumerable<TEntity> GetAll()
		{
			using (var conn = GetDefaultConnection())
			{
				return conn.GetList<TEntity>();
			}
		}

		public IEnumerable<TReturn> Query<TReturn>(string sql, object param = null)
		{
			using (var conn = GetDefaultConnection())
			{
				return conn.Query<TReturn>(sql, param);
			}
		}

		public TReturn QueryFirstOrDefault<TReturn>(string sql, object param = null)
		{
			using (var conn = GetDefaultConnection())
			{
				return conn.QueryFirstOrDefault<TReturn>(sql, param);
			}
		}
	}
}
