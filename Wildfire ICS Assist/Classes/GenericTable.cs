using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Wildfire_ICS_Assist.Classes
{

    //https://stackoverflow.com/questions/59410146/dynamically-creating-bindings-for-dynamically-created-objects-during-runtime 
    public class GenericTable
    {

        private string tableName = "";
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        private ObservableCollection<DataGridColumn> columnCollection;
        public ObservableCollection<DataGridColumn> ColumnCollection
        {
            get { return columnCollection; }
            private set { columnCollection = value; }
        }

        private ObservableCollection<GenericRow> genericRowCollection;
        public ObservableCollection<GenericRow> GenericRowCollection
        {
            get { return genericRowCollection; }
            set { genericRowCollection = value; }
        }




        public GenericTable(string tableName)
        {
            this.TableName = tableName;
            ColumnCollection = new ObservableCollection<DataGridColumn>();
            GenericRowCollection = new ObservableCollection<GenericRow>();
        }

        /// <summary>
        /// ColumnName is also binding property name
        /// </summary>
        /// <param name="columnName"></param>
        public void AddColumn(string columnName)
        {
            DataGridTextColumn column = new DataGridTextColumn();
            column.Header = columnName;
            column.Binding = new Binding(columnName);
            ColumnCollection.Add(column);
        }



        public override string ToString()
        {
            return TableName;
        }


    }

    public class GenericRow : CustomTypeDescriptor, INotifyPropertyChanged
    {

        #region Private Fields
        List<PropertyDescriptor> _property_list = new List<PropertyDescriptor>();
        #endregion

        #region INotifyPropertyChange Implementation

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChange Implementation

        #region Public Methods

        public void SetPropertyValue<T>(string propertyName, T propertyValue)
        {
            var properties = this.GetProperties()
                                    .Cast<PropertyDescriptor>()
                                    .Where(prop => prop.Name.Equals(propertyName));

            if (properties == null || properties.Count() != 1)
            {
                throw new Exception("The property doesn't exist.");
            }

            var property = properties.First();
            property.SetValue(this, propertyValue);

            OnPropertyChanged(propertyName);
        }

        public T GetPropertyValue<T>(string propertyName)
        {
            var properties = this.GetProperties()
                                .Cast<PropertyDescriptor>()
                                .Where(prop => prop.Name.Equals(propertyName));

            if (properties == null || properties.Count() != 1)
            {
                throw new Exception("The property doesn't exist.");
            }

            var property = properties.First();
            return (T)property.GetValue(this);
        }

        public void AddProperty<T, U>(string propertyName) where U : GenericRow
        {
            var customProperty = new CustomPropertyDescriptor<T>(propertyName,typeof(U));
            _property_list.Add(customProperty);
        }

        #endregion

        #region Overriden Methods

        public override PropertyDescriptorCollection GetProperties()
        {
            var properties = base.GetProperties();
            return new PropertyDescriptorCollection(
                                properties.Cast<PropertyDescriptor>()
                                          .Concat(_property_list).ToArray());
        }

        #endregion

    }

}

