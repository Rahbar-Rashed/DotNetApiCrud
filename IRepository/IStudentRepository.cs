using CoreProject.Helper;
using CoreProject.ServiceDTO;

namespace CoreProject.IRepository
{
    public interface IStudentRepository
    {
        public Task<StudentDTO> GetStudentById(long StudentId);
        public Task<MessageHelper> AddStudent(StudentDTO obj);
        public Task<MessageHelper> EditStudent(StudentDTO obj);
    }
}
