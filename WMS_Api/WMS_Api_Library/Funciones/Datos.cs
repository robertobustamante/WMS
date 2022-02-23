using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

class Datos
{
    public static List<T> ListaDesdeDataTable<T>(DataTable Tabla)
    {
        List<T> objList = new List<T>();
        if (Tabla != null)
        {
            int num1 = 0;
            int num2 = checked(Tabla.Rows.Count - 1);
            int index = num1;
            while (index <= num2)
            {
                DataRow row = Tabla.Rows[index];
                T instance = Activator.CreateInstance<T>();
                try
                {
                    foreach (DataColumn column in (InternalDataCollectionBase)Tabla.Columns)
                    {
                        PropertyInfo property = instance.GetType().GetProperty(column.ColumnName);
                        if (property != null && !Convert.IsDBNull(RuntimeHelpers.GetObjectValue(row[column.ColumnName])))
                            property.SetValue((object)instance, RuntimeHelpers.GetObjectValue(row[column.ColumnName]), (object[])null);
                    }
                }
                finally
                {
                    IEnumerator enumerator = null;
                    if (enumerator is IDisposable)
                        (enumerator as IDisposable).Dispose();
                }
                objList.Add(instance);
                checked { ++index; }
            }
        }
        return objList;
    }

}