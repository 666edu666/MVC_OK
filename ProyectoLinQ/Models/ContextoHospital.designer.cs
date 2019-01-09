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

namespace ProyectoLinQ.Models
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
    partial void InsertEMP(EMP instance);
    partial void UpdateEMP(EMP instance);
    partial void DeleteEMP(EMP instance);
    partial void InsertDEPT(DEPT instance);
    partial void UpdateDEPT(DEPT instance);
    partial void DeleteDEPT(DEPT instance);
    #endregion
		
		public ContextoHospitalDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["HOSPITALConnectionString"].ConnectionString, mappingSource)
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
		
		public System.Data.Linq.Table<EMP> EMPs
		{
			get
			{
				return this.GetTable<EMP>();
			}
		}
		
		public System.Data.Linq.Table<DEPT> DEPTs
		{
			get
			{
				return this.GetTable<DEPT>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.EMP")]
	public partial class EMP : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Nullable<int> _EMP_NO;
		
		private string _APELLIDO;
		
		private string _OFICIO;
		
		private System.Nullable<int> _DIR;
		
		private System.Nullable<System.DateTime> _FECHA_ALT;
		
		private System.Nullable<int> _SALARIO;
		
		private System.Nullable<int> _COMISION;
		
		private System.Nullable<int> _DEPT_NO;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEMP_NOChanging(System.Nullable<int> value);
    partial void OnEMP_NOChanged();
    partial void OnAPELLIDOChanging(string value);
    partial void OnAPELLIDOChanged();
    partial void OnOFICIOChanging(string value);
    partial void OnOFICIOChanged();
    partial void OnDIRChanging(System.Nullable<int> value);
    partial void OnDIRChanged();
    partial void OnFECHA_ALTChanging(System.Nullable<System.DateTime> value);
    partial void OnFECHA_ALTChanged();
    partial void OnSALARIOChanging(System.Nullable<int> value);
    partial void OnSALARIOChanged();
    partial void OnCOMISIONChanging(System.Nullable<int> value);
    partial void OnCOMISIONChanged();
    partial void OnDEPT_NOChanging(System.Nullable<int> value);
    partial void OnDEPT_NOChanged();
    #endregion
		
		public EMP()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EMP_NO", DbType="Int", IsPrimaryKey=true)]
		public System.Nullable<int> EMP_NO
		{
			get
			{
				return this._EMP_NO;
			}
			set
			{
				if ((this._EMP_NO != value))
				{
					this.OnEMP_NOChanging(value);
					this.SendPropertyChanging();
					this._EMP_NO = value;
					this.SendPropertyChanged("EMP_NO");
					this.OnEMP_NOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_APELLIDO", DbType="NVarChar(50)")]
		public string APELLIDO
		{
			get
			{
				return this._APELLIDO;
			}
			set
			{
				if ((this._APELLIDO != value))
				{
					this.OnAPELLIDOChanging(value);
					this.SendPropertyChanging();
					this._APELLIDO = value;
					this.SendPropertyChanged("APELLIDO");
					this.OnAPELLIDOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OFICIO", DbType="NVarChar(50)")]
		public string OFICIO
		{
			get
			{
				return this._OFICIO;
			}
			set
			{
				if ((this._OFICIO != value))
				{
					this.OnOFICIOChanging(value);
					this.SendPropertyChanging();
					this._OFICIO = value;
					this.SendPropertyChanged("OFICIO");
					this.OnOFICIOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DIR", DbType="Int")]
		public System.Nullable<int> DIR
		{
			get
			{
				return this._DIR;
			}
			set
			{
				if ((this._DIR != value))
				{
					this.OnDIRChanging(value);
					this.SendPropertyChanging();
					this._DIR = value;
					this.SendPropertyChanged("DIR");
					this.OnDIRChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FECHA_ALT", DbType="DateTime")]
		public System.Nullable<System.DateTime> FECHA_ALT
		{
			get
			{
				return this._FECHA_ALT;
			}
			set
			{
				if ((this._FECHA_ALT != value))
				{
					this.OnFECHA_ALTChanging(value);
					this.SendPropertyChanging();
					this._FECHA_ALT = value;
					this.SendPropertyChanged("FECHA_ALT");
					this.OnFECHA_ALTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SALARIO", DbType="Int")]
		public System.Nullable<int> SALARIO
		{
			get
			{
				return this._SALARIO;
			}
			set
			{
				if ((this._SALARIO != value))
				{
					this.OnSALARIOChanging(value);
					this.SendPropertyChanging();
					this._SALARIO = value;
					this.SendPropertyChanged("SALARIO");
					this.OnSALARIOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_COMISION", DbType="Int")]
		public System.Nullable<int> COMISION
		{
			get
			{
				return this._COMISION;
			}
			set
			{
				if ((this._COMISION != value))
				{
					this.OnCOMISIONChanging(value);
					this.SendPropertyChanging();
					this._COMISION = value;
					this.SendPropertyChanged("COMISION");
					this.OnCOMISIONChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DEPT_NO", DbType="Int")]
		public System.Nullable<int> DEPT_NO
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
