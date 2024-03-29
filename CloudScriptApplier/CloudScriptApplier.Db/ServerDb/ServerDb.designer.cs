﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CloudScriptApplier.Db.ServerDb
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="CloudScriptApplier")]
	public partial class ServerDbDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertDatabase(Database instance);
    partial void UpdateDatabase(Database instance);
    partial void DeleteDatabase(Database instance);
    partial void InsertDatabasesType(DatabasesType instance);
    partial void UpdateDatabasesType(DatabasesType instance);
    partial void DeleteDatabasesType(DatabasesType instance);
    partial void InsertLogHistoryType(LogHistoryType instance);
    partial void UpdateLogHistoryType(LogHistoryType instance);
    partial void DeleteLogHistoryType(LogHistoryType instance);
    partial void InsertLogHistory(LogHistory instance);
    partial void UpdateLogHistory(LogHistory instance);
    partial void DeleteLogHistory(LogHistory instance);
    partial void InsertScript(Script instance);
    partial void UpdateScript(Script instance);
    partial void DeleteScript(Script instance);
    #endregion
		
		public ServerDbDataContext() : 
				base(global::CloudScriptApplier.Db.Properties.Settings.Default.CloudScriptApplierConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ServerDbDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ServerDbDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ServerDbDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ServerDbDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Database> Databases
		{
			get
			{
				return this.GetTable<Database>();
			}
		}
		
		public System.Data.Linq.Table<DatabasesType> DatabasesTypes
		{
			get
			{
				return this.GetTable<DatabasesType>();
			}
		}
		
		public System.Data.Linq.Table<LogHistoryType> LogHistoryTypes
		{
			get
			{
				return this.GetTable<LogHistoryType>();
			}
		}
		
		public System.Data.Linq.Table<LogHistory> LogHistories
		{
			get
			{
				return this.GetTable<LogHistory>();
			}
		}
		
		public System.Data.Linq.Table<Script> Scripts
		{
			get
			{
				return this.GetTable<Script>();
			}
		}
		
		public System.Data.Linq.Table<GetRegisteredDatabase> GetRegisteredDatabases
		{
			get
			{
				return this.GetTable<GetRegisteredDatabase>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Databases")]
	public partial class Database : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _DatabaseName;
		
		private int _DatabaseTypeId;
		
		private string _DatabaseCode;
		
		private EntitySet<Script> _Scripts;
		
		private EntityRef<DatabasesType> _DatabasesType;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnDatabaseNameChanging(string value);
    partial void OnDatabaseNameChanged();
    partial void OnDatabaseTypeIdChanging(int value);
    partial void OnDatabaseTypeIdChanged();
    partial void OnDatabaseCodeChanging(string value);
    partial void OnDatabaseCodeChanged();
    #endregion
		
		public Database()
		{
			this._Scripts = new EntitySet<Script>(new Action<Script>(this.attach_Scripts), new Action<Script>(this.detach_Scripts));
			this._DatabasesType = default(EntityRef<DatabasesType>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DatabaseName", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string DatabaseName
		{
			get
			{
				return this._DatabaseName;
			}
			set
			{
				if ((this._DatabaseName != value))
				{
					this.OnDatabaseNameChanging(value);
					this.SendPropertyChanging();
					this._DatabaseName = value;
					this.SendPropertyChanged("DatabaseName");
					this.OnDatabaseNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DatabaseTypeId", DbType="Int NOT NULL")]
		public int DatabaseTypeId
		{
			get
			{
				return this._DatabaseTypeId;
			}
			set
			{
				if ((this._DatabaseTypeId != value))
				{
					if (this._DatabasesType.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnDatabaseTypeIdChanging(value);
					this.SendPropertyChanging();
					this._DatabaseTypeId = value;
					this.SendPropertyChanged("DatabaseTypeId");
					this.OnDatabaseTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DatabaseCode", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string DatabaseCode
		{
			get
			{
				return this._DatabaseCode;
			}
			set
			{
				if ((this._DatabaseCode != value))
				{
					this.OnDatabaseCodeChanging(value);
					this.SendPropertyChanging();
					this._DatabaseCode = value;
					this.SendPropertyChanged("DatabaseCode");
					this.OnDatabaseCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Database_Script", Storage="_Scripts", ThisKey="Id", OtherKey="DatabaseId")]
		public EntitySet<Script> Scripts
		{
			get
			{
				return this._Scripts;
			}
			set
			{
				this._Scripts.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DatabasesType_Database", Storage="_DatabasesType", ThisKey="DatabaseTypeId", OtherKey="Id", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public DatabasesType DatabasesType
		{
			get
			{
				return this._DatabasesType.Entity;
			}
			set
			{
				DatabasesType previousValue = this._DatabasesType.Entity;
				if (((previousValue != value) 
							|| (this._DatabasesType.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._DatabasesType.Entity = null;
						previousValue.Databases.Remove(this);
					}
					this._DatabasesType.Entity = value;
					if ((value != null))
					{
						value.Databases.Add(this);
						this._DatabaseTypeId = value.Id;
					}
					else
					{
						this._DatabaseTypeId = default(int);
					}
					this.SendPropertyChanged("DatabasesType");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Scripts(Script entity)
		{
			this.SendPropertyChanging();
			entity.Database = this;
		}
		
		private void detach_Scripts(Script entity)
		{
			this.SendPropertyChanging();
			entity.Database = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DatabasesType")]
	public partial class DatabasesType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _TypeName;
		
		private EntitySet<Database> _Databases;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnTypeNameChanging(string value);
    partial void OnTypeNameChanged();
    #endregion
		
		public DatabasesType()
		{
			this._Databases = new EntitySet<Database>(new Action<Database>(this.attach_Databases), new Action<Database>(this.detach_Databases));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TypeName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string TypeName
		{
			get
			{
				return this._TypeName;
			}
			set
			{
				if ((this._TypeName != value))
				{
					this.OnTypeNameChanging(value);
					this.SendPropertyChanging();
					this._TypeName = value;
					this.SendPropertyChanged("TypeName");
					this.OnTypeNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DatabasesType_Database", Storage="_Databases", ThisKey="Id", OtherKey="DatabaseTypeId")]
		public EntitySet<Database> Databases
		{
			get
			{
				return this._Databases;
			}
			set
			{
				this._Databases.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Databases(Database entity)
		{
			this.SendPropertyChanging();
			entity.DatabasesType = this;
		}
		
		private void detach_Databases(Database entity)
		{
			this.SendPropertyChanging();
			entity.DatabasesType = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.LogHistoryType")]
	public partial class LogHistoryType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _EnName;
		
		private string _ArName;
		
		private EntitySet<LogHistory> _LogHistories;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnEnNameChanging(string value);
    partial void OnEnNameChanged();
    partial void OnArNameChanging(string value);
    partial void OnArNameChanged();
    #endregion
		
		public LogHistoryType()
		{
			this._LogHistories = new EntitySet<LogHistory>(new Action<LogHistory>(this.attach_LogHistories), new Action<LogHistory>(this.detach_LogHistories));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EnName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string EnName
		{
			get
			{
				return this._EnName;
			}
			set
			{
				if ((this._EnName != value))
				{
					this.OnEnNameChanging(value);
					this.SendPropertyChanging();
					this._EnName = value;
					this.SendPropertyChanged("EnName");
					this.OnEnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ArName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string ArName
		{
			get
			{
				return this._ArName;
			}
			set
			{
				if ((this._ArName != value))
				{
					this.OnArNameChanging(value);
					this.SendPropertyChanging();
					this._ArName = value;
					this.SendPropertyChanged("ArName");
					this.OnArNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LogHistoryType_LogHistory", Storage="_LogHistories", ThisKey="Id", OtherKey="LogHistoryTypeId")]
		public EntitySet<LogHistory> LogHistories
		{
			get
			{
				return this._LogHistories;
			}
			set
			{
				this._LogHistories.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_LogHistories(LogHistory entity)
		{
			this.SendPropertyChanging();
			entity.LogHistoryType = this;
		}
		
		private void detach_LogHistories(LogHistory entity)
		{
			this.SendPropertyChanging();
			entity.LogHistoryType = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.LogHistory")]
	public partial class LogHistory : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _LogMessage;
		
		private int _LogHistoryTypeId;
		
		private string _Script;
		
		private string _ServerName;
		
		private string _DbName;
		
		private EntityRef<LogHistoryType> _LogHistoryType;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnLogMessageChanging(string value);
    partial void OnLogMessageChanged();
    partial void OnLogHistoryTypeIdChanging(int value);
    partial void OnLogHistoryTypeIdChanged();
    partial void OnScriptChanging(string value);
    partial void OnScriptChanged();
    partial void OnServerNameChanging(string value);
    partial void OnServerNameChanged();
    partial void OnDbNameChanging(string value);
    partial void OnDbNameChanged();
    #endregion
		
		public LogHistory()
		{
			this._LogHistoryType = default(EntityRef<LogHistoryType>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true, IsDbGenerated=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LogMessage", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string LogMessage
		{
			get
			{
				return this._LogMessage;
			}
			set
			{
				if ((this._LogMessage != value))
				{
					this.OnLogMessageChanging(value);
					this.SendPropertyChanging();
					this._LogMessage = value;
					this.SendPropertyChanged("LogMessage");
					this.OnLogMessageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LogHistoryTypeId", DbType="Int NOT NULL")]
		public int LogHistoryTypeId
		{
			get
			{
				return this._LogHistoryTypeId;
			}
			set
			{
				if ((this._LogHistoryTypeId != value))
				{
					if (this._LogHistoryType.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnLogHistoryTypeIdChanging(value);
					this.SendPropertyChanging();
					this._LogHistoryTypeId = value;
					this.SendPropertyChanged("LogHistoryTypeId");
					this.OnLogHistoryTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Script", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Script
		{
			get
			{
				return this._Script;
			}
			set
			{
				if ((this._Script != value))
				{
					this.OnScriptChanging(value);
					this.SendPropertyChanging();
					this._Script = value;
					this.SendPropertyChanged("Script");
					this.OnScriptChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ServerName", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string ServerName
		{
			get
			{
				return this._ServerName;
			}
			set
			{
				if ((this._ServerName != value))
				{
					this.OnServerNameChanging(value);
					this.SendPropertyChanging();
					this._ServerName = value;
					this.SendPropertyChanged("ServerName");
					this.OnServerNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DbName", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string DbName
		{
			get
			{
				return this._DbName;
			}
			set
			{
				if ((this._DbName != value))
				{
					this.OnDbNameChanging(value);
					this.SendPropertyChanging();
					this._DbName = value;
					this.SendPropertyChanged("DbName");
					this.OnDbNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LogHistoryType_LogHistory", Storage="_LogHistoryType", ThisKey="LogHistoryTypeId", OtherKey="Id", IsForeignKey=true)]
		public LogHistoryType LogHistoryType
		{
			get
			{
				return this._LogHistoryType.Entity;
			}
			set
			{
				LogHistoryType previousValue = this._LogHistoryType.Entity;
				if (((previousValue != value) 
							|| (this._LogHistoryType.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._LogHistoryType.Entity = null;
						previousValue.LogHistories.Remove(this);
					}
					this._LogHistoryType.Entity = value;
					if ((value != null))
					{
						value.LogHistories.Add(this);
						this._LogHistoryTypeId = value.Id;
					}
					else
					{
						this._LogHistoryTypeId = default(int);
					}
					this.SendPropertyChanged("LogHistoryType");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Scripts")]
	public partial class Script : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _ScriptName;
		
		private string _ScriptText;
		
		private int _DatabaseId;
		
		private System.DateTime _CreatedDate;
		
		private string _UserMessage;
		
		private EntityRef<Database> _Database;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnScriptNameChanging(string value);
    partial void OnScriptNameChanged();
    partial void OnScriptTextChanging(string value);
    partial void OnScriptTextChanged();
    partial void OnDatabaseIdChanging(int value);
    partial void OnDatabaseIdChanged();
    partial void OnCreatedDateChanging(System.DateTime value);
    partial void OnCreatedDateChanged();
    partial void OnUserMessageChanging(string value);
    partial void OnUserMessageChanged();
    #endregion
		
		public Script()
		{
			this._Database = default(EntityRef<Database>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true, IsDbGenerated=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ScriptName", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string ScriptName
		{
			get
			{
				return this._ScriptName;
			}
			set
			{
				if ((this._ScriptName != value))
				{
					this.OnScriptNameChanging(value);
					this.SendPropertyChanging();
					this._ScriptName = value;
					this.SendPropertyChanged("ScriptName");
					this.OnScriptNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ScriptText", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string ScriptText
		{
			get
			{
				return this._ScriptText;
			}
			set
			{
				if ((this._ScriptText != value))
				{
					this.OnScriptTextChanging(value);
					this.SendPropertyChanging();
					this._ScriptText = value;
					this.SendPropertyChanged("ScriptText");
					this.OnScriptTextChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DatabaseId", DbType="Int NOT NULL")]
		public int DatabaseId
		{
			get
			{
				return this._DatabaseId;
			}
			set
			{
				if ((this._DatabaseId != value))
				{
					if (this._Database.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnDatabaseIdChanging(value);
					this.SendPropertyChanging();
					this._DatabaseId = value;
					this.SendPropertyChanged("DatabaseId");
					this.OnDatabaseIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreatedDate
		{
			get
			{
				return this._CreatedDate;
			}
			set
			{
				if ((this._CreatedDate != value))
				{
					this.OnCreatedDateChanging(value);
					this.SendPropertyChanging();
					this._CreatedDate = value;
					this.SendPropertyChanged("CreatedDate");
					this.OnCreatedDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserMessage", DbType="NVarChar(MAX)")]
		public string UserMessage
		{
			get
			{
				return this._UserMessage;
			}
			set
			{
				if ((this._UserMessage != value))
				{
					this.OnUserMessageChanging(value);
					this.SendPropertyChanging();
					this._UserMessage = value;
					this.SendPropertyChanged("UserMessage");
					this.OnUserMessageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Database_Script", Storage="_Database", ThisKey="DatabaseId", OtherKey="Id", IsForeignKey=true)]
		public Database Database
		{
			get
			{
				return this._Database.Entity;
			}
			set
			{
				Database previousValue = this._Database.Entity;
				if (((previousValue != value) 
							|| (this._Database.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Database.Entity = null;
						previousValue.Scripts.Remove(this);
					}
					this._Database.Entity = value;
					if ((value != null))
					{
						value.Scripts.Add(this);
						this._DatabaseId = value.Id;
					}
					else
					{
						this._DatabaseId = default(int);
					}
					this.SendPropertyChanged("Database");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.GetRegisteredDatabases")]
	public partial class GetRegisteredDatabase
	{
		
		private string _DatabaseName;
		
		private string _TypeName;
		
		public GetRegisteredDatabase()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DatabaseName", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string DatabaseName
		{
			get
			{
				return this._DatabaseName;
			}
			set
			{
				if ((this._DatabaseName != value))
				{
					this._DatabaseName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TypeName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string TypeName
		{
			get
			{
				return this._TypeName;
			}
			set
			{
				if ((this._TypeName != value))
				{
					this._TypeName = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
