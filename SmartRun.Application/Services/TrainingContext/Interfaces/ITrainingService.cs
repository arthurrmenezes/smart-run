using SmartRun.Application.Services.TrainingContext.DataTransferObject;
using SmartRun.Domain.ValueObjects;

namespace SmartRun.Application.Services.TrainingContext.Interfaces;

public interface ITrainingService
{
    public Task<GetTrainingDTO> CreateTrainingServiceAsync(IdValueObject accountId, CreateTrainingDTO createTrainingDto);

    public Task<GetTrainingDTO> GetTrainingByIdServiceAsync(IdValueObject trainingId);

    public Task<GetTrainingDTO[]> GetAllTrainingsByAccountIdServiceAsync(IdValueObject accountId);

    public Task RemoveTrainingByIdServiceAsync(IdValueObject trainingId);

    public Task<GetTrainingDTO> UpdateTrainingByIdServiceAsync(IdValueObject trainingId, UpdateTrainingDTO updateTrainingDTO);



    //public Task<GetTrainingDTO> GetFasterTraining2kmServiceAsync();

    //public Task<GetTrainingDTO> GetLongestTrainingServiceAsync();

    //public Task<GetTrainingDTO> GetMostDistantTrainingServiceAsync();

    //public Task<GetTrainingDTO> GetAllTrainingByDateServiceAsync(DateTime data);

    //public Task<GetTrainingDTO> GetTrainingByDateServiceAsync(int accountId, DateTime data);

    //public Task<List<GetTrainingDTO>> GetAllTrainingByMonth(DateTime data);

    //public Task<List<GetTrainingDTO>> GetTrainingByMonth(int accountId, DateTime data);

    //public Task<List<GetTrainingDTO>> GetAllTrainingByYear(DateTime data);

    //public Task<List<GetTrainingDTO>> GetTrainingByYear(int accountId, DateTime data);

    //public Task<List<GetTrainingDTO>> GetAllTrainingByLastMonth(DateTime data);

    //public Task<List<GetTrainingDTO>> GetTrainingByLastMonth(int accoundId, DateTime data);

    //public Task<List<GetTrainingDTO>> GetAllTrainingByLastYear(DateTime data);

    //public Task<List<GetTrainingDTO>> GetTrainingByLastYear(int accoundId, DateTime data);
}
