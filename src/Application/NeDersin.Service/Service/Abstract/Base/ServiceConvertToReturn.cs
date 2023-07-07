using AutoMapper;
using NeDersin.DTOs.Abstract;
using NeDersin.Entities.Abstract;
using NeDersin.Infrastructure.Repositoryies.Abstract.Base;
using NeDersin.ReturnModel.Abstract;
using NeDersin.ReturnModel.Concrete;
using NeDersin.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Services.Service.Abstract.Base
{
    /// <summary>
    /// Geri dönüş değerlerini dönüştürmek için yardımcı methodlar içeren abstract temel hizmet sınıfı.
    /// </summary>
    abstract public class ServiceConvertToReturn
    {
        /// <summary>
        /// Tüm servis dönüşlerini kontrol etmek ve kolayca dönüştürmek için kullanılan yardımcı bir method.
        /// </summary>
        /// <typeparam name="TCheck">Dönüştürülecek DTO tipini belirten IDto türetilmiş sınıf.</typeparam>
        /// <typeparam name="Entity">Db'den dönen verinin tipini belirten IEntity türetilmiş sınıf.</typeparam>
        /// <param name="result">Db'den gelen ve DTO'ya dönüştürülecek veriyi temsil eden IReturnModel nesnesi.</param>
        /// <param name="mapper">DTO dönüşümünde kullanılacak IMapper nesnesi.</param> 
        /// <returns>Dönüştürülen sonucu temsil eden IReturnModel nesnesi.</returns>
        public static IReturnModel<TCheck> ConvertToReturn<TCheck, Entity>(IReturnModel<Entity> result, IMapper mapper)
            where TCheck : class, IDto
            where Entity : class, IEntity, new()
        {
            if (result.Status)
            {
                return result.Data == null
                    ? new SuccessReturnModel<TCheck>("Data is null")
                    : new SuccessReturnModel<TCheck>(result.Data.ConvertToDtoCustom<TCheck>(mapper));
            }
            else
            {
                return new ErrorReturnModel<TCheck>(result.Message, null, result.Exception);
            }
        }
        /// <summary>
        /// Tüm servis dönüşlerini kontrol etmek ve kolayca dönüştürmek için kullanılan yardımcı bir method.
        /// </summary>
        /// <typeparam name="TCheck">Dönüştürülecek DTO tipini belirten IDto türetilmiş sınıf.</typeparam>
        /// <typeparam name="Entity">Db'den dönen verinin tipini belirten IEntity türetilmiş sınıf.</typeparam>
        /// <param name="result">Db'den gelen ve DTO'ya dönüştürülecek veriyi temsil eden IReturnModel nesnesi.</param>
        /// <param name="mapper">DTO dönüşümünde kullanılacak IMapper nesnesi.</param> 
        /// <returns>Dönüştürülen sonucu temsil eden IReturnModel nesnesi.</returns>
        public static IReturnModel<IEnumerable<TCheck>> ConvertToReturn<TCheck, Entity>(IReturnModel<IEnumerable<Entity>> result, IMapper mapper)
            where TCheck : class, IDto
            where Entity : class, IEntity, new()
        {
            if (result.Status)
            {
                return result.Data == null ?
                    new SuccessReturnModel<IEnumerable<TCheck>>("Data is null") :
                    new SuccessReturnModel<IEnumerable<TCheck>>(result.Data.ConvertToDtoCustom<TCheck>(mapper));
            }
            else
            {
                return new ErrorReturnModel<IEnumerable<TCheck>>(result.Message, null, result.Exception);
            }
        }
    }
}
