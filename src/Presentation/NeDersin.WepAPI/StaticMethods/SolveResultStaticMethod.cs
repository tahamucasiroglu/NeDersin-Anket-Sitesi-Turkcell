using Microsoft.AspNetCore.Mvc;
using NeDersin.DTOs.Concrete.Response.Models.HateoasModels;
using NeDersin.DTOs.Concrete.Response.Models.ReturnModels;
using NeDersin.ReturnModel.Abstract;
using NeDersin.WepAPI.Enumeration.HateoasEnumeration;

namespace NeDersin.WepAPI.StaticMethods
{
    static public partial class StaticHelperMethods
    {
        /// <summary>
        /// IreturnType içini kontrol eder ve başarısız veya boş durumlara göre sonuçlar döner genel kontrol olduğu için çoğu yerde kullanılır ve işleri kolaylaştırır IReturnModel<IEnumerable<TSuccess>> veya IReturnModel<TSuccess>  şeklinde result alır.
        /// yalan yok biraz yama fonksiyonu oldu bu geliştirilirdi ama vakit kalmadı
        /// </summary>
        /// <typeparam name="TSuccess"> başarılı durumda hangi türde döneceğini söyleriz</typeparam>
        /// <typeparam name="TError"> başarısız durumda hangi tipte </typeparam>
        /// <param name="result">gelen IReturnModel tipi</param>
        /// <param name="hateoasModel">Hateoas Sınıfı</param>
        /// <returns></returns>
        static public IActionResult SolveResult<TSuccess, TError>(IReturnModel<TSuccess> result, HateoasModel hateoasModel)
        {
            if (!result.Status)
            {
                return new BadRequestObjectResult(new ErrorReturnToClientModel<TError>
                    (
                        result.Message + result.Exception?.Message,
                        default,
                        hateoasModel
                    ));
            }
            return result.Data != null ?
                new OkObjectResult(new SuccessReturnToClientModel<TSuccess>
                (
                    result.Message,
                    result.Data,
                    hateoasModel
                ))
            :
                new BadRequestObjectResult(new ErrorReturnToClientModel<TError>
                (
                    result.Message + result.Exception?.Message,
                    default,
                    hateoasModel
                ));
        }
        /// <summary>
        /// IreturnType içini kontrol eder ve başarısız veya boş durumlara göre sonuçlar döner genel kontrol olduğu için çoğu yerde kullanılır ve işleri kolaylaştırır IReturnModel<IEnumerable<TSuccess>> veya IReturnModel<TSuccess>  şeklinde result alır.
        /// yalan yok biraz yama fonksiyonu oldu bu geliştirilirdi ama vakit kalmadı
        /// </summary>
        /// <typeparam name="TSuccess"> başarılı durumda hangi türde döneceğini söyleriz</typeparam>
        /// <typeparam name="TError"> başarısız durumda hangi tipte </typeparam>
        /// <param name="result">gelen IReturnModel tipi</param>
        /// <param name="hateoasModel">Hateoas Sınıfı</param>
        /// <returns></returns>
        static public IActionResult SolveResult<TSuccess, TError>(IReturnModel<IEnumerable<TSuccess>> result, HateoasModel hateoasModel)
        {
            if (!result.Status)
            {
                return new BadRequestObjectResult(new ErrorReturnToClientModel<TError>
                    (
                        result.Message + result.Exception?.Message,
                        default,
                        hateoasModel
                    ));
            }
            return result.Data != null ?
                new OkObjectResult(new SuccessReturnToClientModel<IEnumerable<TSuccess>>
                (
                    result.Message,
                    result.Data,
                    hateoasModel
                ))
            :
                new BadRequestObjectResult(new ErrorReturnToClientModel<TError>
                (
                    result.Message + result.Exception?.Message,
                    default,
                    hateoasModel
                ));
        }
        /// <summary>
        /// IreturnType içini kontrol eder ve başarısız veya boş durumlara göre sonuçlar döner genel kontrol olduğu için çoğu yerde kullanılır ve işleri kolaylaştırır IReturnModel<IEnumerable<TSuccess>> veya IReturnModel<TSuccess>  şeklinde result alır.
        /// yalan yok biraz yama fonksiyonu oldu bu geliştirilirdi ama vakit kalmadı
        /// </summary>
        /// <typeparam name="TGeneral"> Hangi tipte işlem yapılacak</typeparam>
        /// <param name="result">gelen IReturnModel tipi</param>
        /// <param name="hateoasModel">Hateoas Sınıfı</param>
        /// <returns></returns>
        static public IActionResult SolveResult<TGeneral>(IReturnModel<TGeneral> result, HateoasModel hateoasModel)
        {
            if (!result.Status)
            {
                return new BadRequestObjectResult(new ErrorReturnToClientModel<TGeneral>
                    (
                        result.Message + result.Exception?.Message,
                        default,
                        hateoasModel
                    ));
            }
            return result.Data != null ?
                new OkObjectResult(new SuccessReturnToClientModel<TGeneral>
                (
                    result.Message,
                    result.Data,
                    hateoasModel
                ))
            :
                new BadRequestObjectResult(new ErrorReturnToClientModel<TGeneral>
                (
                    result.Message + result.Exception?.Message,
                    default,
                    hateoasModel
                ));
        }
        /// <summary>
        /// IreturnType içini kontrol eder ve başarısız veya boş durumlara göre sonuçlar döner genel kontrol olduğu için çoğu yerde kullanılır ve işleri kolaylaştırır IReturnModel<IEnumerable<TSuccess>> veya IReturnModel<TSuccess>  şeklinde result alır.
        /// yalan yok biraz yama fonksiyonu oldu bu geliştirilirdi ama vakit kalmadı
        /// </summary>
        /// <typeparam name="TGeneral"> Hangi tipte işlem yapılacak</typeparam>
        /// <param name="result">gelen IReturnModel tipi</param>
        /// <param name="hateoasModel">Hateoas Sınıfı</param>
        /// <returns></returns>
        static public IActionResult SolveResult<TGeneral>(IReturnModel<IEnumerable<TGeneral>> result, HateoasModel hateoasModel)
        {
            if (!result.Status)
            {
                return new BadRequestObjectResult(new ErrorReturnToClientModel<TGeneral>
                    (
                        result.Message + result.Exception?.Message,
                        default,
                        hateoasModel
                    ));
            }
            return result.Data != null ?
                new OkObjectResult(new SuccessReturnToClientModel<IEnumerable<TGeneral>>
                (
                    result.Message,
                    result.Data,
                    hateoasModel
                ))
            :
                new BadRequestObjectResult(new ErrorReturnToClientModel<TGeneral>
                (
                    result.Message + result.Exception?.Message,
                    default,
                    hateoasModel
                ));
        }
    }
}
