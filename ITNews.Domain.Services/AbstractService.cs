using DomainModels;
using ITNews.Data.Contracts;
using System;
using System.Collections.Generic;

namespace Services
{
    public abstract class AbstractService<TServiceModel, TRepositoryModel> : IInfoModelService<TServiceModel>
    {
        private IEntityRepository<TRepositoryModel> BaseRepository { get; set; }

        public AbstractService(IEntityRepository<TRepositoryModel> repository)
        {
            BaseRepository = repository;
        }

        public void Delete(int id)
        {
            BaseRepository.Delete(id);
        }

        public IEnumerable<TServiceModel> GetModelCollections()
        {
            var repositoryResponse = BaseRepository.GetModelCollections();
            return AutoMapper.Mapper.Map<IEnumerable<TRepositoryModel>, IEnumerable<TServiceModel>>(repositoryResponse);
        }

        public void Create(TServiceModel infoModel)
        {
            var dbModel = AutoMapper.Mapper.Map<TServiceModel, TRepositoryModel>(infoModel);
            BaseRepository.Create(dbModel);
        }

        public TServiceModel GetModelById(int id)
        {
            var dbModel = BaseRepository.GetModelById(id);
            return AutoMapper.Mapper.Map<TRepositoryModel, TServiceModel>(dbModel);
        }

        public void Update(TServiceModel infoModel)
        {
            var dbStudentModel = AutoMapper.Mapper.Map<TServiceModel, TRepositoryModel>(infoModel);
            BaseRepository.Update(dbStudentModel);
        }
    }
}
