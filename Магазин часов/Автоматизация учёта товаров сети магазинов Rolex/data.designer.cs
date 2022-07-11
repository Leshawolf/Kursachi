﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Автоматизация_учёта_товаров_сети_магазинов_Rolex
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Интернет_магазин")]
	public partial class dataDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertЗаказы(Заказы instance);
    partial void UpdateЗаказы(Заказы instance);
    partial void DeleteЗаказы(Заказы instance);
    partial void InsertМагазины(Магазины instance);
    partial void UpdateМагазины(Магазины instance);
    partial void DeleteМагазины(Магазины instance);
    partial void InsertПокупатели(Покупатели instance);
    partial void UpdateПокупатели(Покупатели instance);
    partial void DeleteПокупатели(Покупатели instance);
    partial void InsertСотрудники(Сотрудники instance);
    partial void UpdateСотрудники(Сотрудники instance);
    partial void DeleteСотрудники(Сотрудники instance);
    partial void InsertТовары(Товары instance);
    partial void UpdateТовары(Товары instance);
    partial void DeleteТовары(Товары instance);
    #endregion
		
		public dataDataContext() : 
				base(global::Автоматизация_учёта_товаров_сети_магазинов_Rolex.Properties.Settings.Default.Интернет_магазинConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dataDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dataDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dataDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dataDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Заказы> Заказы
		{
			get
			{
				return this.GetTable<Заказы>();
			}
		}
		
		public System.Data.Linq.Table<Магазины> Магазины
		{
			get
			{
				return this.GetTable<Магазины>();
			}
		}
		
		public System.Data.Linq.Table<Покупатели> Покупатели
		{
			get
			{
				return this.GetTable<Покупатели>();
			}
		}
		
		public System.Data.Linq.Table<Сотрудники> Сотрудники
		{
			get
			{
				return this.GetTable<Сотрудники>();
			}
		}
		
		public System.Data.Linq.Table<Товары> Товары
		{
			get
			{
				return this.GetTable<Товары>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Заказы")]
	public partial class Заказы : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID_заказа;
		
		private string _Дата_заказа;
		
		private int _Цена_заказа;
		
		private int _ID_товара;
		
		private int _ID_покупателя;
		
		private EntityRef<Покупатели> _Покупатели;
		
		private EntityRef<Товары> _Товары;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_заказаChanging(int value);
    partial void OnID_заказаChanged();
    partial void OnДата_заказаChanging(string value);
    partial void OnДата_заказаChanged();
    partial void OnЦена_заказаChanging(int value);
    partial void OnЦена_заказаChanged();
    partial void OnID_товараChanging(int value);
    partial void OnID_товараChanged();
    partial void OnID_покупателяChanging(int value);
    partial void OnID_покупателяChanged();
    #endregion
		
		public Заказы()
		{
			this._Покупатели = default(EntityRef<Покупатели>);
			this._Товары = default(EntityRef<Товары>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_заказа", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID_заказа
		{
			get
			{
				return this._ID_заказа;
			}
			set
			{
				if ((this._ID_заказа != value))
				{
					this.OnID_заказаChanging(value);
					this.SendPropertyChanging();
					this._ID_заказа = value;
					this.SendPropertyChanged("ID_заказа");
					this.OnID_заказаChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Дата_заказа", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string Дата_заказа
		{
			get
			{
				return this._Дата_заказа;
			}
			set
			{
				if ((this._Дата_заказа != value))
				{
					this.OnДата_заказаChanging(value);
					this.SendPropertyChanging();
					this._Дата_заказа = value;
					this.SendPropertyChanged("Дата_заказа");
					this.OnДата_заказаChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Цена_заказа", DbType="Int NOT NULL")]
		public int Цена_заказа
		{
			get
			{
				return this._Цена_заказа;
			}
			set
			{
				if ((this._Цена_заказа != value))
				{
					this.OnЦена_заказаChanging(value);
					this.SendPropertyChanging();
					this._Цена_заказа = value;
					this.SendPropertyChanged("Цена_заказа");
					this.OnЦена_заказаChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_товара", DbType="Int NOT NULL")]
		public int ID_товара
		{
			get
			{
				return this._ID_товара;
			}
			set
			{
				if ((this._ID_товара != value))
				{
					if (this._Товары.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnID_товараChanging(value);
					this.SendPropertyChanging();
					this._ID_товара = value;
					this.SendPropertyChanged("ID_товара");
					this.OnID_товараChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_покупателя", DbType="Int NOT NULL")]
		public int ID_покупателя
		{
			get
			{
				return this._ID_покупателя;
			}
			set
			{
				if ((this._ID_покупателя != value))
				{
					if (this._Покупатели.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnID_покупателяChanging(value);
					this.SendPropertyChanging();
					this._ID_покупателя = value;
					this.SendPropertyChanged("ID_покупателя");
					this.OnID_покупателяChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Покупатели_Заказы", Storage="_Покупатели", ThisKey="ID_покупателя", OtherKey="ID_покупателя", IsForeignKey=true)]
		public Покупатели Покупатели
		{
			get
			{
				return this._Покупатели.Entity;
			}
			set
			{
				Покупатели previousValue = this._Покупатели.Entity;
				if (((previousValue != value) 
							|| (this._Покупатели.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Покупатели.Entity = null;
						previousValue.Заказы.Remove(this);
					}
					this._Покупатели.Entity = value;
					if ((value != null))
					{
						value.Заказы.Add(this);
						this._ID_покупателя = value.ID_покупателя;
					}
					else
					{
						this._ID_покупателя = default(int);
					}
					this.SendPropertyChanged("Покупатели");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Товары_Заказы", Storage="_Товары", ThisKey="ID_товара", OtherKey="ID_товара", IsForeignKey=true)]
		public Товары Товары
		{
			get
			{
				return this._Товары.Entity;
			}
			set
			{
				Товары previousValue = this._Товары.Entity;
				if (((previousValue != value) 
							|| (this._Товары.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Товары.Entity = null;
						previousValue.Заказы.Remove(this);
					}
					this._Товары.Entity = value;
					if ((value != null))
					{
						value.Заказы.Add(this);
						this._ID_товара = value.ID_товара;
					}
					else
					{
						this._ID_товара = default(int);
					}
					this.SendPropertyChanged("Товары");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Магазины")]
	public partial class Магазины : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID_магазина;
		
		private string _Адрес_магазина;
		
		private EntitySet<Товары> _Товары;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_магазинаChanging(int value);
    partial void OnID_магазинаChanged();
    partial void OnАдрес_магазинаChanging(string value);
    partial void OnАдрес_магазинаChanged();
    #endregion
		
		public Магазины()
		{
			this._Товары = new EntitySet<Товары>(new Action<Товары>(this.attach_Товары), new Action<Товары>(this.detach_Товары));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_магазина", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID_магазина
		{
			get
			{
				return this._ID_магазина;
			}
			set
			{
				if ((this._ID_магазина != value))
				{
					this.OnID_магазинаChanging(value);
					this.SendPropertyChanging();
					this._ID_магазина = value;
					this.SendPropertyChanged("ID_магазина");
					this.OnID_магазинаChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Адрес_магазина", DbType="NChar(40) NOT NULL", CanBeNull=false)]
		public string Адрес_магазина
		{
			get
			{
				return this._Адрес_магазина;
			}
			set
			{
				if ((this._Адрес_магазина != value))
				{
					this.OnАдрес_магазинаChanging(value);
					this.SendPropertyChanging();
					this._Адрес_магазина = value;
					this.SendPropertyChanged("Адрес_магазина");
					this.OnАдрес_магазинаChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Магазины_Товары", Storage="_Товары", ThisKey="ID_магазина", OtherKey="ID_магазина")]
		public EntitySet<Товары> Товары
		{
			get
			{
				return this._Товары;
			}
			set
			{
				this._Товары.Assign(value);
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
		
		private void attach_Товары(Товары entity)
		{
			this.SendPropertyChanging();
			entity.Магазины = this;
		}
		
		private void detach_Товары(Товары entity)
		{
			this.SendPropertyChanging();
			entity.Магазины = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Покупатели")]
	public partial class Покупатели : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID_покупателя;
		
		private string _ФИО;
		
		private string _Адрес;
		
		private string _Контактный_телефон;
		
		private string _Электронный_адрес;
		
		private EntitySet<Заказы> _Заказы;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_покупателяChanging(int value);
    partial void OnID_покупателяChanged();
    partial void OnФИОChanging(string value);
    partial void OnФИОChanged();
    partial void OnАдресChanging(string value);
    partial void OnАдресChanged();
    partial void OnКонтактный_телефонChanging(string value);
    partial void OnКонтактный_телефонChanged();
    partial void OnЭлектронный_адресChanging(string value);
    partial void OnЭлектронный_адресChanged();
    #endregion
		
		public Покупатели()
		{
			this._Заказы = new EntitySet<Заказы>(new Action<Заказы>(this.attach_Заказы), new Action<Заказы>(this.detach_Заказы));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_покупателя", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID_покупателя
		{
			get
			{
				return this._ID_покупателя;
			}
			set
			{
				if ((this._ID_покупателя != value))
				{
					this.OnID_покупателяChanging(value);
					this.SendPropertyChanging();
					this._ID_покупателя = value;
					this.SendPropertyChanged("ID_покупателя");
					this.OnID_покупателяChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ФИО", DbType="NVarChar(40) NOT NULL", CanBeNull=false)]
		public string ФИО
		{
			get
			{
				return this._ФИО;
			}
			set
			{
				if ((this._ФИО != value))
				{
					this.OnФИОChanging(value);
					this.SendPropertyChanging();
					this._ФИО = value;
					this.SendPropertyChanged("ФИО");
					this.OnФИОChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Адрес", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string Адрес
		{
			get
			{
				return this._Адрес;
			}
			set
			{
				if ((this._Адрес != value))
				{
					this.OnАдресChanging(value);
					this.SendPropertyChanging();
					this._Адрес = value;
					this.SendPropertyChanged("Адрес");
					this.OnАдресChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Контактный_телефон", DbType="Char(13) NOT NULL", CanBeNull=false)]
		public string Контактный_телефон
		{
			get
			{
				return this._Контактный_телефон;
			}
			set
			{
				if ((this._Контактный_телефон != value))
				{
					this.OnКонтактный_телефонChanging(value);
					this.SendPropertyChanging();
					this._Контактный_телефон = value;
					this.SendPropertyChanged("Контактный_телефон");
					this.OnКонтактный_телефонChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Электронный_адрес", DbType="NVarChar(32) NOT NULL", CanBeNull=false)]
		public string Электронный_адрес
		{
			get
			{
				return this._Электронный_адрес;
			}
			set
			{
				if ((this._Электронный_адрес != value))
				{
					this.OnЭлектронный_адресChanging(value);
					this.SendPropertyChanging();
					this._Электронный_адрес = value;
					this.SendPropertyChanged("Электронный_адрес");
					this.OnЭлектронный_адресChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Покупатели_Заказы", Storage="_Заказы", ThisKey="ID_покупателя", OtherKey="ID_покупателя")]
		public EntitySet<Заказы> Заказы
		{
			get
			{
				return this._Заказы;
			}
			set
			{
				this._Заказы.Assign(value);
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
		
		private void attach_Заказы(Заказы entity)
		{
			this.SendPropertyChanging();
			entity.Покупатели = this;
		}
		
		private void detach_Заказы(Заказы entity)
		{
			this.SendPropertyChanging();
			entity.Покупатели = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Сотрудники")]
	public partial class Сотрудники : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID_сотрудника;
		
		private string _Логин;
		
		private string _Пароль;
		
		private string _ФИО;
		
		private string _Адрес;
		
		private string _Дата_рождения;
		
		private string _Должность;
		
		private string _Контактный_телефон;
		
		private string _Электронный_адрес;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_сотрудникаChanging(int value);
    partial void OnID_сотрудникаChanged();
    partial void OnЛогинChanging(string value);
    partial void OnЛогинChanged();
    partial void OnПарольChanging(string value);
    partial void OnПарольChanged();
    partial void OnФИОChanging(string value);
    partial void OnФИОChanged();
    partial void OnАдресChanging(string value);
    partial void OnАдресChanged();
    partial void OnДата_рожденияChanging(string value);
    partial void OnДата_рожденияChanged();
    partial void OnДолжностьChanging(string value);
    partial void OnДолжностьChanged();
    partial void OnКонтактный_телефонChanging(string value);
    partial void OnКонтактный_телефонChanged();
    partial void OnЭлектронный_адресChanging(string value);
    partial void OnЭлектронный_адресChanged();
    #endregion
		
		public Сотрудники()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_сотрудника", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID_сотрудника
		{
			get
			{
				return this._ID_сотрудника;
			}
			set
			{
				if ((this._ID_сотрудника != value))
				{
					this.OnID_сотрудникаChanging(value);
					this.SendPropertyChanging();
					this._ID_сотрудника = value;
					this.SendPropertyChanged("ID_сотрудника");
					this.OnID_сотрудникаChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Логин", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string Логин
		{
			get
			{
				return this._Логин;
			}
			set
			{
				if ((this._Логин != value))
				{
					this.OnЛогинChanging(value);
					this.SendPropertyChanging();
					this._Логин = value;
					this.SendPropertyChanged("Логин");
					this.OnЛогинChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Пароль", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string Пароль
		{
			get
			{
				return this._Пароль;
			}
			set
			{
				if ((this._Пароль != value))
				{
					this.OnПарольChanging(value);
					this.SendPropertyChanging();
					this._Пароль = value;
					this.SendPropertyChanged("Пароль");
					this.OnПарольChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ФИО", DbType="NVarChar(40) NOT NULL", CanBeNull=false)]
		public string ФИО
		{
			get
			{
				return this._ФИО;
			}
			set
			{
				if ((this._ФИО != value))
				{
					this.OnФИОChanging(value);
					this.SendPropertyChanging();
					this._ФИО = value;
					this.SendPropertyChanged("ФИО");
					this.OnФИОChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Адрес", DbType="NVarChar(40) NOT NULL", CanBeNull=false)]
		public string Адрес
		{
			get
			{
				return this._Адрес;
			}
			set
			{
				if ((this._Адрес != value))
				{
					this.OnАдресChanging(value);
					this.SendPropertyChanging();
					this._Адрес = value;
					this.SendPropertyChanged("Адрес");
					this.OnАдресChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Дата_рождения", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
		public string Дата_рождения
		{
			get
			{
				return this._Дата_рождения;
			}
			set
			{
				if ((this._Дата_рождения != value))
				{
					this.OnДата_рожденияChanging(value);
					this.SendPropertyChanging();
					this._Дата_рождения = value;
					this.SendPropertyChanged("Дата_рождения");
					this.OnДата_рожденияChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Должность", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
		public string Должность
		{
			get
			{
				return this._Должность;
			}
			set
			{
				if ((this._Должность != value))
				{
					this.OnДолжностьChanging(value);
					this.SendPropertyChanging();
					this._Должность = value;
					this.SendPropertyChanged("Должность");
					this.OnДолжностьChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Контактный_телефон", DbType="Char(13) NOT NULL", CanBeNull=false)]
		public string Контактный_телефон
		{
			get
			{
				return this._Контактный_телефон;
			}
			set
			{
				if ((this._Контактный_телефон != value))
				{
					this.OnКонтактный_телефонChanging(value);
					this.SendPropertyChanging();
					this._Контактный_телефон = value;
					this.SendPropertyChanged("Контактный_телефон");
					this.OnКонтактный_телефонChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Электронный_адрес", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string Электронный_адрес
		{
			get
			{
				return this._Электронный_адрес;
			}
			set
			{
				if ((this._Электронный_адрес != value))
				{
					this.OnЭлектронный_адресChanging(value);
					this.SendPropertyChanging();
					this._Электронный_адрес = value;
					this.SendPropertyChanged("Электронный_адрес");
					this.OnЭлектронный_адресChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Товары")]
	public partial class Товары : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID_товара;
		
		private string _Наименование;
		
		private int _Отпускная_цена;
		
		private System.Nullable<int> _Розничная_цена;
		
		private string _Статус;
		
		private int _ID_магазина;
		
		private EntitySet<Заказы> _Заказы;
		
		private EntityRef<Магазины> _Магазины;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnID_товараChanging(int value);
    partial void OnID_товараChanged();
    partial void OnНаименованиеChanging(string value);
    partial void OnНаименованиеChanged();
    partial void OnОтпускная_ценаChanging(int value);
    partial void OnОтпускная_ценаChanged();
    partial void OnРозничная_ценаChanging(System.Nullable<int> value);
    partial void OnРозничная_ценаChanged();
    partial void OnСтатусChanging(string value);
    partial void OnСтатусChanged();
    partial void OnID_магазинаChanging(int value);
    partial void OnID_магазинаChanged();
    #endregion
		
		public Товары()
		{
			this._Заказы = new EntitySet<Заказы>(new Action<Заказы>(this.attach_Заказы), new Action<Заказы>(this.detach_Заказы));
			this._Магазины = default(EntityRef<Магазины>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_товара", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID_товара
		{
			get
			{
				return this._ID_товара;
			}
			set
			{
				if ((this._ID_товара != value))
				{
					this.OnID_товараChanging(value);
					this.SendPropertyChanging();
					this._ID_товара = value;
					this.SendPropertyChanged("ID_товара");
					this.OnID_товараChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Наименование", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string Наименование
		{
			get
			{
				return this._Наименование;
			}
			set
			{
				if ((this._Наименование != value))
				{
					this.OnНаименованиеChanging(value);
					this.SendPropertyChanging();
					this._Наименование = value;
					this.SendPropertyChanged("Наименование");
					this.OnНаименованиеChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Отпускная_цена", DbType="Int NOT NULL")]
		public int Отпускная_цена
		{
			get
			{
				return this._Отпускная_цена;
			}
			set
			{
				if ((this._Отпускная_цена != value))
				{
					this.OnОтпускная_ценаChanging(value);
					this.SendPropertyChanging();
					this._Отпускная_цена = value;
					this.SendPropertyChanged("Отпускная_цена");
					this.OnОтпускная_ценаChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Розничная_цена", DbType="Int")]
		public System.Nullable<int> Розничная_цена
		{
			get
			{
				return this._Розничная_цена;
			}
			set
			{
				if ((this._Розничная_цена != value))
				{
					this.OnРозничная_ценаChanging(value);
					this.SendPropertyChanging();
					this._Розничная_цена = value;
					this.SendPropertyChanged("Розничная_цена");
					this.OnРозничная_ценаChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Статус", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
		public string Статус
		{
			get
			{
				return this._Статус;
			}
			set
			{
				if ((this._Статус != value))
				{
					this.OnСтатусChanging(value);
					this.SendPropertyChanging();
					this._Статус = value;
					this.SendPropertyChanged("Статус");
					this.OnСтатусChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_магазина", DbType="Int NOT NULL")]
		public int ID_магазина
		{
			get
			{
				return this._ID_магазина;
			}
			set
			{
				if ((this._ID_магазина != value))
				{
					if (this._Магазины.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnID_магазинаChanging(value);
					this.SendPropertyChanging();
					this._ID_магазина = value;
					this.SendPropertyChanged("ID_магазина");
					this.OnID_магазинаChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Товары_Заказы", Storage="_Заказы", ThisKey="ID_товара", OtherKey="ID_товара")]
		public EntitySet<Заказы> Заказы
		{
			get
			{
				return this._Заказы;
			}
			set
			{
				this._Заказы.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Магазины_Товары", Storage="_Магазины", ThisKey="ID_магазина", OtherKey="ID_магазина", IsForeignKey=true)]
		public Магазины Магазины
		{
			get
			{
				return this._Магазины.Entity;
			}
			set
			{
				Магазины previousValue = this._Магазины.Entity;
				if (((previousValue != value) 
							|| (this._Магазины.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Магазины.Entity = null;
						previousValue.Товары.Remove(this);
					}
					this._Магазины.Entity = value;
					if ((value != null))
					{
						value.Товары.Add(this);
						this._ID_магазина = value.ID_магазина;
					}
					else
					{
						this._ID_магазина = default(int);
					}
					this.SendPropertyChanged("Магазины");
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
		
		private void attach_Заказы(Заказы entity)
		{
			this.SendPropertyChanging();
			entity.Товары = this;
		}
		
		private void detach_Заказы(Заказы entity)
		{
			this.SendPropertyChanging();
			entity.Товары = null;
		}
	}
}
#pragma warning restore 1591
