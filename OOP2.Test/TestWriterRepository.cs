using OOP2.Domain;

namespace OOP2.Test
{
    public class TestWriterRepository
    {
        [Fact]
        public void TestCreateDatabase()
        {
            var helper = new Helper();
            var writerRepository = helper.WriterRepository;

            Assert.Equal(1,1);
        }

        [Fact]
        public void TestAddWriter()
        {
            var helper = new Helper();
            var writerRepository = helper.WriterRepository;
            var writer = new Writer { Name = "Лев", Patronymic = "Николаевич", SecondName = "Толстой" };

            writerRepository.AddWriterAsync(writer).Wait();
            writerRepository.ChangeTrackerClear();

            Assert.True(writerRepository.GetAllWritersAsync().Result.Count == 4);
            Assert.Equal("Лев", writerRepository.GetWriterByNameAsync("Лев").Result?.Name);
        }

        [Fact]
        public void TestUpdateWriter()
        {
            var helper = new Helper();
            var writerRepository = helper.WriterRepository;
            var writer = writerRepository.GetWriterByNameAsync("Александр").Result;
            writerRepository.ChangeTrackerClear();

            writer.Name = "Сергей";
            writerRepository.UpdateWriterAsync(writer).Wait();

            Assert.Equal("Сергей", writerRepository.GetWriterByNameAsync("Сергей").Result?.Name);
        }

        [Fact]
        public void TestPupiLupiWriter() //Deleter esli 4o
        {
            var helper = new Helper();
            var writerRepository = helper.WriterRepository;
            Guid writer = writerRepository.GetWriterByNameAsync("Фёдор").Result.Id;
            writerRepository.ChangeTrackerClear();

            writerRepository.DeleteWriterAsync(writer).Wait();
            Assert.Equal(2, writerRepository.GetAllWritersAsync().Result?.Count);
            
        }
    }
}