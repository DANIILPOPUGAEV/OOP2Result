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
            var writer = new Writer { Name = "���", Patronymic = "����������", SecondName = "�������" };

            writerRepository.AddWriterAsync(writer).Wait();
            writerRepository.ChangeTrackerClear();

            Assert.True(writerRepository.GetAllWritersAsync().Result.Count == 4);
            Assert.Equal("���", writerRepository.GetWriterByNameAsync("���").Result?.Name);
        }

        [Fact]
        public void TestUpdateWriter()
        {
            var helper = new Helper();
            var writerRepository = helper.WriterRepository;
            var writer = writerRepository.GetWriterByNameAsync("���������").Result;
            writerRepository.ChangeTrackerClear();

            writer.Name = "������";
            writerRepository.UpdateWriterAsync(writer).Wait();

            Assert.Equal("������", writerRepository.GetWriterByNameAsync("������").Result?.Name);
        }

        [Fact]
        public void TestPupiLupiWriter() //Deleter esli 4o
        {
            var helper = new Helper();
            var writerRepository = helper.WriterRepository;
            Guid writer = writerRepository.GetWriterByNameAsync("Ը���").Result.Id;
            writerRepository.ChangeTrackerClear();

            writerRepository.DeleteWriterAsync(writer).Wait();
            Assert.Equal(2, writerRepository.GetAllWritersAsync().Result?.Count);
            
        }
    }
}