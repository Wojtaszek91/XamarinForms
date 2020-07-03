using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Laboratoria.Models;
using SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratoria
{
    public class DataBaseContext
    {
        private SQLiteAsyncConnection dbContext = new SQLiteAsyncConnection(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "MySQLite.db3"), SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

        public SQLiteAsyncConnection DbContext { get => dbContext; set => dbContext = value; }

        private SQLiteConnectionWithLock connection { get; set; }

        public DataBaseContext()
        {
         //   SetTables();
        }

        public async void SetTables()
        {
            await DbContext.CreateTableAsync<AirQualityIndex>();
            await DbContext.CreateTableAsync<AirQualityStandard>();
            await DbContext.CreateTableAsync<InstallationsEntity>();
            await DbContext.CreateTableAsync<MeasurmentsEntity>();
            await DbContext.CreateTableAsync<MeasurmentItemEntity>();
            await DbContext.CreateTableAsync<MeasurementValue>();
            await DbContext.CreateTableAsync<DateTime>();
        }


        public async Task<IEnumerable<Installations>> GetAllInstallations()
        {
            List<Installations> installationsList = new List<Installations>();
           var installationsInDb = dbContext.Table<InstallationsEntity>();
            foreach (var entity in await installationsInDb.ToListAsync())
                installationsList.Add(new Installations(entity));
            return installationsList;
        }

        public List<Measurements> GetAllMeasurement()
        {
            var measurementList = new List<Measurements>();
            foreach (var measurementEntity in dbContext.Table<MeasurmentsEntity>().ToListAsync().Result)
            {
                measurementList.Add(new Measurements(measurementEntity)
                {
                    Current = new MeasurementItem(dbContext.Table<MeasurmentItemEntity>().ElementAtAsync(measurementEntity.Id).Result)
                    {
                        Standards = dbContext.Table<AirQualityStandard>().Where(x => x.Id == measurementEntity.Id).ToArrayAsync().Result,
                        Indexes = dbContext.Table<AirQualityIndex>().Where(x => x.Id == measurementEntity.Id).ToArrayAsync().Result,
                        Values = dbContext.Table<MeasurementValue>().Where(x => x.Id == measurementEntity.Id).ToArrayAsync().Result
                    },
                    Installation = new Installations(dbContext.GetAsync<InstallationsEntity>(measurementEntity.Installation).Result)
                });
            }
            return measurementList;
        }

        public async void SaveInstallationsList (IEnumerable<Installations> installationsList)
        {
            
            var installationsEntityList = new List<InstallationsEntity>();
            foreach(var entity in installationsList)
                installationsEntityList.Add(new InstallationsEntity(entity));


                await dbContext.DeleteAllAsync<InstallationsEntity>();
                await dbContext.InsertAllAsync(installationsEntityList);
        }

        public async void SaveAllMeasurements (IEnumerable<Measurements> measurementsList)
        {
            await dbContext.DeleteAllAsync<AirQualityIndex>();
            await dbContext.DeleteAllAsync<AirQualityStandard>();
            await dbContext.DeleteAllAsync<MeasurmentsEntity>();
            await dbContext.DeleteAllAsync<MeasurmentItemEntity>();
            await dbContext.DeleteAllAsync<MeasurementValue>();

            foreach (var dbInput in measurementsList)
            {
                await DbContext.InsertAsync(new MeasurmentsEntity(dbInput));
                await dbContext.InsertAllAsync(dbInput.Current.Indexes);
                await dbContext.InsertAllAsync(dbInput.Current.Standards);
                await dbContext.InsertAllAsync(dbInput.Current.Values);
                await dbContext.InsertAsync(new MeasurmentItemEntity(dbInput.Current));
            }

        }

    }
}
