using System;
using System.Linq;

namespace MyFigure.Helpers
{
    public static class HashHelper
    {
        /// <summary>
        /// Генерит единый хэш-код для заданного списка параметров, с учетом их порядка следования
        /// </summary>
        /// <param name="objs">Список параметров по которым нужно получить хэш-код</param>
        /// <returns>Хэш-код</returns>
        public static int RSHash(params object[] objs)
        {
            const int b = 378551;
            int a = 63689;
            int hash = 0;
            unchecked
            {
                foreach (var o in objs.Where(x => x != null))
                {
                    hash = hash * a + o.GetHashCode();
                    a *= b;
                }
            }

            return hash;
        }

        /// <summary>
        /// Генерит единый хэш-код для заданного списка параметров, с учетом их порядка следования
        /// </summary>
        /// <param name="objs">Список параметров по которым нужно получить хэш-код</param>
        /// <returns>Хэш-код</returns>
        public static int SimpleHash(params object[] objs)
        {
            var hash = 0;
            unchecked
            {
                foreach (var o in objs.Where(x => x != null))
                    hash = hash * 31 + o.GetHashCode();
            }

            return hash;
        }
    }
}
