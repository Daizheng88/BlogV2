using Blog.Contract.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Blog.Contract.Mapper
{
    [Run(Method = "Init")]
    public static class DtoManager
    {
        /// <summary>
        /// 映射容器
        /// </summary>
        private static List<DtoMapper> Container { get; set; }

        /// <summary>
        /// 初始化 Dto 管理器
        /// </summary>
        private static void Init()
        {
            // 初始化字典
            Container = new List<DtoMapper>();

            // 取得所有公开类型
            Type iMapperType = typeof(IMapper);
            Type objectType = typeof(object);
            typeof(DtoManager).Assembly.ExportedTypes.ToList().ForEach(exportClass =>
            {
                // 检查是否依赖 IMapper
                if (!exportClass.IsAssignableFrom(iMapperType))
                {
                    return;
                }

                // 实例化一个dmi对象
                DtoMapper dmi = new DtoMapper();

                // 实例化对象
                dmi.Object = Activator.CreateInstance(exportClass);

                // 反射对象取得所有可用于映射的方法
                exportClass.GetMethods(BindingFlags.Public | BindingFlags.Instance).ToList().ForEach(mi =>
                {
                    if (mi.Name.Equals("To", StringComparison.OrdinalIgnoreCase) &&
                        mi.IsGenericMethod &&
                        mi.GetParameters().Length == 1 &&
                        mi.GetGenericArguments().Length == 1 &&
                        mi.ReturnType.Equals(objectType))
                    {
                        // 取得方法首参数
                        ParameterInfo pi = mi.GetParameters()[0];

                        // 加入对照方法
                        if (!dmi.Dict.ContainsKey(pi.ParameterType))
                        {
                            dmi.Dict.Add(pi.ParameterType, mi);
                        }
                    }
                });

                // 加入容器
                Container.Add(dmi);
            });
        }

        /// <summary>
        /// 映射
        /// </summary>
        /// <param name="value">用于映射的值</param>
        public static object Map<TTarget>(object value)
        {
            Type targetType = typeof(TTarget);

            // 遍历容器寻找最佳映射对象
            object ret = null;
            foreach (DtoMapper item in Container)
            {
                if (!item.Dict.ContainsKey(targetType))
                {
                    continue;
                }

                ret = item.Dict[targetType].Invoke(item.Object, new object[] { value });
                break;
            }

            return ret;
        }

        /// <summary>
        /// 映射
        /// </summary>
        public static object Map(Type targetType, object value)
        {
            // 遍历容器寻找最佳映射对象
            object ret = null;
            foreach (DtoMapper item in Container)
            {
                if (!item.Dict.ContainsKey(targetType))
                {
                    continue;
                }

                ret = item.Dict[targetType].Invoke(item.Object, new object[] { value });
                break;
            }

            return ret;
        }

        /// <summary>
        /// 将数据表格转为实体
        /// </summary>
        public static TEntity ToEntity<TEntity>(this DataTable input) where TEntity : new()
        {
            if (input == null || input.Rows.Count == 0)
            {
                return default;
            }

            // 创建实体
            TEntity entity = Activator.CreateInstance<TEntity>();

            // 取得数据行
            DataRow dataRow = input.Rows[0];

            // 遍历属性
            typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList().ForEach(prop =>
            {
                // 检查是否存在相关字段
                if (!input.Columns.Contains(prop.Name))
                {
                    return;
                }

                // 设置值
                prop.SetValue(entity, Map(prop.PropertyType, dataRow[prop.Name]));
            });

            return entity;
        }

        /// <summary>
        /// 将数据表格转为实体
        /// </summary>
        public static List<TEntity> ToList<TEntity>(this DataTable input)
        {
            if (input == null)
            {
                return default;
            }

            // 集合
            List<TEntity> entities = new List<TEntity>();

            // 映射的属性
            List<PropertyInfo> props = new List<PropertyInfo>();

            // 遍历属性
            typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList().ForEach(prop =>
            {
                // 检查是否存在相关字段
                if (!input.Columns.Contains(prop.Name))
                {
                    return;
                }

                props.Add(prop);
            });


            foreach (DataRow dataRow in input.Rows)
            {
                // 创建实体
                TEntity entity = Activator.CreateInstance<TEntity>();

                // 设置值
                props.ForEach(prop => prop.SetValue(entity, Map(prop.PropertyType, dataRow[prop.Name])));

                // 加入实体
                entities.Add(entity);
            }

            return entities;
        }
    }
}
