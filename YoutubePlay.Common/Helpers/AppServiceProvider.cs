using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace YoutubePlay.Common
{
    public class AppServiceProvider
    {
        private static AppServiceProvider _instance = new AppServiceProvider();
        private readonly ConcurrentDictionary<RuntimeTypeHandle, EntityMeta> serviceDictionary;

        public static AppServiceProvider Instance { get => _instance; }

        private AppServiceProvider()
        {
            serviceDictionary = new ConcurrentDictionary<RuntimeTypeHandle, EntityMeta>();
        }


        /// <summary>
        /// Parametre olarak gönderilen instance değeri Transient olarak kaydedilir.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="instanceType"></param>
        public void Register(Type type, object instance)
        {
            serviceDictionary.TryAdd(type.TypeHandle, new EntityMeta(instance.GetType(), null));
        }


        /// <summary>
        /// Parametre olarak gönderilen instance değeri Singleton olarak kaydedilir.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="singletonInstance"></param>
        public void RegisterAsSingleton(Type type, object singletonInstance)
        {
            serviceDictionary.TryAdd(type.TypeHandle, new EntityMeta(singletonInstance.GetType(), singletonInstance));
        }

        /// <summary>
        /// Transient olarak kaydedilir.
        /// </summary>
        public void Register<TType, TInstance>() where TInstance : TType
        {
            serviceDictionary.TryAdd(typeof(TType).TypeHandle, new EntityMeta(typeof(TInstance), null));
        }

        public void ClearServiceDictionary()
        {
            this.serviceDictionary.Clear();
        }

        public T Get<T>()
        {

            if (!serviceDictionary.TryGetValue(typeof(T).TypeHandle, out var instanceMeta))
                throw new Exception(string.Format("ServiceRegistry key is not found in dictionary {0} ", typeof(T).ToString()));

            return instanceMeta.CreateInstance<T>();
        }

        public bool TrtGet<T>(out T service)
        {
            if (!serviceDictionary.TryGetValue(typeof(T).TypeHandle, out var instanceMeta))
            {
                service = default(T);
                return false;
            }

            service = instanceMeta.CreateInstance<T>();
            return true;
        }

        internal class EntityMeta
        {
            private readonly Func<object> constructor = null;
            private readonly object singletonInstance = null;
            private readonly Type instanceType = null;
            private readonly bool isTransactional = false;

            public EntityMeta(Type instanceType, object singletonInstance)
            {
                this.instanceType = instanceType;
                this.singletonInstance = singletonInstance;
                if (singletonInstance == null || this.isTransactional)
                    this.constructor = Expression.Lambda<Func<object>>(Expression.New(instanceType)).Compile();
            }

            internal T CreateInstance<T>()
            {
                var instance = (T)constructor();
                return instance;
            }
        }
    }
}
