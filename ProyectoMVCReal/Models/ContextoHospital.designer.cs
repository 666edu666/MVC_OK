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

namespace ProyectoMVCReal.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="HOSPITAL")]
	public partial class ContextoHospitalDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertDEPT(DEPT instance);
    partial void UpdateDEPT(DEPT instance);
    partial void DeleteDEPT(DEPT instance);
    #endregion
		
		public ContextoHospitalDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["cadenaHospital"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ContextoHospitalDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ContextoHospitalDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ContextoHospitalDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ContextoHospitalDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<DEPT> DEPTs
		{
			get
			{
				return this.GetTable<DEPT>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DEPT")]
	public partial class DEPT : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _DEPT_NO;
		
		private string _DNOMBRE;
		
		private string _LOC;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDEPT_NOChanging(int value);
    partial void OnDEPT_NOChanged();
    partial void OnDNOMBREChanging(string value);
    partial void OnDNOMBREChanged();
    partial void OnLOCChanging(string value);
    partial void OnLOCChanged();
    #endregion
		
		public DEPT()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DEPT_NO", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int DEPT_NO
		{
			get
			{
				return this._DEPT_NO;
			}
			set
			{
				if ((this._DEPT_NO != value))
				{
					this.OnDEPT_NOChanging(value);
					this.SendPropertyChanging();
					this._DEPT_NO = value;
					this.SendPropertyChanged("DEPT_NO");
					this.OnDEPT_NOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DNOMBRE", DbType="NVarChar(50)")]
		public string DNOMBRE
		{
			get
			{
				return this._DNOMBRE;
			}
			set
			{
				if ((this._DNOMBRE != value))
				{
					this.OnDNOMBREChanging(value);
					this.SendPropertyChanging();
					this._DNOMBRE = value;
					this.SendPropertyChanged("DNOMBRE");
					this.OnDNOMBREChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LOC", DbType="NVarChar(50)")]
		public string LOC
		{
			get
			{
				return this._LOC;
			}
			set
			{
				if ((this._LOC != value))
				{
					this.OnLOCChanging(value);
					this.SendPropertyChanging();
					this._LOC = value;
					this.SendPropertyChanged("LOC");
					this.OnLOCChanged();
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
}
#pragma warning restore 1591
