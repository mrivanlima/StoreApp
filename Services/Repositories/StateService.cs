using Economizze.Library;
using StoreApp.Services.Interfaces;
using StoreApp.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Services.Repositories
{
    public class StateService : IStateService
    {
        private readonly List<State> _states = new();
        public State State { get; set; }

        public StateService()
        {
            // Initialize with all Brazilian states
            _states.AddRange(new List<State>
        {
            new State { StateId = 1, StateName = "Acre", StateUf = "AC", StateNameAscii = "acre", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 2, StateName = "Alagoas", StateUf = "AL", StateNameAscii = "alagoas", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 3, StateName = "Amapá", StateUf = "AP", StateNameAscii = "amapa", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 4, StateName = "Amazonas", StateUf = "AM", StateNameAscii = "amazonas", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 5, StateName = "Bahia", StateUf = "BA", StateNameAscii = "bahia", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 6, StateName = "Ceará", StateUf = "CE", StateNameAscii = "ceara", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 7, StateName = "Distrito Federal", StateUf = "DF", StateNameAscii = "distrito_federal", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 8, StateName = "Espírito Santo", StateUf = "ES", StateNameAscii = "espirito_santo", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 9, StateName = "Goiás", StateUf = "GO", StateNameAscii = "goias", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 10, StateName = "Maranhão", StateUf = "MA", StateNameAscii = "maranhao", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 11, StateName = "Mato Grosso", StateUf = "MT", StateNameAscii = "mato_grosso", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 12, StateName = "Mato Grosso do Sul", StateUf = "MS", StateNameAscii = "mato_grosso_do_sul", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 13, StateName = "Minas Gerais", StateUf = "MG", StateNameAscii = "minas_gerais", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 14, StateName = "Pará", StateUf = "PA", StateNameAscii = "para", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 15, StateName = "Paraíba", StateUf = "PB", StateNameAscii = "paraiba", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 16, StateName = "Paraná", StateUf = "PR", StateNameAscii = "parana", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 17, StateName = "Pernambuco", StateUf = "PE", StateNameAscii = "pernambuco", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 18, StateName = "Piauí", StateUf = "PI", StateNameAscii = "piaui", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 19, StateName = "Rio de Janeiro", StateUf = "RJ", StateNameAscii = "rio_de_janeiro", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 20, StateName = "Rio Grande do Norte", StateUf = "RN", StateNameAscii = "rio_grande_do_norte", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 21, StateName = "Rio Grande do Sul", StateUf = "RS", StateNameAscii = "rio_grande_do_sul", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 22, StateName = "Rondônia", StateUf = "RO", StateNameAscii = "rondonia", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 23, StateName = "Roraima", StateUf = "RR", StateNameAscii = "roraima", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 24, StateName = "Santa Catarina", StateUf = "SC", StateNameAscii = "santa_catarina", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 25, StateName = "São Paulo", StateUf = "SP", StateNameAscii = "sao_paulo", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 26, StateName = "Sergipe", StateUf = "SE", StateNameAscii = "sergipe", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new State { StateId = 27, StateName = "Tocantins", StateUf = "TO", StateNameAscii = "tocantins", CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now }
        });
        }

        public async Task<IEnumerable<State>> GetAllAsync()
        {
            return await Task.Run(() => _states.AsEnumerable());
        }

        public async Task<State?> GetByIdAsync(int id)
        {
            State = await Task.Run(() => _states.FirstOrDefault(s => s.StateId == id));
            return State;
        }

        public async Task AddAsync(State entity)
        {
            await Task.Run(() =>
            {
                entity.StateId = (short)(_states.Any() ? _states.Max(s => s.StateId) + 1 : 1);
                entity.CreatedOn = DateTime.Now;
                entity.ModifiedOn = DateTime.Now;
                _states.Add(entity);
            });
        }

        public async Task UpdateAsync(State entity)
        {
            await Task.Run(() =>
            {
                var existingState = _states.FirstOrDefault(s => s.StateId == entity.StateId);
                if (existingState != null)
                {
                    existingState.StateName = entity.StateName;
                    existingState.StateUf = entity.StateUf;
                    existingState.StateNameAscii = entity.StateNameAscii;
                    existingState.Longitude = entity.Longitude;
                    existingState.Latitude = entity.Latitude;
                    existingState.ModifiedBy = entity.ModifiedBy;
                    existingState.ModifiedOn = DateTime.Now;
                }
            });
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Run(() =>
            {
                var state = _states.FirstOrDefault(s => s.StateId == id);
                if (state != null)
                {
                    _states.Remove(state);
                }
            });
        }

        

       

        Task<Result<State>> IService<State>.AddAsync(State entity)
        {
            throw new NotImplementedException();
        }

        Task<Result<State>> IService<State>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Result<State>> IService<State>.UpdateAsync(State entity)
        {
            throw new NotImplementedException();
        }
    }
}
