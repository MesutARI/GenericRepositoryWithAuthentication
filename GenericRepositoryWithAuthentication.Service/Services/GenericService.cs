
using GenericRepositoryWithAuthentication.Core.Repositories;
using GenericRepositoryWithAuthentication.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;

namespace GenericRepositoryWithAuthentication.Service.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        #region variables

        private readonly IGenericRepository<T> _genericRepository;

        #endregion

        #region GenericService
        public GenericService(IGenericRepository<T> genericRepository)
        {
            this._genericRepository = genericRepository;
        }


        #endregion

        #region Methods

        #region GetAll
        public GenericResponse<IEnumerable<T>> GetAll()
        {
            return GetAllAsync().Result;
        }

        public async Task<GenericResponse<IEnumerable<T>>> GetAllAsync()
        {
            try
            {
                IEnumerable<T> t = await this._genericRepository.GetAllAsync();
                if (t != null && t.Count() > 0)
                    return new GenericResponse<IEnumerable<T>>(t);
                return new GenericResponse<IEnumerable<T>>($"!!! Unable to find any records in {typeof(T).Name}'s table ", HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return new GenericResponse<IEnumerable<T>>($"Fail:: {ex.Message}", HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region GetById
        public GenericResponse<T> GetById(int id)
        {
            return GetByIdAsync(id).Result;
        }

        public async Task<GenericResponse<T>> GetByIdAsync(int id)
        {
            try
            {
                T t = await this._genericRepository.GetByIdAsync(id);
                if (t != null)
                    return new GenericResponse<T>(t);
                return new GenericResponse<T>($"!!! Unable to find a record with Id: {id} in {typeof(T).Name}'s table", HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {

                return new GenericResponse<T>($"Fail:: {ex.Message}", HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region CountWhere
        public int CountWhere(Expression<Func<T, bool>> predicate)
        {
            return CountWhereAsync(predicate).Result;
        }

        public async Task<int> CountWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await this._genericRepository.CountWhereAsync(predicate);

        }
        #endregion

        #region GetWhere
        public GenericResponse<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return GetWhereAsync(predicate).Result;
        }

        public async Task<GenericResponse<IEnumerable<T>>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                IEnumerable<T> t = await this._genericRepository.GetWhereAsync(predicate);
                if (t != null && t.Count() > 0)
                    return new GenericResponse<IEnumerable<T>>(t);
                return new GenericResponse<IEnumerable<T>>($"!!! Unable to find any records in {typeof(T).Name}'s table by this conditions", HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return new GenericResponse<IEnumerable<T>>($"Fail:: {ex.Message}", HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region Add
        public GenericResponse<T> Add(T Entry)
        {
            return AddAsync(Entry).Result;
        }

        public async Task<GenericResponse<T>> AddAsync(T Entry)
        {
            try
            {
                await this._genericRepository.AddAsync(Entry);
                //await this._unitOfWork.CompleteAsync();

                return new GenericResponse<T>(Entry);

            }
            catch (Exception ex)
            {
                return new GenericResponse<T>($"Fail:: {ex.Message}", HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region Update
        public GenericResponse<T> Update(T Entry)
        {
            try
            {
                this._genericRepository.Update(Entry);
                //this._unitOfWork.CompleteAsync();

                return new GenericResponse<T>(Entry);
            }
            catch (Exception ex)
            {
                return new GenericResponse<T>($"Fail:: {ex.Message}", HttpStatusCode.BadRequest);

            }
        }

        
        #endregion

        #region Delete
        public GenericResponse<T> Delete(int id)
        {
            return DeleteAsync(id).Result;
        }

        public async Task<GenericResponse<T>> DeleteAsync(int id)
        {
            try
            {
                T t = await this._genericRepository.GetByIdAsync(id);

                if (t != null)
                {
                    await this._genericRepository.DeleteAsync(id);
                    //await this._unitOfWork.CompleteAsync();
                    return new GenericResponse<T>(t);
                }
                else
                    return new GenericResponse<T>($"!!! Unable to find any record for deleting with Id: {id} in {typeof(T).Name}'s table", HttpStatusCode.NotFound);

            }
            catch (Exception ex)
            {
                return new GenericResponse<T>($"Fail:: {ex.Message}", HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #endregion
    }
}
