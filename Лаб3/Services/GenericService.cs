using Services.Interfaces;
using Domain.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Domain.RepositoryInterfaces;
using Domain.Exceptions;
using ViewModels.BaseDTOs;
using Domain;

namespace Services
{
    public class GenericService<T> : IGenericService<T> where T : BaseModel 
    {
        protected IMapper _mapper;
        protected IRepositoryManager _repositoryManager;
        protected IGenericRepository<T> _repository;

        public GenericService(IRepositoryManager repositoryManager, IMapper mapper, IGenericRepository<T> repository)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> CreateAsync<TSource>(TSource entityDTO) 
        {
            var entity = _mapper.Map<T>(entityDTO); 
            try 
            {
                await _repository.CreateAsync(entity);
                await _repositoryManager.SaveAsync();
                return entity.Id; 
            } 
            catch (Exception exception) 
            { 
                throw new InternalServerErrorException($"Could not add {(typeof(T).Name)}!", exception);
            }
        }

        public async Task<TResult> GetByIdAsync<TResult>(int id)
        {
            var entity = await _repository.GetByCondition(e => e.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new ItemNotFoundException(ErrorMessages.UserNotFound); 
            }

            var entityDTO = _mapper.Map<TResult>(entity);
            return entityDTO; 
        }

        public async Task<List<TResult>> GetAllAsync<TResult>() where TResult : class 
        {
            var allEntities = await _repository.GetAll().ToListAsync();
            var entitiesDTOs = _mapper.Map<List<TResult>>(allEntities);
            return entitiesDTOs;
        }

        public async Task UpdateAsync<TSource>(TSource entityDTO) where TSource : BaseIdDTO
        { 
            var entity = await GetByIdAsync<T>(Convert.ToInt32(entityDTO.Id ?? default(int)));
            entity = _mapper.Map(entityDTO, entity);
            await _repository.UpdateAsync(entity);
            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync<T>(id);
            if (entity == null)
            {
                throw new ItemNotFoundException($"{typeof(T)} is not found!"); 
            }
            await _repository.DeleteAsync(entity);
            await _repositoryManager.SaveAsync();
        }
    }
}
