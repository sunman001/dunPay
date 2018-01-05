using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunxPay.Core.Extensions
{
    /// <summary>
    /// 基类扩展(Object)
    /// </summary>
    public static class ObjectExpansion
    {
        /// <summary>
        /// 指定类型转换
        /// </summary>
        /// <typeparam name="T">指定的类型</typeparam>
        /// <param name="source">要转换的值</param>
        /// <param name="defobj">为空时的默认值</param>
        /// <param name="diffCase">是否区分大小写，对于特殊类型的转换，如枚举</param>
        /// <param name="isJson">是否支持Json自动转换处理</param>
        /// <returns></returns>
        public static T To<T>(this object source, object defobj = null, bool diffCase = false, bool isJson = true) => TypeConvert.To<T>(source, defobj, diffCase, isJson);

        /// <summary>
        /// 深拷贝一个实体对象
        /// </summary>
        /// <typeparam name="T">需要拷贝的对象类型</typeparam>
        /// <param name="source">需要拷贝的原实体对象</param>
        /// <returns>拷贝的实体副本</returns>
        public static T Clone<T>(this T source)
        {
            //if (!typeof(T).IsSerializable)
            //{
            //    throw new ArgumentException("The type must be serializable.", "source");
            //}

            if (ReferenceEquals(source, null))
            {
                return default(T);
            }

            //IFormatter formatter = new BinaryFormatter();
            //Stream stream = new MemoryStream();
            //using (stream)
            //{
            //    formatter.Serialize(stream, source);
            //    stream.Seek(0, SeekOrigin.Begin);
            //    return (T)formatter.Deserialize(stream);
            //}

            var serilize = JsonHelper.Serialize(source);
            return JsonHelper.Deserialize<T>(serilize);
        }

    }
}
