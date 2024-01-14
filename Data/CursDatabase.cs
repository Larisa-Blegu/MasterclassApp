using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Threading.Tasks;
using MasterclassApp.Models;

namespace MasterclassApp.Data
{
    public class CursDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public CursDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Curs>().Wait();
            _database.CreateTableAsync<Client>().Wait();
            _database.CreateTableAsync<Bilet>().Wait();
            _database.CreateTableAsync<Inscriere>().Wait();
        }

        public Task<List<Curs>> GetCursAsync()
        {
            return _database.Table<Curs>().ToListAsync();
        }


        public Task<Curs> GetCursAsync(int id)
        {
            return _database.Table<Curs>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }
        public Task<Client> GetClientAsync(int id)
        {
            return _database.Table<Client>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }
        public Task<Bilet> GetBiletAsync(int id)
        {
            return _database.Table<Bilet>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<Curs> GetCursNumeAsync(String numeCurs)
        {
            return _database.Table<Curs>()
                .Where(i => i.Name==numeCurs)
                .FirstOrDefaultAsync();
        }
        public Task<Inscriere> GetInscriereAsync(String numeCurs)
        {

            int cursID = App.Database.GetCursNumeAsync(numeCurs).Result.ID;

            return _database.Table<Inscriere>()
                .Where(i => i.CursID== cursID)
                .FirstOrDefaultAsync();
        }


        public Task<List<Inscriere>> GetInscriereAsync()
        {
            return _database.Table<Inscriere>().ToListAsync();

        }
        public Task<List<InscriereDTO>> GetInscriereDTOAsync()
        {
            List<Inscriere> inscrieri = App.Database.GetInscriereAsync().Result;

            List<InscriereDTO> inscrieriDTO = new List<InscriereDTO>();

            foreach(Inscriere inscriere in  inscrieri)
            {
                InscriereDTO inscriereDTO = new InscriereDTO();
                Client client = App.Database.GetClientAsync(inscriere.ClientID).Result;
                inscriereDTO.Client = client.Nume;
                Curs curs= App.Database.GetCursAsync(inscriere.CursID).Result;
                inscriereDTO.Curs = curs.Name;
                Bilet bilet = App.Database.GetBiletAsync(inscriere.BiletID).Result;
                inscriereDTO.Bilet = bilet.Tip;

                inscrieriDTO.Add(inscriereDTO);
            }

            return Task.FromResult(inscrieriDTO);

        }

        public Task<int> SaveInscriereAsync(Inscriere inscriere)
        {
            if (inscriere.ID != 0)
            {
                return _database.UpdateAsync(inscriere);
            }
            else
            {
                return _database.InsertAsync(inscriere);
            }
        }





        public Task<int> SaveCursAsync(Curs curs)
        {
            if (curs.ID != 0)
            {
                return _database.UpdateAsync(curs);
            }
            else
            {
                return _database.InsertAsync(curs);
            }
        }

        public Task<int> DeleteInscriereAsync(Inscriere inscriere)
        {
            return _database.DeleteAsync(inscriere);
        }

        public Task<int> DeleteCursAsync(Curs curs)
        {
            return _database.DeleteAsync(curs);
        }

        public Task<int> SaveBiletAsync(Bilet bilet)
        {
            if (bilet.ID != 0)
            {
                return _database.UpdateAsync(bilet);
            }
            else
            {
                return _database.InsertAsync(bilet);
            }
        }

        public Task<List<Bilet>> GetBiletAsync()
        {
            return _database.Table<Bilet>().ToListAsync();
        }

        public Task<int> DeleteBiletAsync(Bilet bilet)
        {
            return _database.DeleteAsync(bilet);
        }

        public Task<Client> AuthenticateClientAsync(string email, string password)
        {
            return _database.Table<Client>()
                .Where(u => u.Email == email && u.Parola == password)
                .FirstOrDefaultAsync();
        }

        public Task<List<Client>> GetClientAsync()
        {
            return _database.Table<Client>().ToListAsync();
        }

        public Task<int> DeleteClientAsync(Client client)
        {
            return _database.DeleteAsync(client);
        }
        public Task<int> SaveClientAsync(Client client)
        {
            if (client.ID != 0)
            {
                return _database.UpdateAsync(client);
            }
            else
            {
                return _database.InsertAsync(client);
            }
        }
        public async Task<int?> GetUserIdByEmailAndPasswordAsync(string email, string password)
        {

            var clientUserId = await _database.Table<Client>()
                .Where(u => u.Email == email && u.Parola == password)
                .FirstOrDefaultAsync();

            if (clientUserId != null)
                return clientUserId.ID;
            else
                return null;
        }
    }
}
