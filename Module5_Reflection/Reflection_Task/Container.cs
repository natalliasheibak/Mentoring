using Reflection_Task.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reflection_Task
{
    public class Container
    {
        private Dictionary<Type, Type> _typeList;

        public Container()
        {
            _typeList = new Dictionary<Type, Type>();
        }

        public void AddType(Type type)
        {
            _typeList.Add(type, type);
        }

        public void AddType(Type baseType, Type type)
        {
            _typeList.Add(baseType, type);
        }

        public void AddAssembly(Assembly assembly)
        {
            var exportTypes = GetMembersWithAttribute<ExportAttribute, Type>(assembly.GetTypes().ToList());
            exportTypes.ForEach(x => _typeList.Add(x.GetCustomAttribute<ExportAttribute>().Contractor ?? x, x));

            var importTypes = assembly.GetTypes().Where(x => HasImportConstactor(x) || HasImportProperties(x)).ToList();
            importTypes.ForEach(x => _typeList.Add(x, x));
        }

        public object CreateInstance(Type type)
        {
            if(!_typeList.ContainsKey(type))
            {
                throw new Exception($"Container doesn't have the {type.Name} type.");
            }

            var typeOfInstance = _typeList[type];
            if (HasImportConstactor(type))
            {
                return CreateInstanceFromConstructor(typeOfInstance);
            }
            else if(HasImportProperties(type))
            {
                return CreateInstanceWithParameters(typeOfInstance);
            }

            return null;
        }

        public T CreateInstance<T>()
        {
            return (T)CreateInstance(typeof(T));
        }

        #region private

        private List<U> GetMembersWithAttribute<T, U>(List<U> list) where T : Attribute
                                                                                where U : MemberInfo
        {
            return list.Where(x => x.GetCustomAttribute(typeof(T)) != null).ToList();
        }

        private List<PropertyInfo> GetImportProperties(Type type)
        {
            return GetMembersWithAttribute<ImportAttribute, PropertyInfo>(type.GetProperties().ToList());
        }

        private ConstructorInfo GetConstructor(Type type)
        {
            return type.GetConstructors().First();
        }

        private bool HasImportConstactor(Type type)
        {
            return type.GetCustomAttribute<ImportConstructorAttribute>() != null;
        }

        private bool HasImportProperties(Type type)
        {
            return GetImportProperties(type).Count > 0;
        }

        private object CreateInstanceFromConstructor(Type type)
        {
            var paramlist = GetConstructor(type).GetParameters().Select(x => x.ParameterType).Select(x => Activator.CreateInstance(x)).ToArray();

            return Activator.CreateInstance(type, paramlist);
        }

        private object CreateInstanceWithParameters(Type type)
        {
            var returnObject = Activator.CreateInstance(type);
            GetImportProperties(type).ForEach(x => x.SetValue(returnObject, Activator.CreateInstance(x.PropertyType)));
            return returnObject;
        }

        #endregion
    }
}
