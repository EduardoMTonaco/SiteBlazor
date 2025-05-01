using SiteBlazor.Class.Attributes;
using SiteBlazor.Class.DTO;
using System.ComponentModel;
using System.Reflection;

namespace SiteBlazor.Class.Base
{
    public abstract class BaseCollective
    {
        
        public int MaxAmount = 0;
        public static string RemoveSQLInjection(string value)
        {
            return value.Replace("-", "").Replace("'", "");
        }
        public T FillClass<T>(object[] dados) where T : new()
        {
            T obj = new T();
            PropertyInfo[] propriedades = typeof(T).GetProperties();

            foreach (var propriedade in propriedades)
            {
                var atributo = propriedade.GetCustomAttributes(typeof(DisplayAttributes), false)
                                           .FirstOrDefault() as DisplayAttributes;

                if (atributo != null && atributo.Column < dados.Length)
                {
                    if (dados[atributo.Column] != DBNull.Value)
                    {
                        if (propriedade.PropertyType.AssemblyQualifiedName.Contains("DateTime"))
                        {
                            propriedade.SetValue(obj, (DateTime)dados[atributo.Column]);
                        }
                        else if (propriedade.PropertyType.AssemblyQualifiedName.Contains("Boolean"))
                        {
                            propriedade.SetValue(obj, (bool)dados[atributo.Column]);
                        }
                        else
                        {
                            propriedade.SetValue(obj, Convert.ChangeType(dados[atributo.Column], propriedade.PropertyType));
                        }
                    }                       
                }
            }
            return obj;
        }
        public List<Array> SelectArray(BaseDTO objDTO)
        {
            string command = objDTO.SelectCommand();
            return SQLHandler.SQLReader(command);
        }
        public void Update(BaseDTO objDTO)
        {
            string command = objDTO.UpdateCommand();
            SQLHandler.SQLCommand(command);
        }
        public void Insert(BaseDTO objDTO)
        {
            string command = objDTO.InsertCommand();
            SQLHandler.SQLCommand(command);
        }
    }
}
