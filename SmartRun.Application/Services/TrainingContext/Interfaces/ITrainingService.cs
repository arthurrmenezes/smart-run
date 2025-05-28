using SmartRun.Application.Services.TrainingContext.DataTransferObject;

namespace SmartRun.Application.Services.TrainingContext.Interfaces;

public interface ITrainingService
{
    public Task CreateTrainingServiceAsync(Guid accountId, CreateTrainingDTO createTrainingDto);

    public Task<GetTrainingDTO> GetTrainingByIdServiceAsync(Guid trainingId);

    public Task<GetTrainingDTO[]> GetAllTrainingsByAccountIdServiceAsync(Guid accountId);

    public Task RemoveTrainingServiceAsync(Guid trainingId);

    public Task<GetTrainingDTO> UpdateTrainingServiceAsync(Guid trainingId, UpdateTrainingDTO updateTrainingDTO);

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
